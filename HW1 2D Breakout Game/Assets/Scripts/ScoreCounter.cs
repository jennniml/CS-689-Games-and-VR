using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class ScoreCounter : MonoBehaviour
{
	public TextUpdateUI textUI;
    public UIManager ui;
    public GameObject gameOver, win;

    private int greyNum = 84;    // number of grey breaks
    private int scarletNum = 42; // number of scarlet breaks

    private void Start()
    {
        textUI = GameObject.FindWithTag("ui").GetComponent<TextUpdateUI>();
        ui = GameObject.FindWithTag("ui").GetComponent<UIManager>();
        gameOver.SetActive(false);
        win.SetActive(false);
    }

    // Grey or Scarlet Break dissapears when hit by ball
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Grey")
        {
            greyNum--;
            textUI.calculateScore(greyNum, scarletNum);
            Destroy(col.gameObject);

            checkDone();
        }
        if (col.gameObject.tag == "Scarlet")
        {
            scarletNum--;
            textUI.calculateScore(greyNum, scarletNum);
            Destroy(col.gameObject);

            checkDone();
        }

        // Game Over when ball hits bottom wall
        if (col.gameObject.name == "Lower_Wall")
        {
            ui.FinishControl();
            gameOver.SetActive(true);
        }

        // Play ball bounce sound when ball collides with object
        gameObject.GetComponent<AudioSource>().Play();
    }

    void checkDone()
    {
        if (scarletNum==0)
        {
            ui.FinishControl();
            win.SetActive(true);
        }
    }
}
