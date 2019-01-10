using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongList : MonoBehaviour {

  
    public static SongList Instance { get; set; }
    public AudioClip[] songList;
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetSong(string songName)
    {
        GetComponent<AudioSource>().clip = songList[SearchSong(songName)];
    }

    public int SearchSong(string songName)
    {
        //return song by name
        int song = 1;
        for (int i = 0; i < songList.Length; i++)
        {

            if (songName == songList[i].name)
            {
                song = i;
            }
        }

        return song;
    }

    public float SearchSongForLength(string songName)
    {
        //Returns length of song in seconds

        float songLength = 0;
        for (int i = 0; i < songList.Length; i++)
        {

            if (songName == songList[i].name)
            {
                songLength = songList[i].length;
            }
        }

        return songLength;
    }
}
