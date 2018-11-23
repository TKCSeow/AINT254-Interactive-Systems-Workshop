using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Genre {

    public int genreID;
    public string genreName;
    public List<Music> songList;


    public Genre(int id, string name, List<Music> songs)
    {
        genreID = id;
        genreName = name;
        songList = songs;
    }

}
