using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MertTools;
using MoreMountains.NiceVibrations;
using TMPro;

public class GameManager : Singleton<GameManager>
{
   public static Action RestartLevel;
   public Material transparent;
   public Destructor destructor;
   public NiceVibrationsDemoManager vibrator;
   public Transform plane;
   public TextMeshProUGUI animatedText;
   public Animator animatedTextAnimator;
   public PlaneController planeController;
   public GameObject cameraSetters;
   public MixedCamera cameraController;
   public float seaLevel = -2.2f;
   public CameraSwitch cameraSwitch;
   public ParticleSystem speedEffect;
   public BotController botController;
   private void Start()
   {
      Application.targetFrameRate = 60;
      SRDebug.Instance.PanelVisibilityChanged += SRDebug_PanelVisibilityChanged;
   }
   private void SRDebug_PanelVisibilityChanged(bool isVisible)
   {
      Time.timeScale = isVisible ? 0f : 1f;
   }
   public void DisableCameraChanges()
   {
      //bool active = !cameraSetters.activeSelf;
      cameraController.angle = 21;
      cameraController.distance = 6.7f;
      cameraController.defaultDistance = Vector3.zero;
      cameraController.defaultRotation = Vector3.zero;
     // cameraSetters.SetActive(active);
   }
}
