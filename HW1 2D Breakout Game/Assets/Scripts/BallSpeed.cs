using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpeed : MonoBehaviour
{
    float constantSpeed = 6f;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
    }

    // Keeps ball's speed constant
    void Update()
    {
        rb.velocity = constantSpeed * (rb.velocity.normalized);
        rb.gravityScale = 0;
    }
}
