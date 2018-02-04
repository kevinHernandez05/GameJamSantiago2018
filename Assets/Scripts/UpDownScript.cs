using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownScript : MonoBehaviour 
{
	public GameObject Up;
	public GameObject Down;
	public bool upActive;
	public bool downActive;
	private bool isPressed;

	void Update ()
	{
		if (Input.GetButtonDown ("Fire1") && !isPressed) 
		{
			if (upActive) 
			{
				activarAbajo ();
				upActive = false;
				downActive = true;
			} 
			else if (downActive) 
			{
				activarArriba();
				upActive = true;
				downActive = false;					
			}	

			isPressed = true;
		} 

		else if (Input.GetButtonUp ("Fire1")) 
		{
			isPressed = false;	
		}
	}

	void activarArriba()
	{
		Up.SetActive (true);
		Down.SetActive (false);
	}

	void activarAbajo()
	{
		Up.SetActive (false);
		Down.SetActive (true);
	}
}

