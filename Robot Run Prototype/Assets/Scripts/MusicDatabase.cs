using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicDatabase: MonoBehaviour {

    public static MusicDatabase Instance { get; set; }
    private List<Music> MusicList { get; set; }
    public TextAsset MusicFile;

    void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        BuildDatabase();
    }

    private void BuildDatabase()
    {
        string text;
        string[] splitText;
        string[] splitText2;
        float speed;
        int songDivisions;
        int difficulty;
        

        //Create temp Music
        Music temp;

        //Create a list of Music objects
        MusicList = new List<Music>();

        //Set text from external text file (.txt)
        text = MusicFile.text;

        //Get rid of all return carriage/new line 
        text = text.Replace("\r", "").Replace("\n", "");

        //Split text by ";", which separates the songs
        splitText = text.Split(';');
        Debug.Log(text);


        for (int i = 0; i < splitText.Length - 1; i++) //for how many songs
        {
            //Split text by "/", which separates the song's name. Index 0 contains song's name
            splitText2 = splitText[i].Split(',');
           
            //Create new string array with splitText2's length but minus one beacuse the last index will be empty 
            string[] notes = new string[splitText2.Length - 4];
            
            for (int j = 0; j < notes.Length; j++)
            {
                notes[j] = splitText2[j + 4];
             
            }
            
            //notes = notes[1].Split(',');

            int[] note = Array.ConvertAll<string, int>(notes, int.Parse);

            difficulty = int.Parse(splitText2[1]);
            speed = float.Parse(splitText2[3]);
            songDivisions = int.Parse(splitText2[2]);

            //Create new Music object with data i.e. Music(id, name, notes)
            temp = new Music(i, splitText2[0], difficulty, songDivisions, speed, note);

            print(splitText2[0]);
            print(note);


            //Add temp to list
            MusicList.Add(temp);

        }



    }

    public Music GetSong(int id)
    {
        //Search for song by id and return it. 

        foreach (Music temp in MusicList)
        {
            if (temp.songID == id)
            {
                return temp;
            }
        }
        Debug.Log("Couldn't find item: " + id);
        return null;
    }

}
