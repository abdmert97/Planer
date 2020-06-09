using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{

    public CameraSwitch.CameraType cameraType;


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Switch camera");
        GameManager.Instance.cameraSwitch.SwitchCamera(cameraType);
    }
}
