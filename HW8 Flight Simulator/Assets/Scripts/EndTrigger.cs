using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndTrigger : MonoBehaviour
{
    public GameObject panel;
    public Text endText;
    //private UnityStandardAssets.Vehicles.Aeroplane.AeroplaneAudio airplane;
    //public AudioSource planeSound;
    private UImanager textUI;

    // Start is called before the first frame update
    void Start()
    {
        textUI = GameObject.FindWithTag("ui").GetComponent<UImanager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        GetComponent<AudioSource>().Play();
        //planeSound.Stop();
        Time.timeScale = 0;
        Debug.Log("hit end~");
        panel.SetActive(true);
        endText.text = "Winner!";
    }
}
