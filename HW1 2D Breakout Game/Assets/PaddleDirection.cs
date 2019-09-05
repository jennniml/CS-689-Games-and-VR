using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleDirection : MonoBehaviour
{
    public KeyCode moveUp = KeyCode.W;
    public KeyCode moveDown = KeyCode.S;
    public KeyCode moveLeft = KeyCode.A;
    public KeyCode moveRight = KeyCode.D;

    public float speed = 8.0f;
    public float boundX = 5f;
    public float boundY = 4.75f;

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
            vel.y = speed;
            vel.x = 0.0f;
        }
        else if(Input.GetKey(moveDown))
        {
            vel.y = -speed;
            vel.x = 0.0f;
        }
        else if(Input.GetKey(moveLeft))
        {
            vel.x = -speed;
            vel.y = 0.0f;
        }
        else if(Input.GetKey(moveRight))
        {
            vel.x = speed;
            vel.y = 0.0f;
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
