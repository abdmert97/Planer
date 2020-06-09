using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;
using TMPro;
public class PlaneController : MonoBehaviour
{

    public SplineFollower splineFollower;
    public ParticleSystem waterEffectLeft;
    public ParticleSystem waterEffectRight;
    private Vector2 _startPos;
    private Vector2 _lastPos;
    public Camera _camera;
    private float _targetAngle = 0;
    private float _distance;
    public float speedLimit;
    public float rotationSpeed;
    public float distanceMultiplier;
    private Rigidbody _rigidbody;
    public bool vertical = true;
    private bool _crashed = false;
    private float _startSpeed;
    public List<SplineComputer> splineList;
    public bool controlEnabled = true;
    public bool levelEnd  = false;
    private int _spline = 0;
    public bool multiSpline = true;
    public bool waterEffectEnabled = false;
    public Animator propAnimator;
    private readonly string planeSpeed = "PlaneSpeed";
    private void Start()
    {

       
        _startSpeed = splineFollower.followSpeed;
        Lifting();
        if (waterEffectLeft != null)
        {
            waterEffectLeft.Stop();
            waterEffectRight.Stop();
        }
    }

    private void Lifting()
    {
       // StartCoroutine(Lift());
      
    }

    private IEnumerator Lift()
    {
        splineFollower.followSpeed = 0.01f;
        for (int i = 0; i < 60; i++)
        {

            splineFollower.followSpeed += Time.deltaTime * 10;
            yield return new WaitForFixedUpdate();
        }

        controlEnabled = true;
    }

    private void Update()
    {
        SetSpline();

        WaterEffect();
        if (Time.frameCount % 10 == 0)
        {
            propAnimator?.SetFloat(planeSpeed,splineFollower.followSpeed);
        }
      
        if (controlEnabled)
        {
            InputHandle();
            PlaneRotate();
          
           /* if (splineFollower.followSpeed > 8f)
            {
                splineFollower.followSpeed -= Time.deltaTime;
            }*/
        }
       
    }

    private void SetSpline()
    {
        if (multiSpline && Math.Abs(splineFollower.clampedPercent - 1f) < 0.0005f && !levelEnd)
        {
            levelEnd = true;
            _spline++;
            Debug.Log(_spline);
            splineFollower.computer = splineList[_spline % splineList.Count];
            GameManager.RestartLevel?.Invoke();
            splineFollower.SetPercent(0);
          
        }

        if (Math.Abs(splineFollower.clampedPercent - 1f) < 0.0005f)
        {
            splineFollower.followSpeed = _startSpeed;
            Invoke(nameof(ResetLevelEnd), 1f);
        }
    }

    private void WaterEffect()
    {
        if (waterEffectEnabled)
        {
            if (waterEffectLeft.transform.parent.position.y < GameManager.Instance.seaLevel)
            {
                Vector3 pos = waterEffectLeft.transform.localPosition;
                //  waterEffectLeft.transform.position = new Vector3(pos.x,GameManager.Instance.seaLevel,pos.z);
                if (!waterEffectLeft.isPlaying)
                    waterEffectLeft.Play();
                
           
            }

            else if (waterEffectLeft.isPlaying)
            {
                waterEffectLeft.Stop();
                // waterEffectLeft.Clear();
            }

            if (waterEffectRight.transform.parent.position.y < GameManager.Instance.seaLevel)
            {
                Vector3 pos = waterEffectRight.transform.position;
                //  waterEffectRight.transform.position = new Vector3(pos.x,GameManager.Instance.seaLevel,pos.z);
                if (!waterEffectRight.isPlaying)
                    waterEffectRight.Play();
            }

            else if (waterEffectRight.isPlaying)
            {
                waterEffectRight.Stop();
                //  waterEffectRight.Clear();
            }
        }
    }

    void ResetLevelEnd()
    {
        levelEnd = false;
        GameManager.RestartLevel.Invoke();
        
    }
    private void PlaneRotate()
    {

        float angle = Mathf.Clamp((_distance * 180), -720, 720);
        _targetAngle = Mathf.Lerp(_targetAngle, angle, Time.deltaTime * rotationSpeed);
        Vector3 offset = splineFollower.motion.rotationOffset;
        offset.z = 0;
        splineFollower.motion.rotationOffset = offset + Vector3.forward * _targetAngle;
    }

    private void InputHandle()
    {
        if (Input.GetMouseButtonUp(0))
        {
            rotationSpeed /= 1.5f;
        }

        if (Input.GetMouseButtonDown(0))
        {
            _startPos = _camera.ScreenToViewportPoint(Input.mousePosition);
            rotationSpeed *= 1.5f;
        }

        if (Input.GetMouseButton(0))
        {
            _lastPos = _camera.ScreenToViewportPoint(Input.mousePosition);
            _distance = vertical
                ? distanceMultiplier * (_lastPos.y - _startPos.y)
                : distanceMultiplier * (_startPos.x - _lastPos.x);
        }

        else
        {
            _distance = 0;
        }
    }

 

    private void OnTriggerEnter(Collider other)
    {
       
      if(other.CompareTag("Obstacle") && splineFollower.followSpeed >_startSpeed+2)
        {
          
           // splineFollower.followSpeed -= 1;

            _crashed = true;

        }
        else if(!_crashed&&splineFollower.followSpeed <speedLimit && other.CompareTag("Perfect"))
        {
           // splineFollower.followSpeed +=1.5f;
            _crashed = false;
        }
        else
        {
            _crashed = false;
        }

        

    }

    public void ChangeSensivity(bool increase)
    {
        distanceMultiplier = increase ? distanceMultiplier + 0.2f : distanceMultiplier - 0.2f;
    }
    public void SetControl(bool vertical)
    {
        this.vertical = vertical;
    }
  
}
