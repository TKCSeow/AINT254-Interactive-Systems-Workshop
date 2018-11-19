using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    // Use this for initialization
    private Transform lookAt;
    private Vector3 startOffset;
    private Vector3 moveVector;


	void Start () {
        lookAt = GameObject.FindGameObjectWithTag("Player").transform;
        startOffset = transform.position - lookAt.position;
	}
	
	// Update is called once per frame
	void Update () {
        moveVector = lookAt.position + startOffset;

        //moveVector.x = lookAt.position.x;
        moveVector.x = 0;

        
        transform.position = moveVector;
        //if (transition > 1.0f)
        //{
        //    transform.position = moveVector;
        //}
        //else
        //{
        //    transform.position = Vector3.Lerp(moveVector + animationOffset, moveVector, transition);
        //    transition += Time.deltaTime * 1 / animationDuration;
        //    transform.LookAt(lookAt.position + Vector3.up);
        //}
    }
}
