using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuScript : MonoBehaviour
{
    public string sampleScene;

    public GameObject settingsScreen;

    public GameObject creditsScreen;

    public GameObject controlsScreen;



    public void StartGame()
    {
        SceneManager.LoadScene(sampleScene);
    }

    public void OpenSettings()
    {
        settingsScreen.SetActive(true);

        if (settingsScreen.activeSelf)
        {
            controlsScreen.SetActive(false);
        }
    }

    public void OpenCredits()
    {
        creditsScreen.SetActive(true);
    }

    public void OpenControls()
    {
        controlsScreen.SetActive(true);

        if (controlsScreen.activeSelf)
        {
            settingsScreen.SetActive(false);
        }

    }

    public void BackToMenu()
    {
        settingsScreen.SetActive(false);
        creditsScreen.SetActive(false);
        controlsScreen.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
        //Debug.Log("quitting");
    }
}
