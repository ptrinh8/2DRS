using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	private float enemyLaunchRate = .5f;
	public float timer;
	public int health = 50;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		//InvokeRepeating("LaunchEnemy", 3f, 3f);
		if (health <= 0)
		{
			this.gameObject.SetActive(false);
		}
	
	}

	void FixedUpdate()
	{
		timer += Time.deltaTime;

		if (timer >= enemyLaunchRate)
		{
			LaunchEnemy();
			timer = 0f;
		}
	}

	void LaunchEnemy()
	{
		GameObject enemy = EnemyPooler.current.GetPooledObject();

		if (enemy == null)
		{
			return;
		}

		enemy.transform.position = transform.position;
		enemy.transform.rotation = transform.rotation;
		enemy.SetActive(true);
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.name == "Bullet(Clone)")
		{
			collision.gameObject.SetActive(false);
			health--;
		}
	}
}
