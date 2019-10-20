using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndTrigger : MonoBehaviour
{
    public GameObject panel;
    public Text timeText, violationText;
    public GameObject[] hideTexts = new GameObject[3];
    private UIManager textUI;
    private UnityStandardAssets.Vehicles.Car.CarAudio car;

    // Start is called before the first frame update
    void Start()
    {
        textUI = GameObject.FindWithTag("ui").GetComponent<UIManager>();
        car = GameObject.FindWithTag("Player").GetComponent<UnityStandardAssets.Vehicles.Car.CarAudio>();
    }

    // Car hit the home end point trigger
    private void OnTriggerEnter(Collider other)
    {
        panel.SetActive(true);
        foreach (var item in hideTexts)
        {
            item.SetActive(false);
        }
        GetComponent<AudioSource>().Play();
        car.StopSound();
        timeText.text = "Time: " + textUI.GetTime();
        violationText.text = textUI.GetViolations();
        Time.timeScale = 0;
    }
}
