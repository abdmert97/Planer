using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class CrashObstacle : MonoBehaviour
{
   
   
    private Vector3 defaultPartilceRotation;
    private Material _material;
    public bool crashed;
    Renderer _renderer ;
    private void Start()
    {
        _renderer = GetComponent<Renderer>();
       _material = _renderer.sharedMaterial;
    
    }


    private void OnTriggerEnter(Collider other)
    {
        crashed = true;
     
    
        _renderer.sharedMaterial = GameManager.Instance.transparent;
        Invoke(nameof(ResetMaterial),3f);
    }



    void ResetMaterial()
    { 
        _renderer.sharedMaterial = _material; 
        crashed = false;
    }
}