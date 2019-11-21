using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRLookWalk : MonoBehaviour
{
    public Transform vrCamera;          // VR Main Camera
    public float toggleAngle = 30.0f;   // angle at which walk/stop triggered (main camera X value)
    public float speed = 2.0f;           // how fast to move
    //public bool moveFoward;             // player move foward or not
    private CharacterController myCC;

    // Start is called before the first frame update
    void Start()
    {
        myCC = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // check if player head rotated down past toggleAngle, but not > straight down
        if (vrCamera.eulerAngles.x >= toggleAngle && vrCamera.eulerAngles.x < 90.0f)
        {
            // find the forward direction
            Vector3 forward = vrCamera.TransformDirection(Vector3.forward);
            // tell CharacterController to move forward
            myCC.SimpleMove(forward * speed);

        }
    }

    void PlaySound()
    {
        GetComponent<AudioSource>().Play();
    }
}
