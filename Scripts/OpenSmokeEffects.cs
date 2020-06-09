using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSmokeEffects : MonoBehaviour
{
    public ParticleSystem particleSystem1;
    public ParticleSystem particleSystem2;
    public bool open = true;
    private void Start()
    {
        particleSystem1.Stop();
        particleSystem2.Stop();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(open)
        {
            particleSystem1.Play();
            particleSystem2.Play();
        }
        else
        {
            particleSystem1.Stop();
            particleSystem2.Stop();
        }

    }
}
