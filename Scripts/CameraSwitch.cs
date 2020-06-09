using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public enum CameraType
    {
        Main,
        Target,
        Wing,
        Back,
        Far,
        Front,
        Inside,
        TargetFront,
        FrontNear
        
    }
    public List<Camera> cameras = new List<Camera>();
    public CameraType activeCamera;

    private void OnValidate()
    {
        SwitchCameraManual(activeCamera);
    }

    public Camera GetActiveCamera()
    {
        return  cameras[(int) activeCamera];
    }
    private void SwitchCameraManual(CameraType cameraType)
    {
        foreach (var camera in cameras)
        {
            camera.enabled = false;
                   
        }
        cameras[(int) activeCamera].enabled = true;
       // GameManager.Instance.planeController._camera = cameras[(int) activeCamera];
    }

    private void Start()
    {
        foreach (var camera in cameras)
        {
            camera.enabled = false;
            
        }
        cameras[(int) activeCamera].enabled = true;
        GameManager.Instance.planeController._camera = cameras[(int) activeCamera];
    }

    
    public void SwitchCamera(CameraType cameraType)
    {
        cameras[(int) activeCamera].enabled = false;
        cameras[(int) cameraType].enabled = true;
        activeCamera = cameraType;
        GameManager.Instance.planeController._camera = cameras[(int) activeCamera];
        
    }
}
