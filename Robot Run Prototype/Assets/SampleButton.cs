using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SampleButton : MonoBehaviour
{
    //This script is adapted from Unity's tutorial

    public Button buttonComponent;
    public Text nameLabel;


    private Music song;
    private ShopScrollList scrollList;

    // Use this for initialization
    void Start()
    {
        buttonComponent.onClick.AddListener(HandleClick);
    }

    public void Setup(Music currentItem, ShopScrollList currentScrollList)
    {
        //Set item
        song = currentItem;

        //Set item name to Text object
        nameLabel.text = song.songName;

        //Set Scroll List
        scrollList = currentScrollList;

    }

    public void HandleClick()
    {
        //If player is in Shops
        //On click run "buy" code
        
            scrollList.SelectSong(song);
        

    }
}