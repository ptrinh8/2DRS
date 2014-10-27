using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	private float enemyLaunchRate = .5f;
	private PlayerController player;
	public float timer;
	public int health;
	private SpriteRenderer sprite;
	private MetronomeTimer metronome;
	private Vector3 scale;
	private Vector2 position;
	private float enemyHeading;
	private EnemyDumbScript enemyDumb;
	public float angle;
	public Color instrumentColor;
	private Camera theCamera;

	public bool killedOnce = false;

	public bool colorWorks = false;

	private SongScript songScript;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player").GetComponent<PlayerController>();
		sprite = this.gameObject.GetComponent<SpriteRenderer>();
		metronome = GameObject.Find ("AudioSource").GetComponent<MetronomeTimer>();
		scale = this.transform.localScale;
		position = this.transform.position;
		health = 100;
		enemyHeading = 0;
		theCamera = GameObject.Find ("Main Camera").GetComponent<Camera>();
		songScript = GameObject.Find ("SongScript").GetComponent<SongScript>();
	}
	
	// Update is called once per frame
	void Update () {

		//InvokeRepeating("LaunchEnemy", 3f, 3f);
		if (health <= 0)
		{
			player.spawnsKilled++;
			killedOnce = true;
			this.gameObject.SetActive(false);
		}

		if (this.transform.localScale.x >= 1f)
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
		LaunchEnemy(enemyType, 1);
	}

	public void LaunchEnemy(int enemyType, int numberOfEnemies)
	{
		if (this.gameObject.activeInHierarchy)
		{
			if (enemyType == 1)
			{
				for (int i = 0; i < numberOfEnemies; i++)
				{
					GameObject enemy = EnemyFollowPooler.current.GetPooledObject();
					if (enemy == null)
					{
						return;
					}
					
					enemy.transform.position = position;
					enemy.transform.rotation = transform.rotation;
					enemy.SetActive(true);
					position = new Vector2((this.transform.position.x + (Random.Range(-1, 1) * .75f)), (this.transform.position.y + (Random.Range(-1, 1) * .75f)));
				}
			}
			else if (enemyType == 2)
			{
				position = new Vector2(this.transform.position.x, this.transform.position.y);
				for (int i = 0; i < numberOfEnemies; i++)
				{
					GameObject enemy = EnemyStraightPooler.current.GetPooledObject();
					if (enemy == null)
					{
						return;
					}
					
					enemy.transform.position = position;
					enemy.transform.rotation = transform.rotation;
					enemy.SetActive(true);
					position = new Vector2((this.transform.position.x + (Random.Range(-1, 1) * .75f)), (this.transform.position.y + (Random.Range(-1, 1) * .75f)));
				}
			}
			else if (enemyType == 3)
			{
				/*angle = 360f / (float)numberOfEnemies;
				enemyHeading = 0;*/
				for (int i = 0; i < numberOfEnemies; i++)
				{
					GameObject enemy = EnemyDumbPooler.current.GetPooledObject();
					enemyDumb = enemy.GetComponent<EnemyDumbScript>();
					if (enemy == null)
					{
						return;
					}
					
					enemy.transform.position = transform.position;
					enemy.transform.rotation = transform.rotation;
					//enemyDumb.heading = new Vector2(0, 1);
					enemy.SetActive(true);

					//take angle
					if (enemyHeading > 360)
					{
						enemyHeading = enemyHeading - 360;
					}

					enemyDumb.heading = new Vector2(Mathf.Cos(enemyHeading * (180f / Mathf.PI)), Mathf.Sin(enemyHeading * (180f / Mathf.PI)));
					enemyHeading += 360f / (float)numberOfEnemies;
					//convert to radians -- radians = angle * (pi / 180)
					//convert radians to unit vector
					//u = cosine(radians), sine (radians)

				}
			}
			else if (enemyType == 4)
			{
				for (int i = 0; i < numberOfEnemies; i++)
				{
					GameObject enemy = EnemyAvoidPooler.current.GetPooledObject();
					if (enemy == null)
					{
						return;
					}
					
					enemy.transform.position = position;
					enemy.transform.rotation = transform.rotation;
					enemy.SetActive(true);
					position = new Vector2((this.transform.position.x + (Random.Range(-1, 1) * .75f)), (this.transform.position.y + (Random.Range(-1, 1) * .75f)));
				}
			}
			this.transform.localScale = new Vector3(3f, 3f, 1f);
			if (colorWorks == true)
			{
				theCamera.backgroundColor = instrumentColor;
				songScript.cameraColor = instrumentColor;
			}
		}
		else
		{
			return;
		}

		position = this.transform.position;

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
