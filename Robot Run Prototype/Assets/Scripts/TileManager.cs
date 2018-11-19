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
    private List<GameObject> Ramps;
    private float safeZone = 8.0f;
    private Music song;
    public Text songTitle;
    public Text difficulty;
    public int selectSong = 0;
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

        if (song.songDifficulty == 1)
        {
            difficulty.text = "Easy";
        }
        else if (song.songDifficulty == 2)
        {
            difficulty.text = "Normal";
        }
        else if (song.songDifficulty == 3)
        {
            difficulty.text = "Hard";

        }

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
            if (song.notes[i] == 0)
            {
                go = Instantiate(tilePrefabs[0]) as GameObject;
                Spawn(go);

            }
            else if (song.notes[i] == 1)
            {
                go = Instantiate(tilePrefabs[RandomPrefabIndex()]) as GameObject;
                Spawn(go);

            }
            else if (song.notes[i] == 2)
            {
                go = Instantiate(tilePrefabs[RandomPrefabIndex()]) as GameObject;
                Spawn(go);
                go = Instantiate(tilePrefabs[0]) as GameObject;
                Spawn(go);
            }
            else if (song.notes[i] == 3)
            {
                go = Instantiate(tilePrefabs[RandomPrefabIndex()]) as GameObject;
                Spawn(go);
                go = Instantiate(tilePrefabs[0]) as GameObject;
                Spawn(go);
                go = Instantiate(tilePrefabs[0]) as GameObject;
                Spawn(go);
            }
            else if (song.notes[i] == 4)
            {
                go = Instantiate(tilePrefabs[RandomPrefabIndex()]) as GameObject;
                Spawn(go);
                for (int j = 1; j < 4; j++)
                {
                    go = Instantiate(tilePrefabs[0]) as GameObject;
                    Spawn(go);
                }
            }
            else if (song.notes[i] == 8)
            {
                go = Instantiate(tilePrefabs[RandomPrefabIndex()]) as GameObject;
                Spawn(go);
                go = Instantiate(tilePrefabs[0]) as GameObject;
                Spawn(go);
                go = Instantiate(tilePrefabs[0]) as GameObject;
                Spawn(go);
                go = Instantiate(tilePrefabs[0]) as GameObject;
                Spawn(go);
                go = Instantiate(tilePrefabs[0]) as GameObject;
                Spawn(go);
                go = Instantiate(tilePrefabs[0]) as GameObject;
                Spawn(go);
                go = Instantiate(tilePrefabs[0]) as GameObject;
                Spawn(go);
                go = Instantiate(tilePrefabs[0]) as GameObject;
                Spawn(go);
            }
            else if (song.notes[i] == 9)
            {
                go = Instantiate(tilePrefabsHalf[RandomPrefabIndex()]) as GameObject;
                Spawn(go, true);

            }
            else
            {
                go = Instantiate(tilePrefabs[0]) as GameObject;
            }
        }
        go = Instantiate(tilePrefabs[5]) as GameObject;
        Spawn(go);
        for (int i = 0; i < 8; i++)
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

    private void Spawn(GameObject go, bool d)
    {
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += (tileLength / 2);
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
        return randomIndex;
    }
}
