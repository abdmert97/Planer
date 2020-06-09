using System;
using System.Collections;
using System.Collections.Generic;
using MertTools;
using UnityEngine;

public class Destructor : MonoBehaviour
{
    public GameObject torus;
    public GameObject newPlus;
    public GameObject plus;
    
    public ObjectPool torusPool;
    public ObjectPool newPlusPool;
    public ObjectPool plusPool;

    private void Start()
    {
        
        torusPool   =new GameObject("Pool").AddComponent<ObjectPool>(); 
        newPlusPool =new GameObject("Pool").AddComponent<ObjectPool>(); 
        plusPool    =new GameObject("Pool").AddComponent<ObjectPool>();
        torusPool.transform.parent = transform;
        newPlusPool.transform.parent = transform;
        plusPool.transform.parent = transform;
        
        torusPool.poolSize = 3;
        newPlusPool.poolSize = 3;
        plusPool.poolSize = 3;
        torusPool.poolType = ObjectPool.PoolType.Static;
        newPlusPool.poolType = ObjectPool.PoolType.Static;
        plusPool.poolType = ObjectPool.PoolType.Static;
        torusPool.SetPoolObject(torus);
        newPlusPool.SetPoolObject(newPlus);
        plusPool.SetPoolObject(plus);
        
    }

    public void CreateDestruction(ObstacleType obstacleType,Vector3 position,Vector3 angle,Transform _transform)
    {
        ObstacleDestruction obstacleDestruction;
        if (obstacleType == ObstacleType.NonDestructable) return;
        if (obstacleType == ObstacleType.Torus)
        {
            obstacleDestruction = torusPool.GetObjectFromPool().GetComponent<ObstacleDestruction>();

        }
        else if (obstacleType == ObstacleType.Triangle)
        {
            obstacleDestruction = newPlusPool.GetObjectFromPool().GetComponent<ObstacleDestruction>();
        }
        else if (obstacleType == ObstacleType.Plus)
        {
            obstacleDestruction = plusPool.GetObjectFromPool().GetComponent<ObstacleDestruction>();
        }
        else
        {
            obstacleDestruction = torusPool.GetObjectFromPool().GetComponent<ObstacleDestruction>();
        }
        obstacleDestruction.Destroy(position,angle,_transform);
        
    }

}

