using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneChecker : MonoBehaviour {

    // Use this for initialization
    public GameObject note;
    public GameObject hit;
    public GameObject miss;
   
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        //if (GameManager.isSongStarted == true)
        //{
        //    player.GetComponent<CharacterController>().detectCollisions = false;
        //}
    


     

    }

    void OnTriggerEnter(Collider other)
    {
 
    }


    void OnTriggerExit(Collider other)
    {
        if (note.GetComponent<BonusPoint>().isHit == false)
        {
            GameObject.FindGameObjectWithTag("Song").GetComponent<AudioSource>().volume = 0.3f;
            ScoreManager.isMiss = true;
            ScoreManager.isHit = false; ;
            note.SetActive(false);
            hit.SetActive(false);          
        }
        else
        {
            ScoreManager.isMiss = false;

        }

    }

 
}
