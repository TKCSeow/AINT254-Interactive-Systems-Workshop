using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

    // Use this for initialization
    public GameObject[] camera;
    private static int selectedCamera = 2;
    void Start () {

        selectedCamera = GameManager.cameraType;
		foreach (GameObject i in camera)
        {
            i.SetActive(false);
        }

        camera[selectedCamera].SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
