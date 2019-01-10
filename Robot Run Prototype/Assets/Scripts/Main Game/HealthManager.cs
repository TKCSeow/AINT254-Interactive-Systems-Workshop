using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {

    // Use this for initialization
    public Image healthBar;
    static public int health = 20;
    float scale;

    private GameObject player; static public bool dead; 
	void Start () {
        health = 20;


    }

    // Update is called once per frame
    void Update () {
        



        //Set colour of bar based on player's health

        if (health <= 6) //if player is on very low health
        {
            healthBar.GetComponent<Image>().color = Color.red;
        }
        else if (health <= 12) //if player on low health
        {
            healthBar.GetComponent<Image>().color = Color.yellow;
        }
        else if (health < 20) //if player is on high health
        {
            healthBar.GetComponent<Image>().color = Color.green;
        }
        else if (health <= 20) //if player is on full health
        {
            healthBar.GetComponent<Image>().color = Color.white;
        }

        //Calculate scale of bar
        scale = ((float)health * 5) / 100;
        
        // Set length/percentage of bar
        healthBar.rectTransform.transform.localScale = new Vector3(scale, transform.localScale.y, transform.localScale.z);

        //End game if no health
        if (health <= 0)
        {
            AudioSource song;
            
            //Get song source
            song = GameObject.FindGameObjectWithTag("Song").GetComponent<AudioSource>();

            //Stop song
            song.Stop();

            //Enable player controls
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().enabled = false;

            //Stop player
            PlayerMovement.speed = 0;

            //level is finished
            GameManager.isGameOver = true;

            //Open end screen
            EndScreen.Instance.endScreen.SetActive(true);
        }
        

        
    }

    private void OnTriggerEnter(Collider other)
    {
      
    }
}
