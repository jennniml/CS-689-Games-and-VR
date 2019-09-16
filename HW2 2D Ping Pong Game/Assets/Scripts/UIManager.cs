using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text leftText, rightText, winText;
    GameObject[] options;

    // Start is called before the first frame update
    void Start()
    {
        options = GameObject.FindGameObjectsWithTag("ShowOnWin");
        HideOptions();
    }

    // Update score text
    public void UpdateScoreUI(int left, int right)
    {
        leftText.text = "" + left;
        rightText.text = "" + right;
    }

    // Update winner text
    public void WinText(string winner)
    {
        winText.text = winner + " wins!!!";
        ShowOptions();
    }

    // Shows objects after win
    void ShowOptions()
    {
        foreach (GameObject g in options)
        {
            g.SetActive(true);
        }
    }

    // Hides objects before win
    void HideOptions()
    {
        foreach (GameObject g in options)
        {
            g.SetActive(false);
        }
    }

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
