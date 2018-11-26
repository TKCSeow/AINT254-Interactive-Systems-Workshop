using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour {

    // Use this for initialization
    float progress = 0.01f;
    float passLine;
    int totalNotes;
    float scale;
    public Image progressBar;
    float startPosition;

	void Start () {
        totalNotes = TileManager.song.noteCount;
        print(TileManager.song.noteCount);
        passLine = totalNotes * 0.7f;
        startPosition = transform.localScale.y;
    }
	
	// Update is called once per frame
	void Update () {
        //print(TileManager.song.noteCount);
        int time = (int)Time.deltaTime;
        passLine = time * 0.7f;
        print(passLine);
        progress =  (ScoreManager.score / (float)TileManager.song.noteCount);
        if (float.IsNaN(progress) == true || progress == 0)
            progress = 0.01f;

        scale = progressBar.rectTransform.transform.localScale.y * progress;

        //print(progress);
        progressBar.rectTransform.transform.localScale = new Vector3(transform.localScale.x, progress, transform.localScale.z);

        float offset;
        offset = startPosition - (progressBar.rectTransform.sizeDelta.y / 2) * (1 - transform.localScale.y);

        progressBar.rectTransform.transform.localPosition = new Vector3(transform.localPosition.x, offset, transform.localPosition.z);

        if (progress * 100 < passLine)
        {
            progressBar.GetComponent<Image>().color = Color.red;
        }
        else
        {
            progressBar.GetComponent<Image>().color = Color.green;

        }

    }
}
