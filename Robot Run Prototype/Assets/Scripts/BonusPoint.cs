using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusPoint : MonoBehaviour {

    // Use this for initialization
    public GameObject currentInteractableObj = null;
   
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager.score += 10;
        }
        gameObject.SetActive(false);

    }

    private void OnTriggerExit(Collider other)
    {
        
       

    }

 
}
