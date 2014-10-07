using UnityEngine;
using System.Collections;

public class EnemyFollowScript : MonoBehaviour {

	private Transform player;
	private int speed = 10;
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
				gameObject.SetActive(false);
				collision.gameObject.SetActive(false);
			}
		}
	}
}
