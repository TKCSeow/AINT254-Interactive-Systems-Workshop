using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This script is adapted from Unity's tutorial
//This script is recycled from a previous project of mine

public class ShopScrollList : MonoBehaviour
{
    public static ShopScrollList Instance { get; set; }

    public Transform contentPanel;
    //public Text shopNameDisplay;
    public SimpleObjectPool buttonObjectPool;


    public int genre = 1;


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
    }
    void Start()
    {
        genre = GameManager.genre;
        RefreshDisplay();
    }

    public void RefreshDisplay()
    {
        //Reset Buttons
        RemoveButtons();
        AddButtons(MusicDatabase.Instance.GetSongCount(genre));
    }


    public void RemoveButtons()
    {
        //Removes the first/top button until there is none left
        while (contentPanel.childCount > 0)
        {
            GameObject toRemove = transform.GetChild(0).gameObject;
            buttonObjectPool.ReturnObject(toRemove);
        }
    }

    public void AddButtons(int num)
    {


        //For No. of Songs
        for (int i = 0; i <= num - 1; i++) //For No. of Songs
        {
            print(genre);
            //Get Songs from Database using id 
            Music temp = MusicDatabase.Instance.GetSong(i,genre);

            //Create button Object
            GameObject newButton = buttonObjectPool.GetObject();
            newButton.transform.SetParent(contentPanel);

            //Set Button properties and info
            SampleButton sampleButton = newButton.GetComponent<SampleButton>();
            sampleButton.Setup(temp, this);

        }
    }

    public void SelectSong(Music song)
    {
        //Set selected song
        GameManager.SelectSong(song.songID);
    }

}
       
        
    


    