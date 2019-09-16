using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

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
        // Keeps ball speed constant
		float xVel = rb.velocity.x;
		if (xVel < 9 && xVel > -9.5 && xVel != 0)
		{
			if (xVel > 0)
			{
				rb.velocity = new Vector2(9, rb.velocity.y);
			}
            else
			{
				rb.velocity = new Vector2(-9, rb.velocity.y);
			}
			//Debug.Log("Before: " + xVel);
			//Debug.Log("After: " + rb.velocity.x);
		}
	}

    // Ball goes left or right randomly at start of game
    void startBall()
    {
        int randomNum = Random.Range(0, 2);
        int randomX = Random.Range(45, 55);
        int randomY = Random.Range(-15, 15);
        if (randomNum < 1)
        {
            rb.AddForce(new Vector2(-randomX, randomY));
        }
        else
        {
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

			// Play ball bounce sound when ball collides with paddles
			GetComponent<AudioSource>().Play();
		}
    }

    void ResetBall()
	{
		// reset velocity
		rb.velocity = Vector2.zero;
		// reset ball's position to center
		transform.position = Vector2.zero;

		Invoke("startBall", 2);
	}
}
