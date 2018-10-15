using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    // Use this for initialization
    private GameObject player;

    static public float score = 0.0f;
    public Text scoreText;

    private int difficultyLevel = 1;
    private int maxDifficultyLevel = 10;
    private int scoreToNextLevel = 10;

    private GameObject BonusArea;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        BonusArea = GameObject.FindGameObjectWithTag("Bonus");
    }

    // Update is called once per frame
    void Update() {
        

        if (score >= scoreToNextLevel)
        {
            LevelUp();
        }

        score += Time.deltaTime;
        scoreText.text = ((int)score).ToString();

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
