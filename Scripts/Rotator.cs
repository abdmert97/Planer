using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RotationType
{
    Default,
    PingPong
}
public class Rotator : MonoBehaviour
{
    
    public float rotationAmount = 45f;
    private int rotationDirection = 1;
    public float rotationRate = 1;
    public RotationType rotationType = RotationType.Default;

    public float rotationTime = 1 ;
    private bool _first = true;
    private Transform _plane;
    public float rotationDistance = 15;
    public Vector3 startRotation;
    private void Start()
    {
        GameManager.RestartLevel += ResetRotation;
        _plane = GameManager.Instance.plane;
        startRotation = transform.rotation.eulerAngles;
    }
    // Update is called once per frame
    void Update()
    {
        if (_first&&Time.frameCount%10 == 0 && Vector3.Distance(_plane.position,transform.position)<rotationDistance)
        {
            _first = false;
            StartCoroutine(Rotate(rotationDirection));
            if (rotationType == RotationType.PingPong)
            {
                rotationDirection *= -1;
            }
            
        }
    }

    void ResetRotation()
    {
        Debug.Log("resetted");
        _first = true;
        transform.rotation =Quaternion.Euler(startRotation);
    }
    private IEnumerator Rotate(int  rotationDirection )
    {
        float angle = (rotationAmount*rotationDirection) / (10*rotationTime);
     
        for (int i = 0; i < 10*rotationTime; i++)
        {
            transform.Rotate(0,0,angle,Space.Self);
            yield return new WaitForEndOfFrame();
        }
    }
}
