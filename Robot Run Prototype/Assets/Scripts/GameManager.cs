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
    public static int genre = 0;
    static public bool isGameOver = false;
    static public int cameraType = 0;

    public static int[] buttonPress = new int[3] { 0, 0, 0 };
    public static int[] tileCount = new int[3] { 0, 0, 0 };

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

    public static void OpenSong(int i)
    {
        print(selectedSong);
        print(genre);
        genre = ShopScrollList.Instance.genre;
        TileManager.selectSong = selectedSong;
        print(TileManager.selectSong);
        isGameOver = false;
        SceneManager.LoadScene("Main");

    }

    public static void SelectSong(int i)
    {
        selectedSong = i;
        print(selectedSong);
    }

    private IEnumerator LoadStart()
    {

       
        StartCoroutine(GameObject.FindGameObjectWithTag("ScreenFader").GetComponent<ScreenFader>().FadeToClear());
        yield return new WaitForSeconds(2f);
        StartCoroutine(GameObject.FindGameObjectWithTag("ScreenFader").GetComponent<ScreenFader>().FadeToBlack());
        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene("StartScreen");

    }

}
