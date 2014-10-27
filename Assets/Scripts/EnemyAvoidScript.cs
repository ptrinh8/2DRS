using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyAvoidScript : MonoBehaviour {
	
	private Transform player;
	private int speed = 5;
	private int minimumDistance = 0;
	private int maximumDistance;
	private Vector2 velocity;

	private bool avoiding = false;
	
	public Vector2 heading;
	public Vector2 force;
	public Vector2 normal;

	private GameObject nearestBullet;

	private PlayerController playerController;

	List<GameObject> bulletPool;
	

	// Use this for initialization
	void Start () {
		
		player = GameObject.Find("Player").GetComponent<Transform>();
		bulletPool = GameObject.Find ("BulletPooler").GetComponent<BulletPooler>().pooledObjects;
		playerController = GameObject.Find ("Player").GetComponent<PlayerController>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (this.gameObject.activeInHierarchy == true)
		{
			/*
			for (int i = 0; i < bulletPool.Count; i++)
			{
				if (bulletPool[i].activeInHierarchy == true)
				{
					if (Vector2.Distance(this.transform.position, bulletPool[i].transform.position) < 8f)
					{
						Vector2 normalCalc = bulletPool[i].transform.position - this.transform.position;
						if (Random.value > .5f)
						{
							normal = new Vector2(normalCalc.y * -1, normalCalc.x);
						}
						else
						{
							normal = new Vector2(normalCalc.y, normalCalc.x * -1);
						}
						normal.Normalize();
						avoiding = true;
					}
					else
					{
						avoiding = false;
					}

				}
			}*/

			nearestBullet = LookForClosestBullet();
			if (nearestBullet != null)
			{
				if (Vector2.Distance(this.transform.position, nearestBullet.transform.position) < 8f)
				{
					Vector2 normalCalc = nearestBullet.transform.position - this.transform.position;
					if (Random.value > .5f)
					{
						normal = new Vector2(normalCalc.y * -1, normalCalc.x);
					}
					else
					{
						normal = new Vector2(normalCalc.y, normalCalc.x * -1);
					}
					normal.Normalize();
					avoiding = true;
				}
				else
				{
					avoiding = false;
				}
			}

			if (avoiding == true)
			{
				force = normal * 15f;
				this.rigidbody2D.AddForce(force);
			}
			else
			{
				heading = player.transform.position - this.transform.position;
				heading.Normalize();
				force = heading * speed;
				this.rigidbody2D.AddForce(force);
			}
		}

		if (playerController.alive == false)
		{
			this.gameObject.SetActive(false);
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
		nearestBullet = null;
		avoiding = false;
		force = Vector2.zero;
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

	private GameObject LookForClosestBullet()
	{
		GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
		GameObject closestBullet = null;
		if (bullets.Length >= 1)
		{
			for (int i = 0; i < bullets.Length; i++)
			{
				float distanceBetweenObjects = Vector2.Distance(this.transform.position, bullets[i].transform.position);
				if (closestBullet != null)
				{
					if (distanceBetweenObjects < Vector2.Distance(this.transform.position, closestBullet.transform.position))
					{
						closestBullet = bullets[i];
					}
					else
					{
						closestBullet = bullets[0];
					}
				}
				else
				{
					closestBullet = bullets[i];
				}
			}
			return closestBullet;
		}
		else
		{
			return null;
		}
	}
	
	void OnBecameInvisible()
	{
		gameObject.SetActive(false);
	}
}
