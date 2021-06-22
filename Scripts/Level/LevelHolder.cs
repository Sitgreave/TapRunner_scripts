using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHolder : MonoBehaviour
{
    public List<GameObject> Levels;
   public static int currentLevel = 1;
    private void Start()
    {
        if (currentLevel <= Levels.Count) Instantiate(Levels[currentLevel]);
        else
        {
            currentLevel = Levels.Count;
            Instantiate(Levels[currentLevel - 1]);
        }

    }
}
