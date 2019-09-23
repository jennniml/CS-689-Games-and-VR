using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody rb;
    public UIManager textUI;
    public float speed;
    private int cubeNum = 8, cylinderNum = 4, score;
    public Text winText;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        textUI = GameObject.FindWithTag("ui").GetComponent<UIManager>();
        score = 0;
        winText.text = "";
    }

    // Moves the player ball object with arrow keys
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    // Decrements number of hit object
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cube"))
        {
            cubeNum--;
            other.gameObject.SetActive(false);
            calculateScore("cube");
            textUI.UpdateScoreUI(score);
        }
        else if (other.gameObject.CompareTag("Cylinder"))
        {
            cylinderNum--;
            other.gameObject.SetActive(false);
            calculateScore("cylinder");
            textUI.UpdateScoreUI(score);
        }
        checkRemaining();
    }

    // Calculates the new score
    void calculateScore(string hit)
    {
        if (hit == "cube")
        {
            score += 1;
        }
        else
        {
            if (cubeNum == 0)
            {
                score += 1;
            }
            else
            {
                score += cubeNum;
            }
        }
    }

    // Checks if there is no remaining cubes and cylinders
    void checkRemaining()
    {
        if (cubeNum==0 && cylinderNum==0)
        {
            transform.position = Vector2.zero;
            Time.timeScale = 0;
            UpdateWin();
        }
    }

    // Updates the winning text
    void UpdateWin()
    {
        if(score < 26)
        {
            winText.text = "Player Loses";
        }
        else
        {
            winText.text = "Player Wins!!!";
        }
    }
}


