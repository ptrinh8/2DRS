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

	// Use this for initialization
	void Start () {

		player = GameObject.Find("Player").GetComponent<Transform>();
	
	}
	
	// Update is called once per frame
	void Update () {


		heading = player.transform.position - this.transform.position;
		heading.Normalize();

		if (this.gameObject.activeInHierarchy == true)
		{
			force = heading * speed;
			this.rigidbody2D.AddForce(force);
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
				EmitParticles();
				gameObject.SetActive(false);
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
