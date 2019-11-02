using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraView : MonoBehaviour
{
    public Camera firstPersonCamera;
    public Camera overheadCamera;

    // Start is called before the first frame update
    void Start()
    {
        firstPersonCamera.enabled = true;
        overheadCamera.enabled = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ShowOverheadView();
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            ShowFirstPersonView();
        }
    }

    public void ShowOverheadView()
    {
        firstPersonCamera.enabled = false;
        overheadCamera.enabled = true;
    }

    public void ShowFirstPersonView()
    {
        firstPersonCamera.enabled = true;
        overheadCamera.enabled = false;
    }
}
