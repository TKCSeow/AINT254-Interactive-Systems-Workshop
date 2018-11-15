using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    // Use this for initialization
    private GameObject player;

    static public float score = 0.0f;
    static public bool isGameOver = false;
    public Text scoreText;

    private int difficultyLevel = 1;
    private int maxDifficultyLevel = 10;
    private int scoreToNextLevel = 100;

    

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update() {

        if (isGameOver == false)
        {
            if (score >= scoreToNextLevel)
            {
                LevelUp();
            }

            score += (Time.deltaTime * 10);
            scoreText.text = ((int)score).ToString();
        }

    }

     private void LevelUp()
    {
        if (difficultyLevel == maxDifficultyLevel)
        {
            return;
        }

        scoreToNextLevel *= 2;
        difficultyLevel++;
       

        player.GetComponent<PlayerMovement>().SetSpeed(difficultyLevel * 5);
    }


}
