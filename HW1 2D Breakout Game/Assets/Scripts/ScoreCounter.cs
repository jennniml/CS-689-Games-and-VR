using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
	public TextUpdateUI ui;
    
    public int greyNum = 84;
    public int scarletNum = 41;

    private void Start()
    {
		ui = GameObject.FindWithTag("ui").GetComponent<TextUpdateUI>();
    }

    // Grey or Scarlet Break dissapears when hit by ball
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Grey")
        {
            
            greyNum--;
            ui.calculateScore(greyNum, scarletNum);
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "Scarlet")
        {
            
            scarletNum--;
            ui.calculateScore(greyNum, scarletNum);
            Destroy(col.gameObject);
        }

    }

    
}
