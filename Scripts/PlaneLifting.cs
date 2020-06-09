using System.Collections;
using System.Collections.Generic;
using Dreamteck.Splines;
using UnityEngine;

public class PlaneLifting : MonoBehaviour
{
    private SplineFollower _splineFollower;
    // Start is called before the first frame update
    void Start()
    {

        _splineFollower = GetComponent<SplineFollower>();
        _splineFollower.followSpeed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        _splineFollower.followSpeed += Time.deltaTime*2 ;
        else
        {
            _splineFollower.followSpeed -= Time.deltaTime ;
        }
    }
}
