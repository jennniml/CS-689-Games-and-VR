using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour
{
    GameObject[] pauseObjects;
    private bool firstTry;      // checks if 1st time playing game
    

    // Use this for initialization
    void Start()
    {
        firstTry = true;
        Time.timeScale = 0;
        pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
        hidePaused();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // Stops the game
    public void FinishControl()
    {
        firstTry = false;
        Time.timeScale = 0;
        showPaused();
    }

    // Starts the game (Start)
    public void StartControl()
    {
        if (!firstTry)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
        Time.timeScale = 1;
        hidePaused();
    }

    //shows objects with ShowOnPause tag
    public void showPaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(true);
        }
    }

    //hides objects with ShowOnPause tag
    public void hidePaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(false);
        }
    }

}
