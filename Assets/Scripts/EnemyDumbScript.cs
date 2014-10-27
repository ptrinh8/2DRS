using UnityEngine;
using System.Collections;

public class EnemyDumbScript : MonoBehaviour {
	
	private Transform player;
	private int speed = 10;
	private int minimumDistance = 0;
	private int maximumDistance;
	private Vector2 velocity;
	private Camera theCamera;
	
	public Vector2 heading;
	public Vector2 force;

	private PlayerController playerController;


	// Use this for initialization
	void Start () {
		
		player = GameObject.Find("Player").GetComponent<Transform>();
		theCamera = GameObject.Find ("Main Camera").GetComponent<Camera>();
		playerController = GameObject.Find ("Player").GetComponent<PlayerController>();
		//heading = new Vector2(0, 0);
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (this.gameObject.activeInHierarchy == true)
		{
			force = heading * speed;
			this.rigidbody2D.AddForce(force);
		}


		if (playerController.gameObject.activeInHierarchy == false)
		{
			this.gameObject.SetActive(false);
		}
		/*
		if (this.gameObject.transform.position.y > theCamera.orthographicSize)
		{
			gameObject.SetActive(false);
		}
		else if (this.gameObject.transform.position.y < theCamera.orthographicSize * -1)
		{
			gameObject.SetActive(false);
		}
		else if (this.gameObject.transform.position.x > theCamera.orthographicSize * theCamera.aspect)
		{
			gameObject.SetActive(false);
		}*/
		
	}
	
	void OnTriggerEnter2D(Collider2D collision)
	{
		//Debug.Log (collision);
		if (this.gameObject.activeInHierarchy == true)
		{
			if (collision.gameObject.name == "Bullet(Clone)")
			{
				EmitParticles ();
				gameObject.SetActive(false);
				collision.gameObject.SetActive(false);
			}

			if (collision.gameObject.name == "Player")
			{
				EmitParticles();
				playerController.health--;
				gameObject.SetActive(false);
			}
		}
	}
	void EmitParticles()
	{
		GameObject obj = ParticleSystemPooler.current.GetPooledObject();
		
		if (obj == null)
		{
			return;
		}
		
		if (obj.gameObject.name == "ParticleSystem(Clone)")
		{
			obj.transform.position = transform.position;
			obj.SetActive(true);
			obj.particleSystem.Play();
		}
	}

	void OnBecameInvisible()
	{
		gameObject.SetActive(false);
	}
}
