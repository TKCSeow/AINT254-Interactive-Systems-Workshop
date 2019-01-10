using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileManager : MonoBehaviour {

    // Use this for initialization
    public GameObject[] tilePrefabs;
    public GameObject[] tilePrefabsHalf;
 

    private float spawnZ = 0f;
    private float tileLength = 4.0f;

    
    public static Music song;
    public Text songTitle;
    public Text difficulty;

    public static int selectSong = 3;

    private int lastPrefabIndex = 0;
    private int genre = 1;



    void Start() {

        //Get genre
        genre = GameManager.genre;

        //Set difficulty Text
        if (GameManager.genre == 1)
        {
            difficulty.text = "Beginner";

        }
        else
        {
            difficulty.text = "Pro";

        }

        //Get song
        song = MusicDatabase.Instance.GetSong(selectSong,genre);
        print(song.songName);

        //Set song
        GameObject.FindGameObjectWithTag("Song").GetComponent<SongList>().SetSong(song.songName);

        //Set player Speed
        PlayerMovement.speed = song.songSpeed;

        //Spawn Tiles
        SpawnTile();

        //Set song info
        songTitle.text = song.songName;

        


    }

    // Update is called once per frame
    void Update() {
 
    }

    private void SpawnTile(int prefabIndex = -1)
    {
        GameObject go; //temp object

        //Spawn 10 empty tiles at beginning
        for (int i = 0; i < 10; i++)
        {          
                go = Instantiate(tilePrefabs[0]) as GameObject;
                Spawn(go);
        }

        //Spawn the "Start Song" tile
        go = Instantiate(tilePrefabs[4]) as GameObject;
        Spawn(go);

        //Spawn song tiles
        for (int i = 0; i < song.notes.Length; i++)
        {
            //For notes 1 to 8
            for (int j = 1; j <= 8; j++)
            {
                if (song.notes[i] == j)
                {
                    //Spawn note tile
                    go = Instantiate(tilePrefabs[RandomPrefabIndex()]) as GameObject;
                    Spawn(go);

                    //Spawn empty tiles to create length of note
                    for (int k = 1; k < j; k++)
                    {
                        go = Instantiate(tilePrefabs[0]) as GameObject;
                        Spawn(go);
                    }
                }
                

            }
            if (song.notes[i] == 0) //Spawn Empty tile
            {
                go = Instantiate(tilePrefabs[0]) as GameObject;
                Spawn(go);

            }
           
            if (song.notes[i] == 9) //Spawn half length note tile
            {
                go = Instantiate(tilePrefabsHalf[RandomPrefabIndex()]) as GameObject;
                Spawn(go, 2);

            }
            else if (song.notes[i] == 10) //Spawn half length empty tile
            {
                go = Instantiate(tilePrefabsHalf[0]) as GameObject;
                Spawn(go, 2);

            }
            else if (song.notes[i] == 11) //Spawn extra long note
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

        //Spawn the "Stop Song" tile
        go = Instantiate(tilePrefabs[5]) as GameObject;
        Spawn(go);

        //Spawn 11 empty tiles at end
        for (int i = 0; i < 11; i++)
        {
            go = Instantiate(tilePrefabs[0]) as GameObject;
            Spawn(go);
        }
    }

    private void Spawn(GameObject go)
    {
        
        //Get position of last tile and set to temp tile
        go.transform.SetParent(transform);

        //Move forward one tile length
        go.transform.position = Vector3.forward * spawnZ;

        //Update end of tiles
        spawnZ += tileLength;

    }

    private void Spawn(GameObject go, int i)
    {
        //Get position of last tile and set to temp tile
        go.transform.SetParent(transform);

        //Move forward one tile length
        go.transform.position = Vector3.forward * spawnZ;

        //Update end of tiles
        spawnZ += (tileLength / i);
    }


    private int RandomPrefabIndex()
    {
        // if only one type of tile
        if(tilePrefabs.Length <= 1)
        {
            return 0;
        }

        // Set last tile type to randomIndex
        int randomIndex = lastPrefabIndex;

        
        while (randomIndex == lastPrefabIndex) //while randomIndex is still the same as last tile type
        {
            randomIndex = Random.Range(1, tilePrefabs.Length -2);
        }

        //Set new tile type
        lastPrefabIndex = randomIndex;

        //Add tile type to count
        for (int i = 0; i < GameManager.tileCount.Length; i++)
        {
            if (i + 1 == randomIndex)
                GameManager.tileCount[i]++;

        }


        return randomIndex;
    }

    private int RandomPrefabIndex(bool d)
    {
        // if only one type of tile
        if (tilePrefabs.Length <= 1)
        {
            return 0;
        }

        // Set last tile type to randomIndex
        int randomIndex = lastPrefabIndex;

        while (randomIndex == lastPrefabIndex)//while randomIndex is still the same as last tile type
        {
            randomIndex = Random.Range(1, tilePrefabs.Length);
        }

        //Set new tile type
        lastPrefabIndex = randomIndex;

        //Add tile type to count
        for (int i = 0; i < GameManager.tileCount.Length; i++)
        {
            if (GameManager.tileCount[i + 1] == randomIndex)
                GameManager.tileCount[i]++;
        }

        return randomIndex;
    }
}
