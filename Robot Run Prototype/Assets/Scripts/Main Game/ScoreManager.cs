using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    // Use this for initialization
    public Text scoreText;
    public Text comboText;
    public Text hitText;

    private GameObject player;

    static public float score = 0.0f;
    static public int combo = 0;

    static public bool isHit = false;
    static public bool isMiss = false;

    public static int currentMaxScore = 0;

    void Start() {

        //Get player
        player = GameObject.FindGameObjectWithTag("Player");

        //Reset score
        score = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {

        if (GameManager.isGameOver == false) //If game hasn't finished yet
        {

            // Count chain of successful hits
            if (combo >= 5)
            {
                comboText.text = "Combo x" + combo;
            }
            else
            {
                comboText.text = "";
            }

            //Update Score UI
            scoreText.text = ((int)score).ToString();
        }
    }

}
