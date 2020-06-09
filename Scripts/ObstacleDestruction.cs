using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleDestruction : MonoBehaviour
{


    public float speed = 10;
    private List<Vector3> startPositions ;
    public Vector3 startRotation;
    private List<Transform> childs ;
    private List<Vector3> childRotation ;
    public List<Rigidbody> _rigidbodies ;
    private float simulationTime = 0;
    private void Awake()
    {
         childs = new List<Transform>();
         _rigidbodies = new List<Rigidbody>();
         startPositions = new List<Vector3>();
         childRotation = new List<Vector3>();
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            startPositions.Add(child.localPosition);
            childs.Add(child);
            childRotation.Add(child.localRotation.eulerAngles);
            _rigidbodies.Add(child.GetComponent<Rigidbody>());
        }
    }

    private void Update()
    {
        if (simulationTime > 0)
            simulationTime -= Time.deltaTime;
        else
        {
            if(gameObject.activeSelf == true)
                gameObject.SetActive(false);
        }
    }

    public void Destroy(Vector3 position,Vector3 rotation,Transform _transform)
    {
        gameObject.SetActive(true);
        simulationTime = 3f;
       
        transform.position = position;
        transform.Rotate(Vector3.up*Random.Range(0,180),Space.Self);
        var parentPosition = transform.position;
   
      //  transform.rotation = Quaternion.Euler(rotation+startRotation);
  
        transform.rotation = _transform.rotation;
        transform.Rotate(startRotation);
        GatherChilds();
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = childs[i];
            Vector3 normal = (child.position - parentPosition).normalized;
            _rigidbodies[i].useGravity = true;
            _rigidbodies[i].velocity = normal * speed + new Vector3(Random.Range(-1f,1f),Random.Range(-1f,1f),Random.Range(-1f,1f));
        }
        
    }

    private void GatherChilds()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = childs[i];
            child.localPosition = startPositions[i];
            child.localRotation =Quaternion.Euler(childRotation[i]);
            _rigidbodies[i].useGravity = false;
        }
    }
}
