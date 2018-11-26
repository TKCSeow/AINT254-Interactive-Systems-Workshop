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
		if (GameManager.isGameOver == true && isfinishedDisplaying == false)
        {
            endScreen.SetActive(true);

            CalculateGrade();

            scoreText.text = "You Scored:\n" + ScoreManager.score + " out of " + TileManager.song.noteCount + " (" + (int)score + "%)";


            CalculateAccuracy();
            isfinishedDisplaying = true;
        }
	}

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void BackToSongSelection()
    {
        SceneManager.LoadScene("SongSelect");
    }

    public void CalculateGrade()
    {
        score = 0;
        print(TileManager.song.noteCount);
        print(ScoreManager.score);
        score = (ScoreManager.score / TileManager.song.noteCount) * 100;
        print(score);
        if (score < 70)
        {
            gradeText1.text = "You achieved a";
            gradeText2.text = "Fail";
            gradeText2.color = Color.red;
        }
        else if (score < 80)
        {
            gradeText1.text = "You achieved a";
            gradeText2.text = "Pass";
            gradeText2.color = Color.white;
        }
        else if (score < 90)
        {
            gradeText1.text = "You achieved a";
            gradeText2.text = "Merit";
            gradeText2.color = Color.green;
        }
        else if (score < 100)
        {
            gradeText1.text = "You achieved a";
            gradeText2.text = "Distinction";
            gradeText2.color = Color.blue;
        }
        else if(score >= 100)
        {
            gradeText1.text = "You achieved a";
            gradeText2.text = "Perfect!";
            gradeText2.color = Color.yellow;
        }
    }


    public void CalculateAccuracy()
    {
        accuracyTotal = 0;
        totalButtonPress = 0;
            foreach (int i in GameManager.buttonPress)
            {
                totalButtonPress += i;
            }



            if (totalButtonPress != 0)
            {
                accuracyTotal = 0;
                if (totalButtonPress >= TileManager.song.noteCount)
                {
                    for (int i = 0; i<accuracyPerLane.Length; i++)
                    {
                        accuracyPerLane[i] = (float) GameManager.tileCount[i] / GameManager.buttonPress[i];      
                    }
                    for (int i = 0; i<accuracyPerLane.Length; i++)
                    {
                        accuracyTotal += accuracyPerLane[i];
                    }
                    
                    accuracyTotal = (accuracyTotal / accuracyPerLane.Length) * 100;   
                }
                else if (totalButtonPress<TileManager.song.noteCount)
                {
                    for (int i = 0; i<accuracyPerLane.Length; i++)
                        {
                        accuracyPerLane[i] = GameManager.buttonPress[i] / (float) GameManager.tileCount[i];
                    }
                    for (int i = 0; i<accuracyPerLane.Length; i++)
                        {
                        accuracyTotal += accuracyPerLane[i];
                    }
                    accuracyTotal = (accuracyTotal / accuracyPerLane.Length) * 100;      
                }
                

                if (accuracyTotal > 100)
                    accuracyTotal = 100;

                if (ScoreManager.score < TileManager.song.noteCount)
                {
                    accuracyTotal = accuracyTotal * (score / 100);
                }
            }
            else
            {
                accuracyTotal = 0;
            }

            

            print(accuracyTotal);
            accuracyTotal = (Mathf.Floor((accuracyTotal* 100))) / 100;
            print(accuracyTotal);
            accuracyText.text = "Your Accurracy:\n" + accuracyTotal + "%";
    }
}
