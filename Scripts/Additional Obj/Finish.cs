using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    Character character;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            character = other.gameObject.GetComponent<Character>();
            character.Win();
           
        }
    }
}
