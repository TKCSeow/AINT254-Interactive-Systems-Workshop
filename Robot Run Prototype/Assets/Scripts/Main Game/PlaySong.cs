using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlaySong : MonoBehaviour {

    private AudioSource song;

    private void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        //Get Song object
        song = GameObject.FindGameObjectWithTag("Song").GetComponent<AudioSource>();

        //Play song
        song.Play();

        //Game has started
        GameManager.isGameOver = false;

        //Song has started
        GameManager.isSongStarted = true;

        //Not used in final build but plays video
        //GameObject.FindGameObjectWithTag("Video").GetComponent<UnityEngine.Video.VideoPlayer>().Play();

    }
}
