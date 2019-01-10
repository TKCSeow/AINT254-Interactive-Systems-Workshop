using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenreManager : MonoBehaviour {

    // Use this for initialization
    public Button[] Genres;
    public Text diff;
    void Start() {
       
        Genres[0].onClick.AddListener(SetClassical);
        Genres[1].onClick.AddListener(SetTest);

    }
	
	// Update is called once per frame
	void Update () {
		if (GameManager.genre == 1)
        {
            diff.text = "Difficulty: Beginner";

        }
        else if (GameManager.genre == 0)
        {
            diff.text = "Difficulty: Pro";
        }
    }

    public void SetClassical()
    {
        ShopScrollList.Instance.genre = 1;
        GameManager.genre = 1;
        ShopScrollList.Instance.RefreshDisplay();
        //diff.text = "Difficulty: Beginner";
    }

    public void SetTest()
    {
        GameManager.genre = 0;
        ShopScrollList.Instance.genre = 0;
        ShopScrollList.Instance.RefreshDisplay();
        //diff.text = "Difficulty: Pro";

    }
}
