using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SongDescription : MonoBehaviour {

    // Use this for initialization
    public Text songText;
    private float songLength;
	
	// Update is called once per frame
    void Start()
    {
    }

	void Update () {
		for (int i = 0; i < MusicDatabase.Instance.GetSongCount(); i++)
        {
            if (GameManager.selectedSong == i)
            {
                Music temp = MusicDatabase.Instance.GetSong(i);
                songLength = SongList.Instance.SearchSongForLength(temp.songName);
                

                songText.text = "Name: " + temp.songName + "\n\nDifficulty: " + temp.songDifficulty + "\n\nLenth: " + FormatTime(songLength); ;
            }
        }
	}

    private string FormatTime(float songLength)
    {
        string time = "";
        int minutes = 0;
        int seconds = 0;
        string secondsString = "";
        minutes = (int)songLength / 60;
        seconds = (int)songLength - (minutes * 60);

        if (seconds < 10)
        {
            secondsString = "0" + seconds;
        }
        else
        {
            secondsString = seconds.ToString();
        }

        time = minutes + ":" + secondsString;

        return time;
    }

}
