using System;
using System.Collections;
using System.Collections.Generic;
using MertTools;
using UnityEngine;

public class StopCamera : MonoBehaviour
{
    private CameraController _controller;

    private void Start()
    {
        
        _controller = Camera.main.GetComponent<CameraController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        GameManager.RestartLevel += OpenCamera;
       _controller.enabled = false;
      
       
    }

    void OpenCamera()
    {
        _controller.enabled = true;
        GameManager.RestartLevel -= OpenCamera;
    }
}
