using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text violationText, objText, timerText;
    private int violations = 0;
    private string[] objMessages;
    private float startTime;
    public GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        objMessages = new string[5] {
            "1st Objective: Visit the park",
            "2nd Objective: Go to the bank",
            "3rd Objective: Visit the grocery store",
            "4th Objective: Visit friend's house",
            "5th Objective: Return home"
        };
        violationText.text = "VIOLATIONS: 0";
        objText.text = objMessages[0];
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

    // Update violation text
    public void UpdateViolationsUI()
    {
        violations += 1;
        violationText.text = "VIOLATIONS: " + violations;
        GetComponent<AudioSource>().Play();
    }

    // Update objectives text
    public void UpdateObjectivesUI(int index)
    {
        objText.text = objMessages[index];
    }

    public string GetTime()
    {
        return timerText.text;
    }

    public string GetViolations() {
        return violationText.text;
    }

    public void ShowInstructions()
    {
        panel.SetActive(true);
    }

    public void HideInstructions()
    {
        panel.SetActive(false);
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
        if (scene == "CityScene")
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
