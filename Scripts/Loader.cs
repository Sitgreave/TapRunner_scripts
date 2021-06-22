
using UnityEngine;

public class Singleton : MonoBehaviour
{

    private void Awake()
    {
        SaveSystem.LoadStates();
      //SaveSystem.ReloadStates();
        //Debug.Log(LevelHolder.currentLevel);
    }
}
