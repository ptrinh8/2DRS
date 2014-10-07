using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	private float enemyLaunchRate = .5f;
	private PlayerController player;
	public float timer;
	public int health = 50;
	private SpriteRenderer sprite;
	private MetronomeTimer metronome;
	private Vector3 scale;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player").GetComponent<PlayerController>();
		sprite = this.gameObject.GetComponent<SpriteRenderer>();
		metronome = GameObject.Find ("AudioSource").GetComponent<MetronomeTimer>();
		scale = this.transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {

		//InvokeRepeating("LaunchEnemy", 3f, 3f);
		if (health <= 0)
		{
			this.gameObject.SetActive(false);
		}

		if (this.transform.localScale.x >= .75f)
		{
			this.transform.localScale -= new Vector3(.02f, .02f, 0f);
		}
	
	}

	void FixedUpdate()
	{
		timer += Time.deltaTime;
		/*
		if (player.gameObject.activeInHierarchy)
		{
			if (timer >= enemyLaunchRate)
			{
				LaunchEnemy();
				timer = 0f;
			}
		}*/
	}

	public void LaunchEnemy(int enemyType)
	{
		if (enemyType == 1)
		{
			GameObject enemy = EnemyPooler.current.GetPooledObject();
			if (enemy == null)
			{
				return;
			}
			
			enemy.transform.position = transform.position;
			enemy.transform.rotation = transform.rotation;
			enemy.SetActive(true);
			this.transform.localScale = new Vector3(2f, 2f, 1f);
		}
		else if (enemyType == 2)
		{
			GameObject enemy = EnemyStraightPooler.current.GetPooledObject();
			if (enemy == null)
			{
				return;
			}
			
			enemy.transform.position = transform.position;
			enemy.transform.rotation = transform.rotation;
			enemy.SetActive(true);
			this.transform.localScale = new Vector3(2f, 2f, 1f);
		}
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
