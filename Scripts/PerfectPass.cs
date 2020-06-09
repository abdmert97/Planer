using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public enum ObstacleType
{
    Torus,
    Plus,
    Triangle,
    NonDestructable
}
public class PerfectPass : MonoBehaviour
{
    public ParticleSystem perfectParticle;
    public CrashObstacle crashObstacle;
    public ObstacleType obstacleType = ObstacleType.Torus;
    public List<CrashObstacle> obstacleList;
    public bool destroyAnimation = true;
    private void Start()
    {
        perfectParticle.Stop();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (obstacleList.Count != 0)
        {
            foreach (var obstacle in obstacleList)
            {
                if (obstacle.crashed)
                {
                    return;
                }
            }
        }
        else if (crashObstacle.crashed)
            return;

        if (destroyAnimation)
        {
            GameManager.Instance.destructor.CreateDestruction(obstacleType,transform.parent.position, transform.rotation.eulerAngles,transform.parent);
            if (obstacleList.Count != 0)
            {
                foreach (var obstacle in obstacleList)
                {
                    obstacle.GetComponent<Renderer>().enabled = false;
                    Invoke(nameof(ResetMaterial), 3f);
                }
            }
            else
            {
                transform.parent.GetComponent<Renderer>().enabled = false;
                Invoke(nameof(ResetMaterial),3f);

            }
        }

        perfectParticle.transform.position = other.transform.position;
        perfectParticle.Play();
        GameManager.Instance.vibrator.TriggerSelection();

    }

    void ResetMaterial()
    {
        if (obstacleList.Count != 0)
        {
            foreach (var obstacle in obstacleList)
            {
                obstacle.GetComponent<Renderer>().enabled = true;
            }
        }
        else
            transform.parent.GetComponent<Renderer>().enabled = true;
    }
}
