using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControl : MonoBehaviour
{
    /* taken from Unity wheel collider tutorial docs */
    public List<AxleInfo> axleInfos;    // info about each individual axle
    public float maxMotorTorque;        // max torque the motor can apply to wheel
    public float maxSteeringAngle;      // max steer angle of the wheel
    private Rigidbody rb;
    private float speed;
    private UIManager textUI;
    private CheckTerrain texture;
    private int oldTexture=1, newTexture;
    private int points;
    AudioSource blip, engine;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        textUI = GameObject.FindWithTag("ui").GetComponent<UIManager>();
        texture = GetComponent<CheckTerrain>();
        points = 20;
        oldTexture = texture.GetTexture();
        AudioSource[] audios = GetComponents<AudioSource>();
        blip = audios[0];
        engine = audios[1];
    }

    public void FixedUpdate()
    {
        MoveCar();
    }

    // Update is called once per frame
    private void Update()
    {
        speed = rb.velocity.magnitude * 3.6f;
        textUI.UpdateSpeedUI(speed);
        carSound();
        
        CheckTexture();
    }

    // Car steering and acceleration
    private void MoveCar()
    {
        float motor = maxMotorTorque * Input.GetAxis("Vertical");
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");

        foreach (AxleInfo axleInfo in axleInfos)
        {
            if (axleInfo.motor)
            {
                axleInfo.leftWheelW.motorTorque = motor;
                axleInfo.rightWheelW.motorTorque = motor;
            }
            if (axleInfo.steering)
            {
                axleInfo.leftWheelW.steerAngle = steering;
                axleInfo.rightWheelW.steerAngle = steering;
            }
            MoveWheels(axleInfo.leftWheelW, axleInfo.leftWheelT);
            MoveWheels(axleInfo.rightWheelW, axleInfo.rightWheelT);
        }
    }

    // Moves position & rotation of wheels
    private void MoveWheels(WheelCollider _collider, Transform _transform)
    {
        Vector3 _pos = _transform.position;
        Quaternion _quat = _transform.rotation;

        _collider.GetWorldPose(out _pos, out _quat);

        _transform.position = _pos;
        _transform.rotation = _quat;
    }

    // Checks if car is on grass
    private void CheckTexture()
    {
        newTexture = texture.GetTexture();
        if (newTexture != oldTexture)
        {
            if (texture.GetTexture() == 0)
            {
                // Decrease point by 1
                points--;
                blip.Play();
                textUI.UpdatePointsUI(points);
            }
            oldTexture = newTexture;
        }
    }

    // Plays car sound depending on speed
    private void carSound()
    {
        engine.pitch = speed/40 + .5f;
    }

    // Returns the point amount
    public int GetPoints()
    {
        return points;
    }

    // Returns the point amount
    public AudioSource GetSound()
    {
        return engine;
    }

    [System.Serializable]
    public class AxleInfo
    {
        public WheelCollider leftWheelW, rightWheelW;
        public Transform leftWheelT, rightWheelT;
        public bool motor;      // motor attached to wheel
        public bool steering;   // steer angle attached to wheel
    }
}
