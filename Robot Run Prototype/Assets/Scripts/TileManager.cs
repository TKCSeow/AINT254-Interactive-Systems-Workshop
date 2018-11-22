using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileManager : MonoBehaviour {

    // Use this for initialization
    public GameObject[] tilePrefabs;
    public GameObject[] tilePrefabsHalf;
 

    private Transform playerTransform;
    private float spawnZ = 0f;
    private float tileLength = 4.0f;
    private int amountTilesOnScreen = 10;

    private List<GameObject> activeTiles;
    
    public static Music song;
    public Text songTitle;
    public Text difficulty;
    //public static int selectSong = 1;
    public static int selectSong = 1;
    private int songDivisions;

    private int lastPrefabIndex = 0;



    void Start() {
       
        

        song = MusicDatabase.Instance.GetSong(selectSong);
        print(song.songName);

        GameObject.FindGameObjectWithTag("Song").GetComponent<SongList>().SetSong(song.songName);
        activeTiles = new List<GameObject>();

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        PlayerMovement.speed = song.songSpeed;
        SpawnTile();
        songTitle.text = song.songName;
        difficulty.text = "Difficulty: " + song.songDifficulty;
        

    }

    // Update is called once per frame
    void Update() {
 
    }

    private void SpawnTile(int prefabIndex = -1)
    {
        GameObject go;

        for (int i = 0; i < 10; i++)
        {          
                go = Instantiate(tilePrefabs[0]) as GameObject;
                Spawn(go);
        }

        go = Instantiate(tilePrefabs[4]) as GameObject;
        Spawn(go);



        for (int i = 0; i < song.notes.Length; i++)
        {

            for (int j = 1; j <= 8; j++)
            {
                if (song.notes[i] == j)
                {
                    go = Instantiate(tilePrefabs[RandomPrefabIndex()]) as GameObject;
                    Spawn(go);
                    for (int k = 1; k < j; k++)
                    {
                        go = Instantiate(tilePrefabs[0]) as GameObject;
                        Spawn(go);
                    }
                }
                

            }
            if (song.notes[i] == 0)
            {
                go = Instantiate(tilePrefabs[0]) as GameObject;
                Spawn(go);

            }
            //else if (song.notes[i] == 1)
            //{
            //    go = Instantiate(tilePrefabs[RandomPrefabIndex()]) as GameObject;
            //    Spawn(go);

            //}
            //else if (song.notes[i] == 2)
            //{
            //    go = Instantiate(tilePrefabs[RandomPrefabIndex()]) as GameObject;
            //    Spawn(go);
            //    go = Instantiate(tilePrefabs[0]) as GameObject;
            //    Spawn(go);
            //}
            //else if (song.notes[i] == 3)
            //{
            //    go = Instantiate(tilePrefabs[RandomPrefabIndex()]) as GameObject;
            //    Spawn(go);
            //    go = Instantiate(tilePrefabs[0]) as GameObject;
            //    Spawn(go);
            //    go = Instantiate(tilePrefabs[0]) as GameObject;
            //    Spawn(go);
            //}
            //else if (song.notes[i] == 4)
            //{
            //    go = Instantiate(tilePrefabs[RandomPrefabIndex()]) as GameObject;
            //    Spawn(go);
            //    for (int j = 1; j < 4; j++)
            //    {
            //        go = Instantiate(tilePrefabs[0]) as GameObject;
            //        Spawn(go);
            //    }
            //}
            //else if (song.notes[i] == 6)
            //{
            //    go = Instantiate(tilePrefabs[RandomPrefabIndex()]) as GameObject;
            //    Spawn(go);
            //    for (int j = 1; j < 6; j++)
            //    {
            //        go = Instantiate(tilePrefabs[0]) as GameObject;
            //        Spawn(go);
            //    }
            //}
            //else if (song.notes[i] == 8)
            //{
            //    go = Instantiate(tilePrefabs[RandomPrefabIndex()]) as GameObject;
            //    Spawn(go);
            //    for (int j = 1; j < 8; j++)
            //    {
            //        go = Instantiate(tilePrefabs[0]) as GameObject;
            //        Spawn(go);
            //    }
            //}
            if (song.notes[i] == 9)
            {
                go = Instantiate(tilePrefabsHalf[RandomPrefabIndex()]) as GameObject;
                Spawn(go, 2);

            }
            else if (song.notes[i] == 10)
            {
                go = Instantiate(tilePrefabsHalf[0]) as GameObject;
                Spawn(go, 2);

            }
            else if (song.notes[i] == 11)
            {
                go = Instantiate(tilePrefabs[RandomPrefabIndex()]) as GameObject;
                Spawn(go);
                for (int j = 1; j < 16; j++)
                {
                    go = Instantiate(tilePrefabs[0]) as GameObject;
                    Spawn(go);
                }
            }
            
        }
        go = Instantiate(tilePrefabs[5]) as GameObject;
        Spawn(go);
        for (int i = 0; i < 11; i++)
        {
            go = Instantiate(tilePrefabs[0]) as GameObject;
            Spawn(go);
        }
    }

    private void Spawn(GameObject go)
    {
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLength;
        activeTiles.Add(go);
    }

    private void Spawn(GameObject go, int i)
    {
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += (tileLength / i);
        activeTiles.Add(go);
    }

    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

    private int RandomPrefabIndex()
    {
        if(tilePrefabs.Length <= 1)
        {
            return 0;
        }

        int randomIndex = lastPrefabIndex;

        while (randomIndex == lastPrefabIndex)
        {
            randomIndex = Random.Range(1, tilePrefabs.Length -2);
        }

        lastPrefabIndex = randomIndex;

        for (int i = 0; i < GameManager.tileCount.Length; i++)
        {
            if (i + 1 == randomIndex)
                GameManager.tileCount[i]++;

        }
        return randomIndex;
    }

    private int RandomPrefabIndex(bool d)
    {
        if (tilePrefabs.Length <= 1)
        {
            return 0;
        }

        int randomIndex = lastPrefabIndex;

        while (randomIndex == lastPrefabIndex)
        {
            randomIndex = Random.Range(1, tilePrefabs.Length);
        }

        lastPrefabIndex = randomIndex;

        for (int i = 0; i < GameManager.tileCount.Length; i++)
        {
            if (GameManager.tileCount[i + 1] == randomIndex)
                GameManager.tileCount[i]++;
        }

        return randomIndex;
    }
}
