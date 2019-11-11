using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneControl : MonoBehaviour
{
    public GameObject[] flaps = new GameObject[5];
    private float pitch, roll, yaw;
    private float throttle;
    private bool airBrakes;
    private float angle = 30f;
    private float smooth = 5f; // The smoothing applied to the movement of control surfaces

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Plane control attatched to " + gameObject.name);
    }

    private void FixedUpdate()
    {
        // Read input for the pitch, yaw, roll and throttle of the aeroplane.
        pitch = Input.GetAxis("Vertical");
        roll = Input.GetAxis("Mouse X");
        yaw = Input.GetAxis("Horizontal");
        //airBrakes = Input.GetButton("Fire1");
        //throttle = Input.GetAxis("Vertical");

        // Pass the input to the airplane
        //Move(roll, pitch, m_Yaw, m_Throttle, m_AirBrakes);
    }

    // Update is called once per frame
    void Update()
    {
        MoveFlaps();
        //transform.position += transform.forward * Time.deltaTime * 90.0f;
        //transform.Rotate(-Input.GetAxis("Vertical"), 0.0f, -Input.GetAxis("Horizontal"));

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
                        Quaternion.Euler(angle * roll, 0, 4.1f), smooth * Time.deltaTime);
                }
                else
                {
                    flap.transform.localRotation = Quaternion.Slerp(flap.transform.localRotation,
                        Quaternion.Euler(angle * -roll, 0, -4.1f), smooth * Time.deltaTime);
                }
            }
            else if (flap.CompareTag("Rudder"))
            {
                flap.transform.localRotation = Quaternion.Slerp(flap.transform.localRotation,
                    Quaternion.Euler(-8f, angle * -yaw, 0f), smooth * Time.deltaTime);
            }
        }
    }

}
