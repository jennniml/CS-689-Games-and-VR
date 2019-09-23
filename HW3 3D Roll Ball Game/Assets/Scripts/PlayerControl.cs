using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody rb;
    public UIManager textUI;
    public float speed;
    private int cubeNum = 8, cylinderNum = 4, score = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        textUI = GameObject.FindWithTag("ui").GetComponent<UIManager>();
    }

    // Moves the player ball object with arrow keys
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cube"))
        {
            cubeNum--;
            Destroy(other.gameObject);
            score += 1;
            textUI.UpdateScoreUI(score);
        }
        else if (other.gameObject.CompareTag("Cylinder"))
        {
            cylinderNum--;
            Destroy(other.gameObject);
            score += cubeNum;
            textUI.UpdateScoreUI(score);
        }

        checkRemaining();
    }

    void checkRemaining()
    {
        if (cubeNum==0 && cylinderNum==0)
        {
            Time.timeScale = 0;
            textUI.LoadScene("WinLoseScene");

        }
    }
}


