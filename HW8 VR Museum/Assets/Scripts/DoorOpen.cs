using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    Animator m_Animator;

    // Start is called before the first frame update
    void Start()
    {
        //Fetch the Animator from your GameObject
        m_Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AnimateDoor()
    {
        m_Animator.Play("Door_open");
        Invoke("PlaySound", 1);
    }

    void PlaySound()
    {
        GetComponent<AudioSource>().Play();
    }
}
