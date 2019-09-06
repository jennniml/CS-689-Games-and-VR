using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleDirection : MonoBehaviour
{
    private KeyCode moveUp = KeyCode.W;
    private KeyCode moveDown = KeyCode.S;
    private KeyCode moveLeft = KeyCode.A;
    private KeyCode moveRight = KeyCode.D;

    private float speedX = 5.0f;
    private float speedY = 5.0f;
    private float boundX = 7.5f;
    private float boundY = 4.75f;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var vel = rb.velocity;
        if(Input.GetKey(moveUp))
        {
            vel.y = speedY;
            vel.x = 0.0f;
        }
        else if(Input.GetKey(moveDown))
        {
            vel.y = -speedY;
            vel.x = 0.0f;
        }
        else if(Input.GetKey(moveLeft))
        {
            vel.x = -speedX;
            vel.y = 0.0f;
        }
        else if(Input.GetKey(moveRight))
        {
            vel.x = speedX;
            vel.y = 0.0f;
        }
        else if(!Input.anyKey)
        {
            vel.y = 0.0f;
            vel.x = 0.0f;
        }

        rb.velocity = vel;

        // set bound to stop at walls
        var pos = transform.position;
        if(pos.y > boundY)
        {
            pos.y = boundY;
        }
        else if(pos.y < -boundY)
        {
            pos.y = -boundY;
        }
        else if(pos.x > boundX)
        {
            pos.x = boundX;
        }
        else if(pos.x < -boundX)
        {
            pos.x = -boundX;
        }
        transform.position = pos;
    }
}
