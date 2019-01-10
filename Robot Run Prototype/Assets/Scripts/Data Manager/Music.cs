using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music {

    public int songID;
    public string songName;
    public string songDescription;
    public int songDifficulty;
    public int songDivisions;
    public float songSpeed;
    public int[] notes;
    public int noteCount;

    public Music(int id, string name, string description, int difficulty, int divisions, float speed, int[] n, int nCount)
    {
        songID = id;
        songName = name;
        songDescription = description;
        songDifficulty = difficulty;
        songDivisions = divisions;
        songSpeed = speed;
        notes = n;
        noteCount = nCount;
    }
}
