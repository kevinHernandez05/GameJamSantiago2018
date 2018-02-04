using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour 
{

	//Singleton
	public static PlayerController Instance;

	//Public

	public float vida;
	public string nombre;
	public float force;

	//private 
	private float h, v;
	private bool isCorriendo;
	private Rigidbody2D rb;
	private SpriteRenderer sprite;
	private Animator anim;

	void Start () 
	{
		rb = GetComponent<Rigidbody2D> ();
		sprite = GetComponent<SpriteRenderer> ();
		anim = GetComponent<Animator> ();
		Instance = this;
	}

	void Update ()
	{
		//...Monitoreo de Axis...

		h = Input.GetAxis ("Horizontal");
		v = Input.GetAxis ("Vertical");

		//...Seccion de correr...
		if (Input.GetButton ("Fire2")) 
		{
			isCorriendo = true;
		}
		else
		{
			isCorriendo = false;
		}

	}

	void FixedUpdate()
	{
		//...horizontal...
		if (h != 0) 
		{
			//...Gira en su eje X a la izquierda o derecha...
			transform.localScale = new Vector3 (Mathf.Sign (h) * Mathf.Abs (transform.localScale.x), transform.localScale.y, transform.localScale.z);

			//...movimiento del personaje caminando eje X...
			if (!isCorriendo) 
			{
				rb.velocity = new Vector2 (h * force, rb.velocity.y);
				anim.Play ("RobotBoyWalk");
			}

			//...movimiento del personaje corriendo...
			else 
			{
				rb.velocity = new Vector2 ((h * force) + ((h * force) * 0.5f), rb.velocity.y);
				anim.Play ("RobotBoyRun");
			}
		}

		else if (v != 0) 
		{
			//...movimiento del personaje caminando; eje Y...
			if (!isCorriendo) 
			{
				rb.velocity = new Vector2 (rb.velocity.x, v * force);
				anim.Play ("RobotBoyWalk");
			}

			//...movimiento del personaje corriendo...
			else 
			{
				rb.velocity = new Vector2 (rb.velocity.x, (v * force) + ((v * force) * 0.5f));
				anim.Play ("RobotBoyRun");
			}
		}

		//...Si no se esta presionando ningun boton...

		if(v == 0 && h == 0)
		{
			rb.velocity = Vector2.zero;
			anim.Play ("RobotBoyIdle");
		}
	}
} 
