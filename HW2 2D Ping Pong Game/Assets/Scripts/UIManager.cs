using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public BallControl ball;

    // Reloads the Level
    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    // Loads inputted level
    public void LoadLevel(string level)
    {
        SceneManager.LoadScene(level);
        if (level == "PingPongScene")
        {
            Time.timeScale = 1;
        }
    }

    // Exits the game
    public void ExitGame()
    {
        Application.Quit();
    }

}
