using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManageGame : MonoBehaviour
{
    public int leftScore = 0;
    public int rightScore = 0;
    public UIManager textUI;
    private int winningScore = 10;

    // Start is called before the first frame update
    void Start()
    {
        textUI = GameObject.FindWithTag("ui").GetComponent<UIManager>();
    }

    // Update score
    public void Score(string wallID)
    {
        if (wallID == "leftWall")
        {
            leftScore++;
        }
        else
        {
            rightScore++;
        }
        textUI.UpdateScoreUI(leftScore, rightScore);

        CheckWin();
    }

    // When max score reached, stops game and shows winner
    void CheckWin()
    {
        if (rightScore == winningScore)
        {
            FinishControl();
            textUI.WinText("Right Player");
        }
        else if (leftScore == winningScore)
        {
            FinishControl();
            textUI.WinText("Left Player");
        }
    }

    // Stops the game
    public void FinishControl()
    {
        //firstTry = false;
        Time.timeScale = 0;
    }
}
