using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideWalls : MonoBehaviour
{
    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name == "Ball")
        {
            string wallName = transform.name;
            GameManager.Score(wallName);
        }
    }
}
