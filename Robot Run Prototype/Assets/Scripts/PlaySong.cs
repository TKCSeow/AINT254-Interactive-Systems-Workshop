using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySong : MonoBehaviour {

    private AudioSource song;

    private void Start()
    {
        song = GameObject.FindGameObjectWithTag("Song").GetComponent<AudioSource>();
    }
    private void OnTriggerExit(Collider other)
    {

        song.Play();

    }
}
