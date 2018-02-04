using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	//Public
	public GameObject Player;
	public float velocity;
	public Vector3 targetDis;
	public string AnimacionCaminar;
	public string AnimacionAtaque;

	//Private
	private Rigidbody2D rb;
	private float h;
	private bool seen;
	private SpriteRenderer sprite;
	private Animator anim;

	void Start()
	{
		rb = GetComponent<Rigidbody2D> ();
		seen = false;
		sprite = GetComponent<SpriteRenderer> ();
		anim = GetComponent<Animator> ();
	}

	void Update()
	{
		//...girar en su propio eje dependiendo de la posicion del jugador...
		transform.localScale = new Vector3 (Mathf.Sign (h) * Mathf.Abs (transform.localScale.x), transform.localScale.y, transform.localScale.z);

		//...distancia entre el jugador y el enemigo...
		targetDis = Player.transform.position - transform.position;	

		if (targetDis.x < 0) 
		{
			h = -1;
			sprite.flipX = true;
		}
		else 
		{
			h = 1;
		}

		//...Si la distancia del enemigo es mayor que 5 o menor que -5 en su eje x...
		if (targetDis.x > 5 || targetDis.x < -5)
			anim.Play (AnimacionCaminar);
		else
			anim.Play (AnimacionAtaque);

	}

	void FixedUpdate()
	{
		//if (seen)
			rb.velocity = new Vector2 (h * velocity, rb.velocity.y);
	}

	/*void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player") 
		{
			seen = true;
		}
	}*/
}
