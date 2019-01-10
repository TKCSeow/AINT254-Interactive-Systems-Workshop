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
        //Get song source
        song = GameObject.FindGameObjectWithTag("Song").GetComponent<AudioSource>();

        //Stop song
        song.Stop();

        //Enable player controls
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().enabled = false;

        //Stop player
        PlayerMovement.speed = 0;

        //level is finished
        GameManager.isGameOver = true;

        //Open end screen
        EndScreen.Instance.endScreen.SetActive(true);
    }
}
