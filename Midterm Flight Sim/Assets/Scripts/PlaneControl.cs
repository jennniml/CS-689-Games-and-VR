using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneControl : MonoBehaviour
{
//Rotation und Position unseres Flugzeugs. || Rotaton and position of our airplane
    float rotationx = 0, rotationy = 0, rotationz = 0;
    float positionx=0.0f, positiony=0.0f, positionz=0.0f;

    float speed=0.0f;// speed Variable gibt die Geschwindigkeit an || speed variable is the speed
    float uplift=0.0f;

    void Update()
    {
        //Maincode flying ----------------------------------------------------------------------------------------------------------------------------------

            // Drehungen des Flugzeugs || Rotations of the airplane
            if (speed > 595) transform.Rotate(Input.GetAxis("Vertical") * Time.deltaTime * 100, 0, 0); //Hoch Runter, limitiert auf eine Minimalgeschwindigkeit || Up Down, limited to a minimum speed
            transform.Rotate(0, Input.GetAxis("Horizontal") * Time.deltaTime * 100, 0, Space.World); //Rechts Links || Left Right
            if (groundtrigger.triggered == 0) transform.Rotate(0, 0, Input.GetAxis("Horizontal") * Time.deltaTime * 50 * -1); //Seitenneigung. Mal Minus 1 um in die richtige Richtung zu drehen || Tilt multiplied with minus 1 to go into the right direction

            //Seitenneigung limitieren damit flugzeug in Kurve keine Rolle schlägt || limit tilt so that airplane doesn`t fly a roll while flying a curve
            if ((Input.GetAxis("Horizontal") < 0) && (rotationz > 45) && (rotationz < 90)) transform.Rotate(0, 0, Time.deltaTime * -50);//linksrum || to the left
            if ((Input.GetAxis("Horizontal") > 0) && (rotationz < 315) && (rotationz > 270)) transform.Rotate(0, 0, Time.deltaTime * 50);//rechtsrum ||to the right

            // Geschwindigkeit || Speed
            transform.Translate(0, 0, speed / 20 * Time.deltaTime);


            //Variablen auf Position und Rotation des Objekts einstellen || Turn variables to rotation and position of the object
            rotationx = transform.eulerAngles.x;
            rotationy = transform.eulerAngles.y;
            rotationz = transform.eulerAngles.z;
            positionx = transform.position.x;
            positiony = transform.position.y;
            positionz = transform.position.z;


            //Zurückdrehen Z Achse. Limitiert auf Horizontal Button ist nicht gedrückt|| Rotate back in z axis , limited by no horizontal button pressed
            if ((rotationz > 0) && (rotationz < 90) && (!Input.GetButton("Horizontal"))) transform.Rotate(0, 0, Time.deltaTime * -50);
            if ((rotationz > 0) && (rotationz > 270) && (!Input.GetButton("Horizontal"))) transform.Rotate(0, 0, Time.deltaTime * 50);
            if ((rotationz > 180) && (rotationz < 270) && (!Input.GetButton("Horizontal"))) transform.Rotate(0, 0, Time.deltaTime * -50);
            if ((rotationz < 180) && (rotationz > 90) && (!Input.GetButton("Horizontal"))) transform.Rotate(0, 0, Time.deltaTime * 50);

            //Zurückdrehen X Achse || Rotate back X axis

            if ((rotationx > 0) && (rotationx < 180) && (!Input.GetButton("Vertical"))) transform.Rotate(Time.deltaTime * -50, 0, 0);
            if ((rotationx > 0) && (rotationx > 180) && (!Input.GetButton("Vertical"))) transform.Rotate(Time.deltaTime * 50, 0, 0);


            //Geschwindigkeit Fahren und Fliegen || Speed driving and flying ------------------------------------------------------------------------------------------
            //Wir brauchen ein minimales Geschwindigkeitslimit in der Luft. Wir limitieren wieder mit der groundtrigger.triggered Variable
            //We need a minimum speed limit in the air. We limit again with the groundtrigger.triggered variable

            // Input Gas geben und abbremsen am Boden|| Input Accellerate and deccellerate at ground
            if ((groundtrigger.triggered == 1) && (Input.GetButton("Fire1")) && (speed < 800)) speed += Time.deltaTime * 240;
            if ((groundtrigger.triggered == 1) && (Input.GetButton("Fire2")) && (speed > 0)) speed -= Time.deltaTime * 240;

            // Input Gas geben und abbremsen in der Luft|| Input Accellerate and deccellerate in the air
            if ((groundtrigger.triggered == 0) && (Input.GetButton("Fire1")) && (speed < 800)) speed += Time.deltaTime * 240;
            if ((groundtrigger.triggered == 0) && (Input.GetButton("Fire2")) && (speed > 600)) speed -= Time.deltaTime * 240;

            //Auftrieb  -------------------------------------------------------------------------------------------------------------------------------------------------------
            //Wenn in der Luft weder Gasgeben noch Abbremsen gedrückt wird soll unser Flugzeug auf eine neutrale Geschwindigkeit gehen. Mit dieser Geschwindigkeit soll es auch neutral in der Höhe bleiben. Drüber soll es steigen, drunter soll es sinken. Auf diesem Wege lässt sich dann abheben und landen
            //When we don`t accellerate or deccellerate we want to go to a neutral speed in the air. With this speed it has to stay at a neutral height. Above this value the airplane has to climb, with a lower speed it has to  sink. That way we are able to takeoff and land then.

            //Neutrale Geschwindigkeit bei 700 || Neutral speed at 700
            //Dieser Code stellt in der Luft die Geschwindigkeit auf 700 zurück wenn nicht gasgegeben oder abgebremst wird. Maximum 800, minimum 600
            //This code resets the speed to 700 when there is no acceleration or deccelleration. Maximum 800, minimum 600
            if ((Input.GetButton("Fire1") == false) && (Input.GetButton("Fire2") == false) && (speed > 595) && (speed < 700)) speed += Time.deltaTime * 240;
            if ((Input.GetButton("Fire1") == false) && (Input.GetButton("Fire2") == false) && (speed > 595) && (speed > 700)) speed -= Time.deltaTime * 240;


            //uplift - Auftrieb
            transform.Translate(0, uplift * Time.deltaTime / 10.0f, 0);

            //Uplift kalkulieren. Der Auftrieb || Calculate uplift
            uplift = -700 + speed;
            //Wir wollen am Boden keinen Abtrieb. Wenn die Uplift am Boden kleiner 0 ist, setzen wir sie auf 0. We don`t want downlift. So when the uplift value lower zero we set it to 0
            if ((groundtrigger.triggered == 1) && (uplift < 0)) uplift = 0;
        
    }


    /*
    private Rigidbody rb;
    private Vector3 lift;
    public float enginePower=40, liftBooster=0.2f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 moveCamTo = transform.position - transform.forward * 15.0f + Vector3.up * 10.0f;
        Camera.main.transform.position = moveCamTo;
        Camera.main.transform.LookAt(transform.position);
    }

    private void FixedUpdate()
    {
        MovePlane();
    }

    void MovePlane()
    {
        //Add force from jet engine , set enginePower to 15000
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(transform.forward * enginePower);
        }

        //Add lift force ,  set liftBooster to 100 
        lift = Vector3.Project(rb.velocity, transform.forward);
        rb.AddForce(transform.up * lift.magnitude * liftBooster);

        //Banking controls, turning turning left and right on Z axis
        rb.AddTorque(Input.GetAxis("Horizontal") * transform.forward * -1f);

        //Pitch controls, turning the nose up and down
        rb.AddTorque(-Input.GetAxis("Vertical") * transform.right);

        //Set drag and angular drag according relative to speed
        rb.drag = 0.001f * rb.velocity.magnitude;
        rb.angularDrag = 0.01f * rb.velocity.magnitude;
    }*/
}
