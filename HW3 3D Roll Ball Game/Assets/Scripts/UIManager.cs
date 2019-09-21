using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
