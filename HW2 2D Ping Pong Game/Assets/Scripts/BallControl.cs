using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Invoke("startBall", 2);
        //startBall();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Ball goes left or right randomly at start of game
    void startBall()
    {
        int randomNum = Random.Range(0, 2);
        int randomX = Random.Range(30, 45);
        int randomY = Random.Range(-15, 15);
        if (randomNum < 1)
        {
            Debug.Log("LEFT...");
            rb.AddForce(new Vector2(-randomX, randomY));
        }
        else
        {
            Debug.Log("RIGHT...");
            rb.AddForce(new Vector2(randomX, randomY));
        }

        Debug.Log(randomX + " : " + randomY);
    }

    // Ball's direction is affected by paddle velocity
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "LeftPaddle" || col.collider.tag == "RightPaddle")
        {
            float paddleVelocity = col.collider.GetComponent<Rigidbody2D>().velocity.y;
            float velocityY = GetComponent<Rigidbody2D>().velocity.y;

            GetComponent<Rigidbody2D>().velocity = new Vector2(
                GetComponent<Rigidbody2D>().velocity.x,
                velocityY / 2 + paddleVelocity / 3);
        }
    }
}
