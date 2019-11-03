using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UImanager : MonoBehaviour
{
    public GameObject panel;

    // Reloads the Level
    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    // Loads inputted scene
    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
        if (scene == "FlightScene")
        {
            Time.timeScale = 1;
        }
    }

    public void ShowInstructions()
    {
        panel.SetActive(true);
    }

    public void HideInstructions()
    {
        panel.SetActive(false);
    }

    // Exits the game
    public void ExitGame()
    {
        Application.Quit();
    }
}
