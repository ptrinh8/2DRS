using UnityEngine;
using System.Collections;

public class EnemyStraightScript : MonoBehaviour {
	
	private Transform player;
	private int speed = 7;
	private int minimumDistance = 0;
	private int maximumDistance;
	private Vector2 velocity;
	
	public Vector2 heading;
	
	// Use this for initialization
	void Start () {
		
		player = GameObject.Find("Player").GetComponent<Transform>();
		heading = player.transform.position - this.transform.position;
		heading.Normalize();
		
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
				gameObject.SetActive(false);
				collision.gameObject.SetActive(false);
			}
		}
	}
}
