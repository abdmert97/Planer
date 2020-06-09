using System.Collections;
using System.Collections.Generic;
using Dreamteck.Splines;
using UnityEngine;

public class SpeedEffectController : MonoBehaviour
{
    public ParticleSystem particleSystem;
    public SplineFollower splineFollower;
    private Camera _camera;

    private float _defaultSpeed;
    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;
        _defaultSpeed = splineFollower.followSpeed;
        particleSystem.Stop();
    }

    // Update is called once per frame
    void Update()
    {
      
        particleSystem.transform.rotation = Quaternion.Euler(-180*Vector3.right+Vector3.up*_camera.transform.rotation.eulerAngles.y);
    }
}
