using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
    }

    public void LoadSampleScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void LoadTutorial()
    {
        SceneManager.LoadScene("TutorialScene");
    }

    public void LoadHighscores()
    {
        SceneManager.LoadScene("Highscores");
    }

    public void QuitApp()
    {
        Application.Quit();
    }

}
