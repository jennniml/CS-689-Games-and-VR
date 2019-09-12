using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleControl : MonoBehaviour
{
    public Rigidbody2D leftPaddle, rightPaddle;
    private KeyCode leftMoveUp = KeyCode.W;
    private KeyCode leftMoveDown = KeyCode.S;
    private KeyCode rightMoveUp = KeyCode.UpArrow;
    private KeyCode rightMoveDown = KeyCode.DownArrow;
    private float speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        leftPaddle = GameObject.FindWithTag("LeftPaddle").GetComponent<Rigidbody2D>();
        rightPaddle = GameObject.FindWithTag("RightPaddle").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movePaddle(leftPaddle, leftMoveUp, leftMoveDown);
        movePaddle(rightPaddle, rightMoveUp, rightMoveDown);
    }

    void movePaddle(Rigidbody2D p, KeyCode up, KeyCode down)
    {
        if (Input.GetKey(up))
        {
            p.velocity = new Vector2(0, speed);
        }
        else if (Input.GetKey(down))
        {
            p.velocity = new Vector2(0, -speed);
        }
        else
        {
            p.velocity = new Vector2(0, 0);
        }
    }
}
