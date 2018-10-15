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


        if (ObstacleCollision.dead == true)
        {
            //StartCoroutine(PlayerStop());
            ObstacleCollision.dead = false;

        }
        else
        {
            PlayerMove();
        }

    }

    private void PlayerMove()
    {
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
    }

    private IEnumerator PlayerStop()
    {
        controller.Move(Vector3.zero);
        PlayerBounceBack();
        yield return new WaitForSeconds(0.2f);
        controller.Move(Vector3.zero);
        
        ObstacleCollision.dead = false;
    }

    private void PlayerBounceBack()
    {
        moveVector.z = -speed;
        controller.Move(moveVector * Time.deltaTime);
    }


        public void SetSpeed(float modifier)
    {
        speed = 5 + modifier;
    }

}
