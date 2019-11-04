using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    public GameObject panel;
    public Text timerText;
    private float startTime;

    private void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.time - startTime;    // time since the timer has started
        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("F2");

        timerText.text = minutes + ":" + seconds;
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
