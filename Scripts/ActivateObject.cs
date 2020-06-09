using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateObject : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;
    public GameObject prefab;
    private void OnTriggerEnter(Collider other)
    {
        target.SetActive(true);
        Invoke(nameof(Deactivate),10f);
    }

    private void Deactivate()
    {
        GameObject destroyed = target;
        target = Instantiate(prefab, target.transform.position,target.transform.rotation);
        target.SetActive(false);
        Destroy(destroyed);
    }
}
