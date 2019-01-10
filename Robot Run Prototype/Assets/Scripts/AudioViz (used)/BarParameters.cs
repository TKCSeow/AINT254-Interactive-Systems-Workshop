using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarParameters : MonoBehaviour {


    //Not used in final build
    //Used for audio visualisation


    // Use this for initialization
    public int band;
    public float startScale, scaleMultiplier;
    public Image bar;
    bool isUsingBuffer;
    float canvasWidth = 799;
    public static float  barWidth;
    float barSpacing = 1;
	void Start () {

        barWidth = (canvasWidth - 62) / 64;
        bar = gameObject.GetComponent<Image>();
        bar.rectTransform.sizeDelta = new Vector2(barWidth, 2);

    }
	
	// Update is called once per frame
	void Update () {
        //bar.rectTransform.sizeDelta = new Vector2(20, (AudioPeer.freqBand[band] * scaleMultiplier) + 10);
        bar.rectTransform.transform.localScale = new Vector3 (transform.localScale.x, (AudioPeer.freqBand[band] * scaleMultiplier) + startScale, transform.localScale.z);
        //bar.transform.localPosition = new Vector3(transform.localPosition.x, bar.transform.localPosition.y * 2, transform.localPosition.z);
        //transform.localScale = new Vector3(transform.localScale.x, (AudioPeer.freqBand[band] * scaleMultiplier) + startScale, transform.localScale.z);
    }
}
