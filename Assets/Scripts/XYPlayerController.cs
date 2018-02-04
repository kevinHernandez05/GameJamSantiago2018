using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class XYPlayerController : MonoBehaviour 
{
	//Singleton
	public static XYPlayerController Instance;

	//Public
	public float vida;
	public string nombre;
	public float force;
	public float jumpForce;
	public GameObject GroundCheck;
	public Transform startPoint;
	public AudioSource[] jumps;
	public AudioSource[] Taunts;


	//private 
	private float h, v;
	private bool isCorriendo;
	private Rigidbody2D rb;
	private SpriteRenderer sprite;
	private Animator anim;
	private Transform Ground;
	private bool isOnFloor;
	private bool jump;
	private bool isOnPlatform;
	private bool isCintaMangada;
	private bool isUsingPawa;
	private bool moving;

	void Start () 
	{
		rb = GetComponent<Rigidbody2D> ();
		sprite = GetComponent<SpriteRenderer> ();
		anim = GetComponent<Animator> ();
		Instance = this;
		isOnFloor = false;
		isUsingPawa = false;

	}

	void Update ()
	{
		//...Monitoreo de Axis...
		h = Input.GetAxis ("Horizontal");
		v = Input.GetAxis ("Vertical");

		//...Esta en el suelo?...
		isOnFloor = Physics2D.Linecast(transform.position, GroundCheck.transform.position, 1 << LayerMask.NameToLayer("Floor"));

		//...esta en una plataforma?...
		isOnPlatform = Physics2D.Linecast(transform.position, GroundCheck.transform.position, 1 << LayerMask.NameToLayer("Platform"));

		//..se presiona boton de salto y se esta en el suelo?...
		if (Input.GetButtonDown ("Fire3") && isOnFloor)
			jump = true;
		
		//...Seccion de correr...

		if (Input.GetButton ("Fire2")) 
		{
			isCorriendo = true;
		}
		else
		{
			isCorriendo = false;
		}

		//seccion de carga de poder
		if (Input.GetButton ("Fire1")) 
		{
			isUsingPawa = true;
			Taunts [Random.Range (0, Taunts.Length)].Play ();
		} 
		else 
		{
			isUsingPawa = false;
		}
	}

	void FixedUpdate()
	{
		//...horizontal...
		if (h != 0) 
		{
			//...Gira en su eje izquierda o derecha...
			transform.localScale = new Vector3 (Mathf.Sign (h) * Mathf.Abs (transform.localScale.x), transform.localScale.y, transform.localScale.z);

			//...movimiento del personaje caminando eje X...
			if (!isCorriendo && !isOnFloor) 
			{
				rb.velocity = new Vector2 (h * force, rb.velocity.y);
				anim.Play ("Jumping");
			}

			//...movimiento del personaje corriendo...
			else 
			{
				rb.velocity = new Vector2 ((h * force) + ((h * force) * 0.5f), rb.velocity.y);
				anim.Play ("BobRunning");
			}
		}
	
		//Seccion de salto

		if (jump) 
		{
			jumps [Random.Range (0, jumps.Length)].Play (); //se reproduce un sonido aleatorio
			rb.AddForce (new Vector2(0f, jumpForce));
			anim.Play ("Jumping");
			jump = false;
		}

		//...Si no se esta presionando ningun boton...

		if(v == 0 && h == 0)
		{
			rb.velocity = new Vector2(0f, rb.velocity.y);
			
			if (!isOnFloor)
				anim.Play ("Jumping");
			else if (isOnFloor && isUsingPawa) 
			{
				rb.velocity = Vector2.zero;	
				anim.Play ("Power");
			}
			else
				anim.Play ("Idle");
		}
	}

	//...Game Trigger Collider...
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Floor")
			isOnFloor = true;
		else
			isOnFloor = false;

	}

	//...Game Collider...
	void OnCollisionStay2D(Collision2D col)
	{
		if (col.gameObject.tag == "Cinta") 
		{
			Destroy (col.gameObject);
			isCintaMangada = true;
		}

		if(col.gameObject.tag == "Platform")
		{
			this.transform.SetParent(col.transform, true);
		}

	}

	void OnCollisionExit2D(Collision2D col)
	{
		if(col.gameObject.tag == "Platform")
		{
			this.transform.parent = null;
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		Collider2D collider = col.collider;

		if(col.gameObject.tag == "Enemy")
		{
			//transform.position = new Vector2(startPoint.position.x, startPoint.position.y);
			Application.LoadLevel(Application.loadedLevel);
		}

	}
}
