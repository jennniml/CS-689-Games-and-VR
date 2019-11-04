using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraView : MonoBehaviour
{
    public Camera firstPersonCamera;
    public Camera overheadCamera;
    public Camera engineerCamera;

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
        else if (Input.GetKeyDown(KeyCode.I))
        {
            ShowEngineerView();
        }
    }

    public void ShowOverheadView()
    {
        firstPersonCamera.enabled = false;
        overheadCamera.enabled = true;
        engineerCamera.enabled = false;
    }

    public void ShowFirstPersonView()
    {
        firstPersonCamera.enabled = true;
        overheadCamera.enabled = false;
        engineerCamera.enabled = false;
    }

    public void ShowEngineerView()
    {
        firstPersonCamera.enabled = false;
        overheadCamera.enabled = false;
        engineerCamera.enabled = true;
    }
}
