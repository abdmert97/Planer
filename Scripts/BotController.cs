using System;
using System.Collections;
using System.Collections.Generic;
using Dreamteck.Splines;
using Dreamteck.Splines.Primitives;
using UnityEngine;

public class BotController : MonoBehaviour
{
    public SplineFollower splineFollower;
    public SplineFollower target;
    private bool rotating = false;
    public float followSpeed = 1;
    private float nullTime = 1.8f;
    [Range(0,100)]
    public int startPosition = 3;

    public bool enableBot;
    // Start is called before the first frame update

    public bool EnableBot
    {
        get => enableBot;
        set
        {
            enableBot = value;
            if (enableBot)
            {
                gameObject.SetActive(true);
            
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }

    public int StartPosition
    {
        get => startPosition;
        set
        {
            startPosition = value;
            splineFollower.SetPercent(startPosition/100f);
        } 
    }

   
    private void Start()
    {
     splineFollower.SetPercent(startPosition/100f);
    }

    private void FixedUpdate()
    {
        splineFollower.followSpeed = target.followSpeed * followSpeed;
        if (rotating)
        {
            nullTime = 1.8f;
            
        }
        else
        {
            nullTime -= Time.fixedDeltaTime;
            if (nullTime <= 0&&  splineFollower.motion.rotationOffset.z >2 )
            {
                splineFollower.motion.rotationOffset -= splineFollower.motion.rotationOffset / 60;
            }
        }
    }
    // Update is called once per frame

    private void OnTriggerEnter(Collider other)
    {
        AISetter aiSetter = other.GetComponent<AISetter>();
        StartCoroutine(RotateWings(aiSetter.rotation, aiSetter.time));
    }



    IEnumerator RotateWings(float rotation, float time)
    {
        int iteration = (int) (time / Time.fixedDeltaTime);
        iteration = Mathf.Clamp(iteration, 30, 120);
    
        float dist = (rotation-splineFollower.motion.rotationOffset.z )/ iteration;
        for (int i = 0; i < iteration; i++)
        {
            rotating = true;
            splineFollower.motion.rotationOffset += dist*Vector3.forward;
            yield return new WaitForFixedUpdate();
            
        }

        rotating = false;
    }
}
