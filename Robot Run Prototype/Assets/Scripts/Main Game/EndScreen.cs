using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour {

    // Use this for initialization
    public GameObject endScreen;
    public Text gradeText1;
    public Text gradeText2;
    public Text scoreText;
    public Text accuracyText;
    private bool isfinishedDisplaying = false;

    private int totalButtonPress = 0;
    private float[] accuracyPerLane = new float[3];
    private float accuracyTotal = 0;
    public static EndScreen Instance { get; set; }
    private float score = 0;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        endScreen.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {

		if (GameManager.isGameOver == true && isfinishedDisplaying == false) //if game is over and end screen isn't displaying
        {
            //activate end screen
            endScreen.SetActive(true);

            CalculateGrade();

            //Set score text
            scoreText.text = "You Scored:\n" + ScoreManager.score + " out of " + TileManager.song.noteCount + " (" + (int)score + "%)";

            CalculateAccuracy();

            //Finished displaying
            isfinishedDisplaying = true;
        }

        //Reset values
        ScoreManager.score = 0.0f;
        ScoreManager.currentMaxScore = 0;
        ScoreManager.combo = 0;
    }

    public void PlayAgain()
    {
        //Reload same scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void BackToSongSelection()
    {
        //Load Song Select Screen
        SceneManager.LoadScene("SongSelect");
    }

    public void CalculateGrade()
    {
        //Reset value
        score = 0;

        print(TileManager.song.noteCount);
        print(ScoreManager.score);

        //Calculate percentage of player performance
        score = (ScoreManager.score / TileManager.song.noteCount) * 100;
        print(score);

        //Display results based on player performance
        if (score < 70) //Achieved less then 70%
        {
            gradeText1.text = "You achieved a";
            gradeText2.text = "Fail";
            gradeText2.color = Color.red;
        }
        else if (score < 80) //Achieved less then 80%
        {
            gradeText1.text = "You achieved a";
            gradeText2.text = "Pass";
            gradeText2.color = Color.white;
        }
        else if (score < 90) //Achieved less then 90%
        {
            gradeText1.text = "You achieved a";
            gradeText2.text = "Merit";
            gradeText2.color = Color.green;
        }
        else if (score < 100) //Achieved less then 100%
        {
            gradeText1.text = "You achieved a";
            gradeText2.text = "Distinction";
            gradeText2.color = Color.blue;
        }
        else if(score >= 100) //Achieved 100%
        {
            gradeText1.text = "You achieved a";
            gradeText2.text = "Perfect!";
            gradeText2.color = Color.yellow;
        }
    }


    public void CalculateAccuracy()
    {
        //Reset Values
        accuracyTotal = 0;
        totalButtonPress = 0;

        //count total button presses by player
        foreach (int i in GameManager.buttonPress)
        {
            totalButtonPress += i;
        }

        
        if (totalButtonPress != 0)
        {
            //Reset value
            accuracyTotal = 0;

           
            if (totalButtonPress >= TileManager.song.noteCount) //if total button presses by player is equal or greater than total note count
            {
                //Calculate accuracy on a per lane basis
                for (int i = 0; i < accuracyPerLane.Length; i++)
                {
                     accuracyPerLane[i] = (float) GameManager.tileCount[i] / GameManager.buttonPress[i]; //total note count in 'i' lane / total button presses in 'i' Lane
                }

                //Add together the lane accuracy
                for (int i = 0; i < accuracyPerLane.Length; i++)
                {
                    accuracyTotal += accuracyPerLane[i];
                }

                //Calculate Average of lane accuracy
                accuracyTotal = (accuracyTotal / accuracyPerLane.Length) * 100;   
            }

            else if (totalButtonPress < TileManager.song.noteCount) //if total button presses by player is less than total note count
            {
                //Calculate accuracy on a per lane basis
                for (int i = 0; i < accuracyPerLane.Length; i++)
                {
                    accuracyPerLane[i] = GameManager.buttonPress[i] / (float) GameManager.tileCount[i]; //total button presses in 'i' Lane / total note count in 'i' lane
                }

                // Add together the lane accuracy
                for (int i = 0; i < accuracyPerLane.Length; i++)
                {
                    accuracyTotal += accuracyPerLane[i];
                }

                //Calculate Average of lane accuracy
                accuracyTotal = (accuracyTotal / accuracyPerLane.Length) * 100;      
            }
                
            //if accuracy is greater then 100, set to 100
            if (accuracyTotal > 100)
                 accuracyTotal = 100;

            //Limit maximum accuracy
            if (ScoreManager.score < TileManager.song.noteCount) //if score is less than total note count
            {
                accuracyTotal = accuracyTotal * (score / 100);
            }
        }
        else
        {
            accuracyTotal = 0;
        }

        print(accuracyTotal);

        // round and format value
        accuracyTotal = (Mathf.Floor((accuracyTotal* 100))) / 100; 
        print(accuracyTotal);

        //Set text
        accuracyText.text = "Your Accurracy:\n" + accuracyTotal + "%"; 
    }
}
