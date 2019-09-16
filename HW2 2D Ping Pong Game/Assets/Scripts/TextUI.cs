using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextUI : MonoBehaviour
{
    public Text leftText, rightText, winText;
    GameObject[] options;

    // Start is called before the first frame update
    void Start()
    {
        options = GameObject.FindGameObjectsWithTag("ShowOnWin");
        HideOptions();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Update score text
    public void UpdateScoreUI(int left, int right)
    {
        leftText.text = "" + left;
        rightText.text = "" + right;
    }

    // Update winner text
    public void WinText(string winner)
    {
        winText.text = winner + " wins!!!";
        ShowOptions();
    }

    // Shows objects with 
    void ShowOptions()
    {
        foreach (GameObject g in options)
        {
            g.SetActive(true);
        }
    }

    void HideOptions()
    {
        foreach (GameObject g in options)
        {
            g.SetActive(false);
        }
    }
}
