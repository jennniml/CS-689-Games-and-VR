using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneControl : MonoBehaviour
{

    private Rigidbody rb;
    public GameObject[] flaps = new GameObject[5];
    private float curSpeed, prevSpeed, constSpeed = 50f, maxSpeed = 70f;
    private float pitch, rollyaw;
    private float angle = 50f;
    private float smooth = 5f; // The smoothing applied to the movement of control surfaces
    private Vector3 prevPos, currVel;
    private Quaternion originalRotate, tempRotate;

    public float power;
    public Vector3 tempPosition;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalRotate = transform.rotation;
    }

    private void FixedUpdate()
    {
        // Read input for the pitch, yaw, roll and throttle of the aeroplane.
        pitch = Input.GetAxis("Vertical") * Time.deltaTime * 50f;
        rollyaw = Input.GetAxis("Horizontal") * Time.deltaTime * 50f;
        //Vector3 movement = new Vector3(pitch, 0.0f, rollyaw);
        //rb.AddForce(movement * 0.5f);

        MovePlane();
    }

    // Update is called once per frame
    void Update()
    {
        curSpeed = rb.velocity.magnitude;

        Debug.Log("ROLLYAW: " + rollyaw);
        Debug.Log("PITCH: " + pitch);
        Debug.Log("SPEED: " + curSpeed);
        //transform.position += transform.forward * Time.deltaTime * 10.0f;
        //transform.Rotate(-Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"), -Input.GetAxis("Horizontal"));
    }

    void MovePlane()
    {
        MoveFlaps();
        /*
        if (curSpeed>maxSpeed)
        {
            rb.velocity = new Vector3(maxSpeed, 10, 0);
        }
        if (curSpeed < 20f)
        {
            transform.Rotate(-pitch/2f, rollyaw, -rollyaw/2.5f);
            prevSpeed = curSpeed;
        }
        else
        {
            if (pitch>0.5)
            {
                transform.Rotate(-pitch/2f, rollyaw, -rollyaw/2.5f);
                prevSpeed = curSpeed;
            }
            else
            {
                prevSpeed--;
            }
        }*/

        if (curSpeed<20)
        {
            transform.Rotate(-pitch/1.5f, rollyaw, -rollyaw);
        }
        else
        {
            transform.Rotate(-pitch, rollyaw, -rollyaw);
        }

        transform.position += transform.forward * Time.deltaTime * (curSpeed*.5f);
        //rb.AddForce(Vector3.forward * power * (curSpeed));
        

    }

    void MoveFlaps()
    {
        foreach (var flap in flaps)
        {
            if (flap.CompareTag("Elevator"))
            {
                float num = 8.85f;
                if (flap.name == "ElevatorLeft")
                {
                    num = -num;
                }
                flap.transform.localRotation = Quaternion.Slerp(flap.transform.localRotation,
                    Quaternion.Euler(angle * pitch, num, 0f), smooth * Time.deltaTime);
            }
            else if (flap.CompareTag("Aileron"))
            {
                if (flap.name == "AileronRight")
                {
                    flap.transform.localRotation = Quaternion.Slerp(flap.transform.localRotation,
                        Quaternion.Euler(angle * rollyaw, 0, 4.1f), smooth * Time.deltaTime);
                }
                else
                {
                    flap.transform.localRotation = Quaternion.Slerp(flap.transform.localRotation,
                        Quaternion.Euler(angle * -rollyaw, 0, -4.1f), smooth * Time.deltaTime);
                }
            }
            else if (flap.CompareTag("Rudder"))
            {
                flap.transform.localRotation = Quaternion.Slerp(flap.transform.localRotation,
                    Quaternion.Euler(-8f, angle * -rollyaw, 0f), smooth * Time.deltaTime);
            }
        }
    }

}
