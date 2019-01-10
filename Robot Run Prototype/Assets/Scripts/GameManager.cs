using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    // Use this for initialization
    public static GameManager instance = null;

    public static int selectedSong;
    public static int genre = 1;

    static public bool isGameOver = false;
    static public bool isSongStarted = false;

    static public int cameraType = 1;

    public static int[] buttonPress = new int[3] { 0, 0, 0 }; //Counts how many button presses player makes for each lane
    public static int[] tileCount = new int[3] { 0, 0, 0 }; //Counts how many tiles are in each lane

    void Awake()
    {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        StartCoroutine(LoadStart());
    }

    void Update()
    {
        //Go back to song select screen when Esc is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("SongSelect");
            GameObject.FindGameObjectWithTag("Song").GetComponent<AudioSource>().Stop();

            //Reset values
            ScoreManager.score = 0.0f;
            ScoreManager.currentMaxScore = 0;
            ScoreManager.combo = 0;
        }
    }

    public static void OpenSong(int i)
    {
        print(selectedSong);
        print(genre);

        //Get genre
        genre = ShopScrollList.Instance.genre;

        //Get Song
        TileManager.selectSong = selectedSong;
        print(TileManager.selectSong);

        //Set to not in play
        isGameOver = false;

        //Load main game scene
        SceneManager.LoadScene("Main");

    }

    public static void SelectSong(int i)
    {
        //Get Selected Song
        selectedSong = i;
        print(selectedSong);
    }

    private IEnumerator LoadStart()
    {

       //Fade to clear
        StartCoroutine(GameObject.FindGameObjectWithTag("ScreenFader").GetComponent<ScreenFader>().FadeToClear());
        yield return new WaitForSeconds(2f);

        //Fade to Black
        StartCoroutine(GameObject.FindGameObjectWithTag("ScreenFader").GetComponent<ScreenFader>().FadeToBlack());
        yield return new WaitForSeconds(2f);

        //Load Start Screen
        SceneManager.LoadScene("StartScreen");

    }

}
