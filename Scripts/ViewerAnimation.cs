using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewerAnimation : MonoBehaviour
{
    private Animator _animator;
    private int animChange = 20;
    private string[] animList = {"1", "2", "3"}; 
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.frameCount % animChange == 0)
        {
            animChange = Random.Range(200, 400);
            _animator.SetTrigger(animList[Random.Range(0,3)]);
        }    
    }
}
