using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMainMenu : MonoBehaviour
{
    public int tutorialCountIndex = 0;
    public GameObject tutorialBase;
    public GameObject tutorial1;
    public GameObject tutorial2;
    public GameObject tutorial3;

    public void StartGame()
    {
        SceneManager.LoadSceneAsync("Play 2");
    }

    public void Tutorial()
    {
        tutorialBase.SetActive(true);
        tutorialCountIndex++;
        if (tutorialCountIndex == 1)
        {
            tutorial1.SetActive(true);
        }
        else if (tutorialCountIndex == 2)
        {
            tutorial1.SetActive(false);
            tutorial2.SetActive(true);
        }
        else if (tutorialCountIndex == 3)
        {
            tutorial2.SetActive(false);
            tutorial3.SetActive(true);
        }
        else if (tutorialCountIndex == 4)
        {
            tutorial3.SetActive(false);
            tutorialBase.SetActive(false);
            tutorialCountIndex = 0;
            StartGame();
        }
    }
}