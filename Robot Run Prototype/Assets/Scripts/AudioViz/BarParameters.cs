using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarParameters : MonoBehaviour {

    // Use this for initialization
    public int band;
    public float startScale, scaleMultiplier;
    public Image bar;
    bool isUsingBuffer;
	void Start () {
        bar = gameObject.GetComponent<Image>();
        bar.rectTransform.sizeDelta = new Vector2(15, 2);

    }
	
	// Update is called once per frame
	void Update () {
        //bar.rectTransform.sizeDelta = new Vector2(20, (AudioPeer.freqBand[band] * scaleMultiplier) + 10);
        bar.rectTransform.transform.localScale = new Vector3 (transform.localScale.x, (AudioPeer.freqBand[band] * scaleMultiplier) + startScale, transform.localScale.z);
        //bar.transform.localPosition = new Vector3(transform.localPosition.x, bar.transform.localPosition.y * 2, transform.localPosition.z);
        //transform.localScale = new Vector3(transform.localScale.x, (AudioPeer.freqBand[band] * scaleMultiplier) + startScale, transform.localScale.z);
    }
}
