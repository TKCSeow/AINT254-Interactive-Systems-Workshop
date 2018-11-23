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
        TileManager.selectSong = GameManager.selectedSong;
        GameManager.isGameOver = false;
        SceneManager.LoadScene("Main");
        GameManager.genre = ShopScrollList.Instance.genre;
    }

    public void MainMenu()
    {

        SceneManager.LoadScene("StartScreen");
    }
}
