using System;
using System.Collections;
using System.Collections.Generic;
using MertTools;
using UnityEngine;


public enum CameraSetType
{
    ChangeAngle,
    FreezeXRotation,
    FreezeZRotation,
    FullSet
    
}
public class SetCameraAngle : MonoBehaviour
{
    private MixedCamera _camera;
    public CameraSetType cameraSetType = CameraSetType.ChangeAngle;
    public float cameraAngle;
    public float cameraDistance;
    public Vector3 defaultDistance;
    public Vector3 defaultRotation;
    public bool freezeXRotation;
    public bool freezeZRotation;
    private void Start()
    {
        _camera = GameManager.Instance.cameraController;

    }

    private void OnTriggerEnter(Collider other)
    {
        switch (cameraSetType)
        {
            case CameraSetType.ChangeAngle:
                StartCoroutine(ChangeAngle(_camera.angle, cameraAngle,_camera.distance,cameraDistance,_camera.defaultDistance,defaultDistance,_camera.defaultRotation,defaultRotation));
                break;
            case CameraSetType.FreezeXRotation:
                _camera.followXRotation = !freezeXRotation;
                break;
            case CameraSetType.FreezeZRotation:
                _camera.freezeZRotation = freezeZRotation;
                break;
            case CameraSetType.FullSet:
                StartCoroutine(ChangeAngle(_camera.angle, cameraAngle,_camera.distance,cameraDistance,_camera.defaultDistance,defaultDistance,_camera.defaultRotation,defaultRotation));
                _camera.freezeZRotation = freezeZRotation;
                _camera.followXRotation = !freezeXRotation;
                break;
        }
       
    }

    IEnumerator ChangeAngle(float startAngle, float targetAngle, float startDistance,float targetDistance,Vector3 startDefaultDistance,Vector3 targetDefaultDistance,Vector3 startDefaultRotation,Vector3 targetDefaultRotation)
    {
     
        float dist = (targetAngle - startAngle)/60;
        float dist2 = (targetDistance - startDistance) / 60;
        Vector3 defaultDist  = (targetDefaultDistance - startDefaultDistance) / 60;
        Vector3 defaultRot  = (targetDefaultRotation - startDefaultRotation) / 60;
        for (int i = 0; i < 60; i++)
        {
            _camera.distance += dist2;
            _camera.angle += dist;
            _camera.defaultDistance += defaultDist;
            _camera.defaultRotation+= defaultRot;
            yield return  new WaitForEndOfFrame();
        }
    }
}
