using System;
using System.Collections;
using System.Collections.Generic;
using Dreamteck.Splines;
using UnityEngine;

public class ActivateBots : MonoBehaviour
{
    public SplineFollower leftPlane;
    public SplineFollower rightPlane;


    private void OnTriggerEnter(Collider other)
    {
        leftPlane.gameObject.SetActive(true);
        rightPlane.gameObject.SetActive(true);
    }
}
