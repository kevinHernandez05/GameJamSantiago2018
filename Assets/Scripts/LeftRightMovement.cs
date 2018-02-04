using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRightMovement : MonoBehaviour 
{
	private Transform platform;
	public float max, current, doblador;
	public bool left, right, isPressed;
	//private Rigidbody2D rb;
	public bool isHorizontal, isVertical;
	public float move;

	void Start()
	{
		if (left && !right)
			doblador = -1;
		
		else if (right && !left)
			doblador = 1;

		//rb = GetComponent<Rigidbody2D> ();
		platform = GetComponent<Transform>();
	}

	void Update()
	{
		if (Input.GetButtonDown ("Fire1") && !isPressed) 
		{
			if (left) 
			{
				left = false;
				right = true;
				doblador = -1;
			} 

			else if (right) 
			{
				left = true;
				right = false;
				doblador = 1;
			}	

			isPressed = true;
		} 

		else if (Input.GetButtonUp ("Fire1"))
			isPressed = false;

		if (isHorizontal) 
		{
			if (left && current > 0f) 
			{
				--current;
				platform.Translate (move*doblador, 0f, 0f);
			} 

			else if (current <= 0)
				platform.Translate (new Vector3 (0f,0f, 0f));

			if (right && current < max) 
			{
				++current;
				platform.Translate (move*doblador, 0f, 0f);
			}

			else if(current >= max)
				platform.Translate (new Vector3 (0f,0f));
		}

		if (isVertical) 
		{
			if (left && current > 0f) 
			{
				--current;
				platform.Translate (0f, move*doblador, 0f);
			} 

			else if (current <= 0)
				platform.Translate (0f, 0f, 0f);

			if (right && current < max) 
			{
				++current;
				platform.Translate (0f, move*doblador, 0f);
			}

			else if(current >= max)
				platform.Translate (0f, 0f, 0f);
		}
	}

}

