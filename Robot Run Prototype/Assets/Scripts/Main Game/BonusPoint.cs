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
        //when player touches/enters note

        if (other.CompareTag("Player")) //validate object
        {
            if (lane == PlayerMovement.desiredLane) // only compare with desiredLane
            {
                //Add Health
                if (HealthManager.health < 20)
                {
                    HealthManager.health += 1;
                }

                //Set song to normal volume
                GameObject.FindGameObjectWithTag("Song").GetComponent<AudioSource>().volume = 1;

                // +1 to score on enter
                ScoreManager.score += 1;

                // +1 to combo on enter
                ScoreManager.combo++;

                //set bool
                isHit = true;
                ScoreManager.isHit = isHit;

                //Disable object
                gameObject.SetActive(false);
            }
        }
    }


 
}
