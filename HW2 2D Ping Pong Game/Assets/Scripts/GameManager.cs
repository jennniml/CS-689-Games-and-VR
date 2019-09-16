using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int leftScore = 0;
    public static int rightScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Update score
    public static void Score(string wallID)
    {
        if (wallID == "leftWall")
        {
            rightScore++;
        }
        else
        {
            leftScore++;
        }
    }
}
