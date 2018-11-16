using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music {

    public int songID;
    public string songName;
    public int[] notes;

    public Music(int id, string name, int[] n)
    {
        songID = id;
        songName = name;
        notes = n;
    }
}
