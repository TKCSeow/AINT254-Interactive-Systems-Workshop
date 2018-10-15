using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour {

    // Use this for initialization
    private GameObject player;
    static public bool dead; 
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        dead = false;
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Hit");
            Debug.Log("Game Over");

            dead = true;

        }
    }
}
