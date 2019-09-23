using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateWinUI : MonoBehaviour
{

    public Text winText;

    public void UpdateWin(int score)
    {
        //LoadScene("WinLoseScene");
        if (score < 26)
        {
            winText.text = "Player Loses";
        }
        else
        {
            winText.text = "Player Wins!!!";
        }
        Time.timeScale = 0;
    }
}
