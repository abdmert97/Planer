using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    private Renderer _renderer;
    private Vector3 startScale;
    private Vector3 startPosition;
    public GameObject particleSystem;
    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        startScale = transform.localScale;
        startPosition = transform.position;
    }

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        GameManager.Instance.vibrator.TriggerSelection();
        StartCoroutine(Fade());
    }

    private IEnumerator Fade()
    {
        Vector3 scaleLoss = startScale / 45f;
        //particleSystem.SetActive(false);
        for (int i = 0; i < 45; i++)
        {
            
            transform.localScale-= scaleLoss;
            transform.position += Vector3.up * Time.deltaTime*10;
            yield return null;
        }

        _renderer.enabled = false;
        Invoke(nameof(Renabled),10f);
    }


    private void Renabled()
    {
        _renderer.enabled = true;
       // particleSystem.SetActive(true);
        transform.position = startPosition;
        transform.localScale = startScale;
    }
}
