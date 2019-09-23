using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text scoreText, winText;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Update score text
    public void UpdateScoreUI(int score)
    {
        scoreText.text = "" + score;
    }

    public void UpdateWinUI(int score)
    {
        if (score<26)
        {
            winText.text = "Player Wins!!!";
        }
        else
        {
            winText.text = "Player Loses";
        }
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
