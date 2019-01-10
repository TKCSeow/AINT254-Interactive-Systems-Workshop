using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetFrameRate : MonoBehaviour {

    // There were some framerate problems during early development. This was to limit the framerate as it was very unstable
    

        public int target = 60;

        void Awake()
        {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = target;
        }

        void Update()
        {
            if (Application.targetFrameRate != target)
                Application.targetFrameRate = target;
        }
    
}
