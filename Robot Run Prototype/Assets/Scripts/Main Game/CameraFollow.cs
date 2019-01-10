using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    // Use this for initialization
    private Transform lookAt;
    private Vector3 startOffset;
    private Vector3 moveVector;


	void Start () {
        //Get position of player
        lookAt = GameObject.FindGameObjectWithTag("Player").transform;

        //Calculate offset of camera position and player
        startOffset = transform.position - lookAt.position;
	}
	
	// Update is called once per frame
	void Update () {

        // Player position + offset
        moveVector = lookAt.position + startOffset;

        //x axis not used
        moveVector.x = 0;

        //Set position of camera
        transform.position = moveVector;

    }
}
