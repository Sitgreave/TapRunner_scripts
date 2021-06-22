
using UnityEngine;

public static class SaveSystem 
{
    public static void SaveStates()
    {
        PlayerPrefs.SetInt("Level", LevelHolder.currentLevel);
    }

    public static void LoadStates()
    {
        LevelHolder.currentLevel = PlayerPrefs.GetInt("Level");
    }

    public static void ReloadStates()
    {
        PlayerPrefs.SetInt("Level", 0);
        LoadStates();
    }
    
    public static void SaveState(string name, int var)
    {
        PlayerPrefs.SetInt(name, var);
    }

    public static int GetState(string name)
    {
        return PlayerPrefs.GetInt(name);
    }
}
