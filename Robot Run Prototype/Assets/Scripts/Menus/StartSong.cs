using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSong : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlaySong()
    {
        //Set song
        TileManager.selectSong = GameManager.selectedSong;
        
        //Game isn't over
        GameManager.isGameOver = false;

        //Load main game screen
        SceneManager.LoadScene("Main");

        //Set genre
        GameManager.genre = ShopScrollList.Instance.genre;
    }

    public void MainMenu()
    {

        SceneManager.LoadScene("StartScreen");
    }
}
