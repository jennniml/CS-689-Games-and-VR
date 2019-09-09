using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TextUpdateUI : MonoBehaviour
{
	int score;  // score of game
    public Text scoreText, greyText, scarletText;

    // Start is called before the first frame update
    void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {
		
    }

	// Calculates the score based on remaining breaks
	public void calculateScore(int greyNum, int scarletNum)
	{
		if (greyNum > scarletNum * 2)
		{
			score += 2;
		}
		else
		{
			score++;
		}
        scoreText.text = "Score: " + score;
		greyText.text = "Grey: " + greyNum;
		scarletText.text = "Scarlet: " + scarletNum;
	}
}
