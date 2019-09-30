using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject carPlayer;
    //private Vector3 offset;
    private float carX, carY, carZ;

    // Start is called before the first frame update
    void Start()
    {
        //offset = transform.position - carPlayer.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //transform.position = carPlayer.transform.position + offset;
    }

    private void Update()
    {
        carX = carPlayer.transform.eulerAngles.x;
        carY = carPlayer.transform.eulerAngles.y;
        carZ = carPlayer.transform.eulerAngles.z;

        transform.eulerAngles = new Vector3(carX-carX, carY, carZ-carZ);
    }
}
