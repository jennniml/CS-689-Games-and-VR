using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play : MonoBehaviour
{
	void Start()
	{
		Pause();
	}

	void Pause()
	{
		Time.timeScale = 0;
	}

	public void UnPause()
	{
		Time.timeScale = 1;
	}
}
