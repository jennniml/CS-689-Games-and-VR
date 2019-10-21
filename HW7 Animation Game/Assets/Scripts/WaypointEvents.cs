using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaypointEvents : MonoBehaviour
{
    public Text pointText, objText, timerText;
    private string[] objMessages;
    private int points = 0;
    private float startTime;

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
        pointText.text = "POINTS: 0";
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

    void Waypoint1()
    {

    }

    // Plays sound
    void PlaySound()
    {

    }

    // Update points
    void UpdatePoints()
    {

    }
}
