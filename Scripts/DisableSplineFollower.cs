using System;
using System.Collections;
using System.Collections.Generic;
using Dreamteck.Splines;
using UnityEngine;

public class DisableSplineFollower : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        SplineFollower splineFollower = other.transform.parent.GetComponent<SplineFollower>();
        Debug.Log(splineFollower.name);
        PlaneController planeController =  other.transform.parent.GetComponent<PlaneController>();
        planeController.enabled = false;
        splineFollower.enabled = false;
        other.transform.parent.GetComponent<Rigidbody>().velocity = other.transform.forward * 9 +other.transform.up;
        
    }

   
}
