using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoseHelper : MonoBehaviour
{
    private Transform _target;
    private float _positionZ;
    private bool _first = true;
    private Vector3 _defaultScale;
    public List<MeshRenderer> renderers = new List<MeshRenderer>();
    private List<Color> startColor = new List<Color>();
    public float visibleDistance = 15;
    private void Start()
    {
        _positionZ = transform.position.z;
        _target = GameManager.Instance.plane;
        _defaultScale = transform.localScale;
        foreach (var renderer in renderers)
        {
            startColor.Add(renderer.material.color);
        }
    }

    private void Update()
    {
        if(!_first) return;
        
        float distance = _positionZ - _target.transform.position.z;
        if (distance < visibleDistance)
        {
            foreach (var renderer in renderers)
            {
                renderer.enabled = true;
            }
            _first = false;
            StartCoroutine(IncreaseScale());
        }
    }

    private IEnumerator IncreaseScale(int frame = 20,float amount = 0.005f)
    {
        for (int i = 0; i <frame; i++)
        {
            transform.localScale += Vector3.one * amount;
            yield return null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
      
       StartCoroutine(FadeEffect());
       float targetAngle = transform.rotation.eulerAngles.z;
       float angle = other.transform.parent.rotation.eulerAngles.z;
      
       float difference = Mathf.Abs(targetAngle - angle);
       if(difference< 18)
       {
           
           GameManager.Instance.animatedText.text = "Perfect";
       }
       else if(difference< 40)
       {
          
           GameManager.Instance.animatedText.text = "Good";
       }
       else
       {
           
           GameManager.Instance.animatedText.text = "OK";
       }
       GameManager.Instance.vibrator.TriggerSelection();
       GameManager.Instance.animatedTextAnimator.Play("Fade");
    }

    private IEnumerator FadeEffect()
    {

        for (int i = 0; i < 40; i++)
        {
            foreach (var renderer in renderers)
            {
                renderer.material.color -= Color.black*0.1f;
                if(transform.localScale.x>0)
                    transform.localScale -= (Vector3.one *  0.0025f);
            }
            yield return null;
        }
        Invoke(nameof(Activate),7f);
    }

    private void Activate()
    {
        
        
        _first = true;
        int i = 0;
        foreach (var renderer in renderers)
        {
            renderer.material.color = startColor[i++];
            renderer.enabled = false;
        }
        transform.localScale = _defaultScale;
    }
}
