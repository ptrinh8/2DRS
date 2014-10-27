using UnityEngine;
using System.Collections;

public class EnemyFollowScript : MonoBehaviour {

	private Transform player;
	private int speed = 5;
	private int minimumDistance = 0;
	private int maximumDistance;
	private Vector2 velocity;

	public Vector2 heading;
	public Vector2 force;

	private PlayerController playerController;


	// Use this for initialization
	void Start () {

		player = GameObject.Find("Player").GetComponent<Transform>();
		playerController = GameObject.Find ("Player").GetComponent<PlayerController>();
	
	}
	
	// Update is called once per frame
	void Update () {

		if (playerController.gameObject.activeInHierarchy == true)
		{
			player = GameObject.Find ("Player").GetComponent<Transform>();
		}
		heading = player.transform.position - this.transform.position;
		heading.Normalize();

		if (this.gameObject.activeInHierarchy == true)
		{
			force = heading * speed;
			this.rigidbody2D.AddForce(force);

			if (playerController.alive == false)
			{
				this.gameObject.SetActive(false);
			}
		}
	

	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		//Debug.Log (collision);
		if (this.gameObject.activeInHierarchy == true)
		{
			if (collision.gameObject.name == "Bullet(Clone)")
			{
				EmitParticles();
				gameObject.SetActive(false);
				collision.gameObject.SetActive(false);
			}

			if (collision.gameObject.name == "Player")
			{
				if (playerController.alive == true && playerController.boosting == false)
				{
					EmitParticles();
					playerController.health--;
					gameObject.SetActive(false);
				}
			}
		}
	}


	void OnEnable()
	{
		player = GameObject.Find("Player").GetComponent<Transform>();
		heading = player.transform.position - this.transform.position;
		heading.Normalize();
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
