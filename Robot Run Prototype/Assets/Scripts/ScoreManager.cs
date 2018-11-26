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


    private int difficultyLevel = 1;
    private int maxDifficultyLevel = 10;
    private int scoreToNextLevel = 100;

    

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        score = 0.0f;
        hitText.text = "";
    }

    // Update is called once per frame
    void Update()
    {

        if (GameManager.isGameOver == false)
        {
            StartCoroutine(HitText());

            
            if (combo > 5)
            {
                comboText.text = "Combo x" + combo;
            }
            else
            {
                comboText.text = "";
            }

            


            scoreText.text = ((int)score).ToString();
        }
        //noteText.text = ((int)score / 10).ToString() + "/" + TileManager.song.noteCount.ToString();
    }
        
    IEnumerator HitText()
    {
        if (isHit == false)
        {
            combo = 0;
            hitText.text = "Miss";
            hitText.color = Color.red;
            yield return new WaitForSeconds(1f);
            hitText.text = "";
        }

        else if (isHit == true)
        {
            hitText.text = "Hit";
            hitText.color = Color.green;
            yield return new WaitForSeconds(1f);
            hitText.text = "";
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
