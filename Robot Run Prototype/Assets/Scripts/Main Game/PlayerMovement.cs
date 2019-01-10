using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Adapted from Unity Tutorials

public class PlayerMovement : MonoBehaviour {

    private const float LANE_DISTANCE = 2.0f;

    static public float speed = 10.0f;
    private CharacterController controller;
    private Vector3 moveVector;

    public static int desiredLane = 1;

    private float animationDuration = 2.0f;

    private int lanePosition;




    

    //private Animator anim;

    void Start()
    {
        //Get controller
        controller = GetComponent<CharacterController>();

        //Set start lane
        desiredLane = 1;

    }
    void Update()

    {
    
        // move player forward only for set time
        if (Time.time < animationDuration)
        {
            controller.Move(Vector3.forward * speed * Time.deltaTime);

            return;
        }

        //Start player control
        PlayerMove();

    }

    private void PlayerMove()
    {
        
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //Move to Left Lane
            desiredLane = 0;

            //Count the button press for left lane
            GameManager.buttonPress[0]++;
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            //Move to Middle Lane
            desiredLane = 1;

            //Count the button press for middle lane
            GameManager.buttonPress[1]++;
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.L) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            //Move to Right Lane
            desiredLane = 2;

            //Count the button press for right lane
            GameManager.buttonPress[2]++;
        }

        //Set player to move forward
        Vector3 targetPosition = transform.position.z * Vector3.forward;
       
         
        if (desiredLane == 0) //Left Lane
        { 
                targetPosition += Vector3.left * LANE_DISTANCE;  //Set target to left lane
        }
        else if (desiredLane == 2) //Right Lane
        {
            
           targetPosition += Vector3.right * LANE_DISTANCE; //Set target to right lane

        }
        else if (desiredLane == 1) //Middle Lane
        {
            if (lanePosition == 0) //if player is in Left Lane
            {
                targetPosition += Vector3.right * LANE_DISTANCE; //Move right by a lane length
            }
            else if (lanePosition == 2) //if player is in Right Lane
            {
                targetPosition += Vector3.left * (LANE_DISTANCE);//Move left by a lane length
            }
        }


        //lanePosition is set to new lane position
        lanePosition = desiredLane;
        
        //Reset vector
        moveVector = Vector3.zero;

        //Move player on x axis
        moveVector.x = (targetPosition - transform.position).normalized.x * (17 * 2);

        //y axis is not used
        moveVector.y = 0;

        //Set z axis
        moveVector.z = speed;

        //Move player
        controller.Move(moveVector * Time.deltaTime);
    }

   


}
