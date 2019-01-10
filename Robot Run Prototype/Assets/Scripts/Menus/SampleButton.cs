using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SampleButton : MonoBehaviour
{
    //This script is adapted from Unity's tutorial
    //This is adapted from a previous project of mine

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
        //Set song
        song = currentItem;

        //Set song name to Text object
        nameLabel.text = song.songName;

        //Set Scroll List
        scrollList = currentScrollList;

    }

    public void HandleClick()
    {
        
        scrollList.SelectSong(song);    

    }
}