using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Adapted from Unity Tutorials

public class PlayerMovement : MonoBehaviour {

    private const float LANE_DISTANCE = 1.0f;

    public float speed = 10.0f;
    private CharacterController controller;
    private Vector3 moveVector;
    private float verticalVelocity = 0.0f;
    private float gravity = 20.0f;
    private int desiredLane = 0;
    private float jumpForce = 6.0f;

    private float animationDuration = 3.0f;
    private bool isFirstMove = true;

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
            //ObstacleCollision.dead = false;
            

        }
        else
        {
            PlayerMove();
        }

    }

    private void PlayerMove()
    {
        
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            MoveLane(false);
        }
        if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            MoveLane(true);
        }

        Vector3 targetPosition = transform.position.z * Vector3.forward;
        if (isFirstMove == true)
        {
           
            if (desiredLane == 0)
            {
                targetPosition += Vector3.left * LANE_DISTANCE/2;
            }
            else if (desiredLane == 1)
            {
                targetPosition += Vector3.right * LANE_DISTANCE/2;
            }
            isFirstMove = false;
        }
        else
        {
            
            if (desiredLane == 0)
            {
                targetPosition += Vector3.left * LANE_DISTANCE;
            }
            else if (desiredLane == 1)
            {
                targetPosition += Vector3.right * LANE_DISTANCE;
            }
        }
        //moveVector.x = Input.GetAxisRaw("Horizontal") * (speed / 2);
        moveVector = Vector3.zero;

        moveVector.x = (targetPosition - transform.position).normalized.x * speed;

        // Gravity/Falling
        if (controller.isGrounded)
        {
            verticalVelocity = -0.1f;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                verticalVelocity = jumpForce;
            }
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        moveVector.y = verticalVelocity;

        moveVector.z = speed;

        controller.Move(moveVector * Time.deltaTime);
    }


    private void MoveLane(bool isGoingRight)
    {
        //if (!isGoingRight)
        //{
        //    desiredLane--;
        //}
        //if (!isGoingRight)
        //{
        //    desiredLane++;      
        //}
        desiredLane += (isGoingRight) ? 1 : -1;
        desiredLane = Mathf.Clamp(desiredLane, 0, 1);
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
        if (speed == 40)
        {
            return;
        }
        else
        {
            speed = 5 + modifier;
        }
    }

}
