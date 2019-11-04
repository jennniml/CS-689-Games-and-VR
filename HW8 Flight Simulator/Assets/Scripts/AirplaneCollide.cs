using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AirplaneCollide : MonoBehaviour
{
    public GameObject panel;
    public Text endText;
    private float startTime, seconds;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.time - startTime;    // time since the timer has started
        seconds = (t % 60);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "AircraftPropeller" && seconds>9)
        {
            Time.timeScale = 0;
            panel.SetActive(true);
            endText.text = "Crashed";
            GetComponent<AudioSource>().Play();
        }
    }
}
