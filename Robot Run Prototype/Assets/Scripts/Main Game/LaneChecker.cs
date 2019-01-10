using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneChecker : MonoBehaviour {

    // Use this for initialization
    public GameObject note;
    public GameObject hit;
    public GameObject miss;
   

    void OnTriggerEnter(Collider other)
    {
        //Keep tracks of the current maximum score the player could have
        ScoreManager.currentMaxScore++;
    }


    void OnTriggerExit(Collider other)
    {
        if (note.GetComponent<BonusPoint>().isHit == false) //if player misses note
        {
            //Reduce Health
            HealthManager.health -= 4;
            if (HealthManager.health < 0)
            {
                HealthManager.health = 0;
            }
            //Lower volume
            GameObject.FindGameObjectWithTag("Song").GetComponent<AudioSource>().volume = 0.3f;

            //Reset combo
            ScoreManager.combo = 0;

            //Set bools
            ScoreManager.isMiss = true;
            ScoreManager.isHit = false; 
            note.SetActive(false);
            hit.SetActive(false);          
        }
        else
        {
            ScoreManager.isMiss = false;
        }

    }

 
}
