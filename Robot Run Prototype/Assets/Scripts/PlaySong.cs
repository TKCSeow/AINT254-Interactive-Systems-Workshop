using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySong : MonoBehaviour {

    private AudioSource song;

    private void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        song = GameObject.FindGameObjectWithTag("Song").GetComponent<AudioSource>();
        song.Play();
        GameManager.isGameOver = false;

    }
}
