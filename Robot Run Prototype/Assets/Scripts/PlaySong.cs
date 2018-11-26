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
        song = GameObject.FindGameObjectWithTag("Song").GetComponent<AudioSource>();
        song.Play();
        GameManager.isGameOver = false;
        GameManager.isSongStarted = true;
        GameObject.FindGameObjectWithTag("Video").GetComponent<UnityEngine.Video.VideoPlayer>().Play();

        //GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>().detectCollisions = false;


    }
}
