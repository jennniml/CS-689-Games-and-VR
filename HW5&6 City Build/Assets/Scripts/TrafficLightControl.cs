using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightControl : MonoBehaviour
{
    private GameObject[] Red1, Red2, Yellow1, Yellow2, Green1, Green2;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize arrays with light blocks
        Red1 = new GameObject[2]{
            transform.GetChild(0).gameObject.transform.GetChild(0).gameObject,
            transform.GetChild(2).gameObject.transform.GetChild(0).gameObject
        };
        Red2 = new GameObject[2]{
            transform.GetChild(1).gameObject.transform.GetChild(0).gameObject,
            transform.GetChild(3).gameObject.transform.GetChild(0).gameObject
        };
        Yellow1 = new GameObject[2]{
            transform.GetChild(0).gameObject.transform.GetChild(1).gameObject,
            transform.GetChild(2).gameObject.transform.GetChild(1).gameObject
        };
        Yellow2 = new GameObject[2]{
            transform.GetChild(1).gameObject.transform.GetChild(1).gameObject,
            transform.GetChild(3).gameObject.transform.GetChild(1).gameObject
        };
        Green1 = new GameObject[2]{
            transform.GetChild(0).gameObject.transform.GetChild(2).gameObject,
            transform.GetChild(2).gameObject.transform.GetChild(2).gameObject
        };
        Green2 = new GameObject[2]{
            transform.GetChild(1).gameObject.transform.GetChild(2).gameObject,
            transform.GetChild(3).gameObject.transform.GetChild(2).gameObject
        };

        StartCoroutine(LightCycle());
    }

    // Light goes from green to red back to green
    private IEnumerator LightCycle()
    {
        while(true) {
            ShowLight(Green1);
            ShowLight(Red2);
            yield return new WaitForSeconds(5);
            HideLight(Green1);
            ShowLight(Yellow1);
            yield return new WaitForSeconds(2);
            HideLight(Yellow1);
            HideLight(Red2);
            ShowLight(Red1);
            ShowLight(Green2);
            yield return new WaitForSeconds(5);
            HideLight(Green2);
            ShowLight(Yellow2);
            yield return new WaitForSeconds(2);
            HideLight(Yellow2);
            HideLight(Red1);
        }
    }

    // Reveal traffic light
    void ShowLight(GameObject[] light)
    {
        foreach (var item in light)
        {
            item.SetActive(false);
        }
    }

    // Hide traffic light
    void HideLight(GameObject[] light)
    {
        foreach (var item in light)
        {
            item.SetActive(true);
        }
    }
}
