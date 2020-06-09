using System;
using System.Collections;
using System.Collections.Generic;
using Dreamteck.Splines;
using UnityEngine;

public class SpeedIncrease : MonoBehaviour
{
   private SplineFollower _splineFollower;

   public float time = 1;
   public float speedIncrease = 2;
   public bool speedEffect = true;
   public float effectDelay = 2;
   private void Start()
   {
      _splineFollower = GameManager.Instance.planeController.splineFollower;
   }

   private void OnTriggerEnter(Collider other)
   {
      StartCoroutine(IncreaseSpeed());
      
   }

   private IEnumerator IncreaseSpeed()
   {
      if (speedIncrease > 0 && speedEffect )
      {
         GameManager.Instance.speedEffect.Play();
         
      }
    
      int iteration = (int)(time * 60);
      float increase = speedIncrease / iteration;
      for (int i = 0; i < iteration; i++)
      {
         _splineFollower.followSpeed += increase;
         GameManager.Instance.speedEffect.transform.rotation = Quaternion.Euler(-180*Vector3.right+Vector3.up*GameManager.Instance.cameraController.transform.rotation.eulerAngles.y);
         yield return null;
      }
      
      yield return new WaitForSeconds(effectDelay);
      GameManager.Instance.speedEffect.Stop();
   }
}
