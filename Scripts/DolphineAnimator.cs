 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DolphineAnimator : MonoBehaviour
{

    private Animator _animator;
    
    private Transform _plane;
    private bool isEnable = true;
    private Vector3 position;

    public float animationDistance;
    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
        _animator = GetComponent<Animator>();
        _plane = GameManager.Instance.plane;
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnable)
        {
            float distance = Vector3.Distance(position, _plane.position);
            if (distance < animationDistance)
            {
                isEnable = false;
                Invoke(nameof(ReEnable),10f);
                _animator.SetTrigger("Plane");
            }
        }
    }

    void ReEnable()
    {
        isEnable = true;
    }
}
