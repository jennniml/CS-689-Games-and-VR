using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManageGame : MonoBehaviour
{
    public int leftScore = 0;
    public int rightScore = 0;
    public TextUI textUI;

    // Start is called before the first frame update
    void Start()
    {
        textUI = GameObject.FindWithTag("ui").GetComponent<TextUI>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Update score
    public void Score(string wallID)
    {
        if (wallID == "leftWall")
        {
            rightScore++;
        }
        else
        {
            leftScore++;
        }

        textUI.UpdateScoreUI(leftScore, rightScore);
    }


}
