using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Grey")
        {
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "Scarlet")
        {
            Destroy(col.gameObject);
        }
    }
}
