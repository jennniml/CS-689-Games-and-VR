using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextUI : MonoBehaviour
{
    public Text leftText, rightText;

    // Start is called before the first frame update
    void Start()
    {
        
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
}
