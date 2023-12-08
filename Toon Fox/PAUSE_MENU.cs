using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PAUSE_MENU : MonoBehaviour
{
    public AudioSource audioSource;

    public void SettingsButtonClicked()
    {

        Time.timeScale = 0f; // Pause the game by setting time scale to 0
        audioSource.Pause();
    }
public void PauseButtonClicked()
{
    Time.timeScale = 1f;
    audioSource.UnPause();
}
public void exit()
    {
        Application.Quit();
    }

}
