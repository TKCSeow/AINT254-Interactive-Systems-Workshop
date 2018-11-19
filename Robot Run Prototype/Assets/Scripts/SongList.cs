using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongList : MonoBehaviour {

    public AudioClip[] songList;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetSong(string songName)
    {
        print(songName);
        GetComponent<AudioSource>().clip = songList[SearchSong(songName)];
    }

    public int SearchSong(string songName)
    {
        int song = 1;
        for (int i = 0; i < songList.Length; i++)
        {
            print(songList[i].name);
            if (songName == songList[i].name)
            {
                song = i;                
            }
        }



        print(song);
        return song;
    }
}
