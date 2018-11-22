using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    // Use this for initialization
    public Text scoreText;

    private GameObject player;

    static public float score = 0.0f;
    
    

    private int difficultyLevel = 1;
    private int maxDifficultyLevel = 10;
    private int scoreToNextLevel = 100;

    

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        score = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {

        if (GameManager.isGameOver == false)
        {

            scoreText.text = ((int)score).ToString();

            //noteText.text = ((int)score / 10).ToString() + "/" + TileManager.song.noteCount.ToString();

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
