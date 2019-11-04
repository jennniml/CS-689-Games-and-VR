using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public Transform airplane;

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(airplane);
    }
}
