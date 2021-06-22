using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public GameObject SoundOnButton;
    public GameObject SoundOffButton;
    public GameObject PausePanel;
    private void Start()
    {
       // Time.timeScale = 1;
        FootSteps.needSound = SaveSystem.GetState("Sound");
        if (PausePanel != null) PausePanel.SetActive(false);
        if (SaveSystem.GetState("Sound") == 1) {
            SoundOnButton.SetActive(true);
            SoundOffButton.SetActive(false);
        }
        else
        {
            SoundOnButton.SetActive(false);
            SoundOffButton.SetActive(true);
        }
    }
    public void Play()
    {
        SceneManager.LoadScene("l1");
    }

    public void Resume()
    {
        Time.timeScale = 1;
        if (PausePanel.activeSelf)
        {
            
            Debug.Log("Resume");
            PausePanel.SetActive(false);
        }
        else Pause();
    }

    public void Menu()
    {
        Resume();
        SceneManager.LoadScene("Menu");
    }
    public void Pause()
    {
        
        if (!PausePanel.activeSelf)
        {
            Time.timeScale = 0;
            Debug.Log(Time.timeScale);
            PausePanel.SetActive(true);
        }
        else Resume();
    }

    public void SoundOff()
    {
        SaveSystem.SaveState("Sound", 1);
        FootSteps.needSound = 1;
        SoundOffButton.SetActive(false);
        SoundOnButton.SetActive(true);
    }

    public void SoundOn()
    {
        FootSteps.needSound = 0;
        SaveSystem.SaveState("Sound", 0);
        SoundOnButton.SetActive(false);
        SoundOffButton.SetActive(true);
    }
}
