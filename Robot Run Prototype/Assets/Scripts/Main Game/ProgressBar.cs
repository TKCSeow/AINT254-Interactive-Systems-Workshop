using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour {

    // Use this for initialization
    float progress = 0f;
    float passLine;

    public Image progressBar;
    float startPosition;

	void Start () {
        //Reset progress
        progress = 0f;

        //Get y position of GameObject
        startPosition = transform.localScale.y;
    }
	
	// Update is called once per frame
	void Update () {

        float offset;

        //Reset values on game over
        if (GameManager.isGameOver == true)
        {
            progress = 0f;
            passLine = 0f;
        }

        //Pass Line is 70% of the current maximum score the play could get
        passLine = ScoreManager.currentMaxScore * 0.7f;
        
        progress =  (ScoreManager.score / (float)TileManager.song.noteCount); // Player's score / total note count of song

        //failsafe / error catcher
        if (float.IsNaN(progress) == true || progress == 0)
            progress = 0.01f;


        // Set length/percentage of bar
        progressBar.rectTransform.transform.localScale = new Vector3(transform.localScale.x, progress, transform.localScale.z);

        //Calculate offset
        offset = startPosition - (progressBar.rectTransform.sizeDelta.y / 2) * (1 - transform.localScale.y);

        //offset bar
        progressBar.rectTransform.transform.localPosition = new Vector3(transform.localPosition.x, offset, transform.localPosition.z);

        //print(passLine);
        //print(progress * 100);

        //Set colour of bar based on player performance
        if (passLine > 0)
        { 
            if (ScoreManager.score < passLine) //if player is on track to fail
            {
                progressBar.GetComponent<Image>().color = Color.red;
            }
            else if (ScoreManager.score == TileManager.song.noteCount * 1) //if player is achieving a perfect
            {
                progressBar.GetComponent<Image>().color = Color.yellow;
            }
            else if (ScoreManager.score > TileManager.song.noteCount * 0.9) //if player is achieving a Distinction
            {
                progressBar.GetComponent<Image>().color = Color.cyan;
            }
            else if (ScoreManager.score > TileManager.song.noteCount * 0.8) //if player is achieving a Merit
            {
                progressBar.GetComponent<Image>().color = Color.green;
            }
            
            
            else if (ScoreManager.score >= passLine) //if player is achieving a pass
            {
                progressBar.GetComponent<Image>().color = Color.blue;
            }

        }
        else
        {
            progressBar.GetComponent<Image>().color = Color.white;

        }

    }
}
