using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This script is adapted from Unity's tutorial

public class ShopScrollList : MonoBehaviour
{
    public static ShopScrollList Instance { get; set; }

    public Transform contentPanel;
    public Text shopNameDisplay;
    public SimpleObjectPool buttonObjectPool;


    //These are changed from PhoneInteraction and KitchenInteraction scripts
    public string shopCategory;
    public int itemNum;
    public int genre = 0;

    char Yen = '\u00A5';


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
        RefreshDisplay();
    }

    public void RefreshDisplay()
    {
        //Update Money
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
        //Update Header


        //set category


        //Set No. of Items


        //For No. of Items
        for (int i = 0; i <= num - 1; i++) //For No. of Items
        {
       
            //Get Item from Database using id e.g. V1
            Music temp = MusicDatabase.Instance.GetSong(i,genre);
            print(temp.songName);
            //If Kitchen is Open and item is not bought yet


            //Create button Object
            GameObject newButton = buttonObjectPool.GetObject();
            newButton.transform.SetParent(contentPanel);

            //Set Button properties and info
            SampleButton sampleButton = newButton.GetComponent<SampleButton>();
            sampleButton.Setup(temp, this);

        }
    }

    public void ChangeShopName(string category)
    {
        //Change header based on category

        //If Phone is open
        
        
    }

    public void SelectSong(Music song)
    {
        GameManager.SelectSong(song.songID);
    }

}
       
        
    


    