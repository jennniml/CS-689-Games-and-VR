using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaypointEvents : MonoBehaviour
{
    public Text pointText, objText, timerText, endTime, endPoints;
    private string[] objMessages;
    private int points = 0, index = 0;
    private float startTime;
    public GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        objMessages = new string[6] {
            "1st Objective: Inspect the boat",
            "2nd Objective: Walk through the meadow",
            "3rd Objective: Cross the bridge",
            "4th Objective: Explore the campsite",
            "5th Objective: Climb to the top of the hill",
            "6th Objective: Travel around the mountain"
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

    // Waypoint event: Updates objective text
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Trigger")
        {
            PlaySound();
            Debug.Log(col.gameObject.tag);
            index++; 
            objText.text = objMessages[index];
            UpdatePoints();
        }
        if (col.gameObject.tag == "EndTrigger")
        {
            Debug.Log(col.gameObject.tag);
            PlaySound();
            UpdatePoints();
            GameFinished();
        }
    }

    // Player reached the last trigger
    void GameFinished()
    {
        Time.timeScale = 0;
        panel.SetActive(true);
        pointText.gameObject.SetActive(false);
        objText.gameObject.SetActive(false); 
        timerText.gameObject.SetActive(false);
        endTime.text = timerText.text;
        endPoints.text = "Total Points: " + points;
    }

    // Plays sound
    void PlaySound()
    {
        GetComponent<AudioSource>().Play();
    }

    // Update points
    void UpdatePoints()
    {
        points += 5;
        pointText.text = "POINTS: " + points;
    }
}
