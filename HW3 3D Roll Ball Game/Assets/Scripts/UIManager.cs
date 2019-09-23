using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: 0";
    }

        // Update score text
        public void UpdateScoreUI(int score)
    {
        scoreText.text = "Score: " + score;
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
