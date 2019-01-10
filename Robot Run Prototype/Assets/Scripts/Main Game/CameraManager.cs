using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

    // Use this for initialization
    public GameObject[] camera;
    private static int selectedCamera = 2;
    void Start () {

        //Get Selected Camera Type
        selectedCamera = GameManager.cameraType;

        //Disable all cameras
		foreach (GameObject i in camera)
        {
            i.SetActive(false);
        }

        //Active selected camera
        camera[selectedCamera].SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
