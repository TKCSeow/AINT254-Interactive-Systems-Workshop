using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Adapted from Unity Tutorials

public class PlayerMovement : MonoBehaviour {

    public float speed = 10.0f;
    private CharacterController controller;
    private Vector3 moveVector;
    private float verticalVelocity = 0.0f;
    private float gravity = 12.0f;

    private float animationDuration = 3.0f;

    //private Animator anim;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        //anim = GetComponent<Animator>();
    }
    void Update()
    {
        // During Opening Animation
        if(Time.time < animationDuration)
        {
            controller.Move(Vector3.forward * speed * Time.deltaTime);

            return;
        }

        moveVector = Vector3.zero;

        moveVector.x = Input.GetAxisRaw("Horizontal") * (speed / 2);

        // Gravity/Falling
        if (controller.isGrounded)
        {
            verticalVelocity = -0.1f;
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        moveVector.y = verticalVelocity;

        moveVector.z = speed;

        controller.Move(moveVector * Time.deltaTime);
        //anim.Play("Locomotion");

    }

    public void SetSpeed(float modifier)
    {
        speed = 5 + modifier;
    }

}
