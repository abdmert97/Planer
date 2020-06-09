using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCamera : MonoBehaviour
{

    public Transform target;
    public Vector3 startRotation;
    public Vector3 distance;
    private Vector3 _lastPosition;
    
    private void Start()
    {
        transform.rotation = Quaternion.Euler(startRotation);
        _lastPosition = target.position;
    }

    private void LateUpdate()
    {
        
        transform.position = target.position + distance;
        transform.LookAt(target);
        transform.Rotate(startRotation);
    }
}
