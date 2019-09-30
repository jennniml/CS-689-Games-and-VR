using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class HalfPointTrigger : MonoBehaviour
{
    public GameObject LapCompleteTrig;
    public GameObject HalfLapTrig;
    //public GameObject panel;
    //public Text winText;

    // car hit half point, activates end point trigger
    private void OnTriggerEnter(Collider other)
    {
        LapCompleteTrig.SetActive(true);
        HalfLapTrig.SetActive(false);
        //winText.text = "You Win!";
        //panel.SetActive(true);
    }
}
