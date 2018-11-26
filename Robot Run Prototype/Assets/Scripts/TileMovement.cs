using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMovement : MonoBehaviour {

    // Use this for initialization
    GameObject track;
    float speed = 19.5f;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.Translate(Vector3.back * speed * Time.deltaTime);
        
		
	}
}
