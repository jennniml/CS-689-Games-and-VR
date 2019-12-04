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

    private Vector3 lift;
    public float enginePower = 40, liftBooster = 0.2f;
    private float rotateAmount = 0.25f;

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

        pitch = Input.GetAxis("Vertical");
        rollyaw = Input.GetAxis("Horizontal");

        MovingPlane();
    }

    // Update is called once per frame
    void Update()
    {
        curSpeed = rb.velocity.magnitude;

        Debug.Log("ROLLYAW: " + rollyaw);
        Debug.Log("PITCH: " + pitch);
        Debug.Log("SPEED: " + curSpeed);
        
        Vector3 moveCamTo = transform.position - transform.forward * 20.0f + Vector3.up * 8.0f;
        Camera.main.transform.position = moveCamTo;
        Camera.main.transform.LookAt(transform.position);
    }

    void MovingPlane()
    {
        MoveFlaps();

        //Add force from jet engine 
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(transform.forward * enginePower);
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.Rotate(0, -rotateAmount, 0);
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            transform.Rotate(0, rotateAmount, 0);
        }

        //Add lift force 
        lift = Vector3.Project(rb.velocity, transform.forward);
        rb.AddForce(transform.up * lift.magnitude * liftBooster);

        //Banking controls, turning turning left and right on Z axis
        rb.AddTorque(rollyaw * transform.forward * -1f);

        //Pitch controls, turning the nose up and down
        rb.AddTorque(-pitch * transform.right);

            //Set drag and angular drag according relative to speed
            rb.drag = 0.001f * rb.velocity.magnitude;
            rb.angularDrag = 0.01f * rb.velocity.magnitude;
       
    }



void MoveFlaps()
    {
        foreach (var flap in flaps)
        {
            if (flap.CompareTag("Elevator"))
            {
                float num = 8.85f;
                if (flap.name == "ElevatorLeftObject")
                {
                    num = -num;
                }
                flap.transform.localRotation = Quaternion.Slerp(flap.transform.localRotation,
                    Quaternion.Euler(angle * pitch, num, 0f), smooth * Time.deltaTime);
            }
            else if (flap.CompareTag("Aileron"))
            {
                if (flap.name == "AileronRightObject")
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
                    Quaternion.Euler(-11.5f, angle * -rollyaw, (angle * -rollyaw)/-5f), smooth * Time.deltaTime);
            }
        }
    }

}
