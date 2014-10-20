using UnityEngine;
using System.Collections;

public class EnemyStraightScript : MonoBehaviour {
	
	private Transform player;
	private int speed = 15;
	private int minimumDistance = 0;
	private int maximumDistance;
	private Vector2 velocity;
	private Camera theCamera;
	
	public Vector2 heading;

	public ParticleSystem particles;
	
	// Use this for initialization
	void Start () {
		
		player = GameObject.Find("Player").GetComponent<Transform>();
		theCamera = GameObject.Find ("Main Camera").GetComponent<Camera>();
		heading = player.transform.position - this.transform.position;
		heading.Normalize();
		particles = GetComponent<ParticleSystem>();

		
	}
	
	// Update is called once per frame
	void Update () {

		if (this.gameObject.activeInHierarchy == true)
		{
			rigidbody2D.velocity = heading * speed;
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

	void OnEnable()
	{
		player = GameObject.Find("Player").GetComponent<Transform>();
		heading = player.transform.position - this.transform.position;
		heading.Normalize();
	}

	void OnBecameInvisible()
	{
		gameObject.SetActive(false);
	}
}
