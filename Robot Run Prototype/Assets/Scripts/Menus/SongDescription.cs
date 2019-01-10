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

        //cycle through current list
		for (int i = 0; i < MusicDatabase.Instance.GetSongCount(ShopScrollList.Instance.genre); i++)
        {
            if (GameManager.selectedSong == i) //if selected song matches
            {
                //Set to temp
                Music temp = MusicDatabase.Instance.GetSong(i, ShopScrollList.Instance.genre);

                //Get length of song (seconds)
                songLength = SongList.Instance.SearchSongForLength(temp.songName);
                
                //Set text
                songText.text = "Name: " + temp.songName + "\n\nGrade: " + temp.songDifficulty + "\n\nLength: " + FormatTime(songLength) + "\n\n" + temp.songDescription;
            }
        }
	}

    private string FormatTime(float songLength)
    {
        //Format length of song
        //e.g. songLength = 102 becomes 1:42

        string time = "";
        int minutes = 0;
        int seconds = 0;
        string secondsString = "";


        minutes = (int)songLength / 60;
        seconds = (int)songLength - (minutes * 60);

        if (seconds < 10)
        {
            secondsString = "0" + seconds; // format numbers under 10 to 01, 02 etc
        }
        else
        {
            secondsString = seconds.ToString();
        }

        time = minutes + ":" + secondsString;

        return time;
    }

}
