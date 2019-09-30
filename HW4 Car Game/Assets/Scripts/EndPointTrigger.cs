using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndPointTrigger : MonoBehaviour
{
    public GameObject panel;
    public Text winText;
    public CarControl car;

    // Car hit the end point trigger
    private void OnTriggerEnter(Collider other)
    {
        car.GetSound().Stop();

        if (car.GetPoints()>15)
        {
            winText.text = "You Win!";
        }
        else
        {
            winText.text = "You Lose";
        }
        
        panel.SetActive(true);
        Time.timeScale = 0;
    }
}
