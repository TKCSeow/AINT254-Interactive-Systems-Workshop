﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicDatabase: MonoBehaviour {

    public static MusicDatabase Instance { get; set; }
    private List<Genre> MusicList { get; set; }
    private List<Music> SongList { get; set; }
    public TextAsset[] MusicFile;

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
        BuildDatabase();
    }

    private void BuildDatabase()
    {
        MusicList = new List<Genre>();
        string genreName;
        Genre tempGenre;

        for (int i = 0; i < MusicFile.Length; i++) //for how many songs
        {
            string text;
            string[] splitText;
            string[] splitText2;
            string description;
            float speed = 0;
            int songDivisions = 0;
            int difficulty = 0;

            //Create temp Music
            Music temp;

            //Create a list of Music objects
            SongList = new List<Music>();

            //Set text from external text file (.txt)
            text = MusicFile[i].text;
            genreName = MusicFile[i].name;
            //Get rid of all return carriage/new line 
            text = text.Replace("\r", "").Replace("\n", "").Replace("[", "").Replace("]", "");

            //Split text by ";", which separates the songs
            splitText = text.Split(';');
            Debug.Log(text);

            for (int j = 0; j < splitText.Length - 1; j++) //for how many songs
            {
                int noteCount = 0;


                //Split text by "/", which separates the song's name. Index 0 contains song's name
                splitText2 = splitText[j].Split(',');

                //Create new string array with splitText2's length but minus one beacuse the last index will be empty 
                string[] notes = new string[splitText2.Length - 5];

                for (int k = 0; k < notes.Length; k++)
                {
                    notes[k] = splitText2[k + 5];

                }

                //notes = notes[1].Split(',');

                int[] note = Array.ConvertAll<string, int>(notes, int.Parse);

                difficulty = int.Parse(splitText2[2]);
                description = splitText2[1];
                speed = float.Parse(splitText2[4]);
                songDivisions = int.Parse(splitText2[3]);


                foreach (int k in note)
                {
                    if (k != 0 && k != 10)
                        noteCount++;
                }

                //Create new Music object with data i.e. Music(id, name, notes)
                temp = new Music(j, splitText2[0], description, difficulty, songDivisions, speed, note, noteCount);
                //print(temp.songName);
                //Add temp to list
                SongList.Add(temp);

            }

            tempGenre = new Genre(i, genreName, SongList);

            MusicList.Add(tempGenre);
        }


    }

    public Music GetSong(int id, int genre)
    {
        //Debug.Log(id);
        //Debug.Log(genre);
        //Genre tempGenre;
        Music temp;
        foreach (Genre tempGenre in MusicList)
        {
            //Debug.Log(tempGenre.genreName);
            if (tempGenre.genreID == genre)
            {
                //Debug.Log(tempGenre.genreID);
                for (int i = 0; i < tempGenre.songList.Count; i++)
                {
                    //Debug.Log(tempGenre.songList[i].songName);
                    if (tempGenre.songList[i].songID == id)
                        {
                            temp = tempGenre.songList[i];
                        //Debug.Log(temp.songName);
                        return temp;
                        
                    }
                }
            }

        }
        

        //Search for song by id and return it.
        Debug.Log("Couldn't find item: " + id);
        return null;
    }

    public int GetSongCount(int genre)
    {
        // 

        int n = 0;
        foreach (Genre tempGenre in MusicList)
        {
            if (tempGenre.genreID == genre)
            {

                return n = tempGenre.songList.Count;
                //for (int i = 0; i < tempGenre.songList.Count; i++)
                //{
                //    if (tempGenre.genreID == genre)
                //    {
                //        foreach (Music temp in tempGenre.songList)
                //        {
                //            n++;
                //        }
                //    }
                //}
            }
        }
        
        return n;
    }

}
