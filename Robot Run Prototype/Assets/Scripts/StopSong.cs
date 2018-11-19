using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopSong: MonoBehaviour {

    private AudioSource song;

    private void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        song = GameObject.FindGameObjectWithTag("Song").GetComponent<AudioSource>();
        song.Stop();

        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().enabled = false;
        PlayerMovement.speed = 0;
    }
}
