using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndPointTrigger : MonoBehaviour
{
    public GameObject panel;
    public Text winText;

    // Car hit the end point trigger
    private void OnTriggerEnter(Collider other)
    {
        winText.text = "You Win!";
        panel.SetActive(true);
        Time.timeScale = 0;
    }
}
