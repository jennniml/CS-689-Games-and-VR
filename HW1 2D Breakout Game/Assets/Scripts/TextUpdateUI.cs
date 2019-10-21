using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TextUpdateUI : MonoBehaviour
{
	int score;  // score of game
    public Text scoreText, greyText, scarletText;

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
