using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateAudioBars : MonoBehaviour {

    // Use this for initialization
    public GameObject barPrefab;
    GameObject[] sampleBar = new GameObject[AudioPeer.freqBand.Length];
    public float maxScale;
    RectTransform canvasRect;
    public bool isBackwards = false;
	void Start () {
        float offset;
        if (isBackwards == false)
        {
            offset = 16f;
        }
        else
        {
            offset = -16f;
        }

        canvasRect = gameObject.GetComponent<RectTransform>();
        float panelWidth = canvasRect.rect.width * canvasRect.localScale.x;
        print(panelWidth);
        float panelHeight = canvasRect.rect.height * canvasRect.localScale.y;
        print(panelHeight);
        for (int i = 0; i < sampleBar.Length; i++)
        {
            GameObject instanceSampleBar = Instantiate(barPrefab);
            instanceSampleBar.transform.parent = this.transform.parent;
            instanceSampleBar.transform.localPosition = this.transform.localPosition;
            instanceSampleBar.transform.localPosition = new Vector3(gameObject.transform.localPosition.x + (offset * i), gameObject.transform.localPosition.y, 0);
            instanceSampleBar.transform.localRotation = new Quaternion(0,0,0,0);
            instanceSampleBar.transform.localScale = new Vector3(1, 1, 1);

            instanceSampleBar.name = "SampleBar" + i;
            instanceSampleBar.GetComponent<BarParameters>().band = i;

            //this.transform.eulerAngles = new Vector3(0, -03125f * 1, 0);
            //instanceSampleBar.transform.position = Vector3.forward * 100;
            sampleBar[i] = instanceSampleBar;
        }
	}
	
	// Update is called once per frame
	void Update () {


		for (int i = 0; i < sampleBar.Length; i++)
        {
            if(sampleBar != null)
            {
                //sampleBar[i].GetComponent<BarParameters>().band = ;
                //sampleBar[i].transform.localScale = new Vector3(transform.localScale.x, (AudioPeer.freqBand[i+1] * 5) + 1, transform.localScale.z);

                //sampleBar[i].transform.localScale = new Vector3(10, (AudioPeer.samples[i] * maxScale) + 2, 10);
            }
        }

    }
}
