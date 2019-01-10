using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraSelector : MonoBehaviour {

    // Use this for initialization
    public Button[] cameraTypes;
    public Text cameraText;

    void Start()
    {
        
        cameraTypes[0].onClick.AddListener(SetNormalCam);
        cameraTypes[1].onClick.AddListener(SetFarCam);
        cameraTypes[2].onClick.AddListener(Set2DCam);
    }

    void Update()
    {
        if (GameManager.cameraType == 0)
        {
            cameraText.text = "Camera Type: Close";

        }
        else if (GameManager.cameraType == 1)
        {
            cameraText.text = "Camera Type: Far (Default)";

        }
        else if (GameManager.cameraType == 2)
        {
            cameraText.text = "Camera Type: 2D Top Down";

        }
    }

    public void SetNormalCam()
    {
       
            GameManager.cameraType = 0;
            //cameraText.text = "Camera Type: Normal";
        

    }
    public void SetFarCam()
    {
        
            GameManager.cameraType = 1;
            //cameraText.text = "Camera Type: Far";
        

    }
    public void Set2DCam()
    {
        
            GameManager.cameraType = 2;
            //cameraText.text = "Camera Type: 2D Top Down";
        

    }

}
