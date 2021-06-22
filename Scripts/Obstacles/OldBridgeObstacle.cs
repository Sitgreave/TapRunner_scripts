using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldBridgeObstacle : MonoBehaviour
{
   
    public Animator animator;
    public AudioSource audioSource;
    bool StageComplete = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!StageComplete)
            {
                animator.SetBool("ruin", true);
                audioSource.Play();
                StagesHolder.StagePassedCount++;
                StageComplete = true;
            }
        }
    }
}
