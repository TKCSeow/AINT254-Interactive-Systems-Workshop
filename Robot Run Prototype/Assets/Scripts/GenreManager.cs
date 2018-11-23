using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenreManager : MonoBehaviour {

    // Use this for initialization
    public Button[] Genres;
    void Start() {
       
        Genres[0].onClick.AddListener(SetClassical);
        Genres[1].onClick.AddListener(SetTest);

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetClassical()
    {
        ShopScrollList.Instance.genre = 0;
        GameManager.genre = 0;
        ShopScrollList.Instance.RefreshDisplay();
    }

    public void SetTest()
    {
        GameManager.genre = 1;
        ShopScrollList.Instance.genre = 1;
        ShopScrollList.Instance.RefreshDisplay();
    }
}
