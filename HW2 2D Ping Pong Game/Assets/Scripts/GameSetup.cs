using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetup : MonoBehaviour
{
    public Camera mainCam;
    public BoxCollider2D topWall, bottomWall, leftWall, rightWall;
    public Transform playerLeft, playerRight;

    // Start is called before the first frame update
    void Update()
    {
        // Move each wall to edge location
        topWall.size = new Vector2(mainCam.ScreenToWorldPoint(
            new Vector3(Screen.width * 1.5f, 0f, 0f)).x, 1f);
        topWall.offset = new Vector2(0f, mainCam.ScreenToWorldPoint(
            new Vector3(0f, Screen.height, 0f)).y + 0.5f);

        bottomWall.size = new Vector2(mainCam.ScreenToWorldPoint(
            new Vector3(Screen.width * 1.5f, 0f, 0f)).x, 1f);
        bottomWall.offset = new Vector2(0f, mainCam.ScreenToWorldPoint(
            new Vector3(0f, 0f, 0f)).y - 0.5f);

        leftWall.size = new Vector2(1f, mainCam.ScreenToWorldPoint(
            new Vector3(0f, Screen.height * 1.5f, 0f)).y);
        leftWall.offset = new Vector2(mainCam.ScreenToWorldPoint(
            new Vector3(0f, 0f, 0f)).x - 0.5f, 0f);

        rightWall.size = new Vector2(1f, mainCam.ScreenToWorldPoint(
            new Vector3(0f, Screen.height * 1.5f, 0f)).y);
        rightWall.offset = new Vector2(mainCam.ScreenToWorldPoint(
            new Vector3(Screen.width, 0f, 0f)).x + 0.5f, 0f);
    }

}
