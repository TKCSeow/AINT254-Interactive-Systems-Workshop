using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Adapted from Unity Tutorials

public class PlayerMovement : MonoBehaviour {

    public float speed;
    private Rigidbody rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    void Update()
    {
        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(x, 0.0f, z);

        rigidbody.AddForce(movement * speed);


    }
}
