using System.Collections.Generic;
using UnityEngine;

public class Stages : MonoBehaviour
{
    public Transform Begin;
    public Transform End;

    public float Distance()
    {
        return End.transform.position.z - Begin.transform.position.z;
    }


    [SerializeField] private List<GameObject> DecoreSets = new List<GameObject>();

    private void Start()
    {
        //if (DecoreSets)
            int i = Random.Range(0, DecoreSets.Count-1);
        if(DecoreSets[i] != null)  DecoreSets[i].SetActive(true);


    }
}
