using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusPoint : MonoBehaviour {

    // Use this for initialization
    public GameObject currentInteractableObj = null;
    public int lane;
    public bool isHit = false;
   
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        //print(other.gameObject.name);
        //print(other.gameObject.tag);
        if (other.CompareTag("Player"))
        {
            if (lane == PlayerMovement.desiredLane)
            {
                GameObject.FindGameObjectWithTag("Song").GetComponent<AudioSource>().volume = 1;
                ScoreManager.score += 1;
                ScoreManager.combo++;
                isHit = true;
                ScoreManager.isHit = isHit;
                gameObject.SetActive(false);
            }
        }


    }

    private void OnTriggerExit(Collider other)
    {
        
       

    }

 
}
