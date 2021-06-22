using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    Character character;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            character = other.gameObject.GetComponent<Character>();
            character.OnBridge(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        character.OnBridge(false);
    }
}
