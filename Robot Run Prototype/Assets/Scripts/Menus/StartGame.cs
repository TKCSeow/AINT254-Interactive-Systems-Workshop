using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

    // Use this for initialization
    public GameObject ControlScreen;
	void Start () {
        ControlScreen.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OpenControls()
    {
        ControlScreen.SetActive(true);
    }

    public void CloseControls()
    {
        ControlScreen.SetActive(false);
    }

    public void LoadSelectMenu()
    {
        GameObject.FindGameObjectWithTag("StartButton").GetComponent<Button>().interactable = false;
        StartCoroutine(LoadFade());
    }

    private IEnumerator LoadFade()
    {
        GameObject.FindGameObjectWithTag("StartSound").GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(GameObject.FindGameObjectWithTag("ScreenFader").GetComponent<ScreenFader>().FadeToBlack());
        yield return new WaitForSeconds(2.5f);

        SceneManager.LoadScene("SongSelect");

    }

    public void EndGame()
    {
        Application.Quit();
    }

}

