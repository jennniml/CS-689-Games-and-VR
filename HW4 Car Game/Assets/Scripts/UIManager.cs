using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text speedText, pointsText;
    
    // Start is called before the first frame update
    void Start()
    {
        speedText.text = "0 KM/H";
        
    }

    // Update score text
    public void UpdatePointsUI(int point)
    {
        pointsText.text = "Points: " + point;
    }

    // Update speed text
    public void UpdateSpeedUI(float speed)
    {
        speedText.text = speed.ToString("F2") + " KM/H";
    }

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
        if (scene == "GameScene")
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
