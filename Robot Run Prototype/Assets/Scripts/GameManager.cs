using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	
    public void OpenSong()
    {
        SceneManager.LoadScene("Main");
    }
}
