using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierControl : MonoBehaviour
{
    public GameObject[] barriers = new GameObject[4];
    public GameObject redLight;
    private UIManager textUI;

    // Start is called before the first frame update
    void Start()
    {
        textUI = GameObject.FindWithTag("ui").GetComponent<UIManager>();
    }

    // Check traffic light barrier
    void OnTriggerEnter(Collider other)
    {
        if (!redLight.activeSelf)
        {
            // Add violation point
            textUI.UpdateViolationsUI();
        }

        // Deactivate other barriers
        foreach (var item in barriers)
        {
            item.SetActive(false);
        }

        Invoke("ActivateBarriers", 5);
    }

    // Turn all barriers back on
    void ActivateBarriers()
    {
        foreach (var item in barriers)
        {
            item.SetActive(true);
        }
    }
}
