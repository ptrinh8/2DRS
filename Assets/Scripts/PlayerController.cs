using UnityEngine;
using System.Collections;

//[RequireComponent (typeof (CharacterController))]
public class PlayerController : MonoBehaviour {

	//Handling
	public float rotationSpeed = 450f;
	private float speed = 7.5f;
	//public float gravity = 20.0f;
	public float timer;

	private float bulletFireRate = .05f;
	private float deltaX;
	private float deltaY;
	private Vector3 direction;
	private Vector2 bulletDirection;
	private int bulletSpeed = 20;
	private float radialDeadZone = .25f;
	public int health = 3;
	public int spawnsKilled = 0;

	private float boostTimer;
	private float boostTime;
	private float boostRechargeTime = 1.5f;
	public float boostRechargeTimer;
	private Vector3 boostDirection = Vector3.zero;

	public float vertExtent;
	public float horzExtent;

	public float respawnTime = 1.5f;

	public bool boosting = false;
	public bool canBoost = true;

	public bool alive = true;
	public float respawnTimer;
	public Vector2 respawnPosition;

	private AudioSource shootingArp;

	private ParticleSystem particleSystem;
	//Components
	//private CharacterController controller;

	//System
	public Vector3 moveDirection = Vector3.zero;
	private bool gamePad;

	void Start () {
		//controller = GetComponent<CharacterController>();

		vertExtent = Camera.main.camera.orthographicSize;
		horzExtent = vertExtent * Screen.width / Screen.height;

		if (Input.GetJoystickNames().Length == 0) {
			gamePad = false;
		} else {
			gamePad = true;
		}

		boostTime = .5f;
		respawnTime = 3f;

		shootingArp = GameObject.Find ("ShootingArp").GetComponent<AudioSource>();

		particleSystem = this.GetComponent<ParticleSystem>();
	}
	
	void Update () {

		if (health <= 0)
		{
			alive = false;
		}

		if (alive == true)
		{
			if (particleSystem.isPlaying == true)
			{
				particleSystem.Stop ();
			}

			if (gamePad) 
			{
				moveDirection = new Vector3(Input.GetAxis("GamepadMoveHorizontal"), (-1 * Input.GetAxis("GamepadMoveVertical")), 0);

				deltaX = Input.GetAxis("GamepadAimHorizontal");
				deltaY = Input.GetAxis("GamepadAimVertical");
				direction = new Vector3(-deltaX, -deltaY, 0);

				boostRechargeTimer += Time.deltaTime;
				float angle = Mathf.Atan2(deltaY,deltaX) * 180/Mathf.PI + 90;
				
				if (canBoost == true)
				{
					if (Input.GetButtonDown("Button0"))
					{
						boosting = true;
						canBoost = false;
						boostRechargeTimer = 0;
						boostTimer = 0;
						boostDirection = moveDirection;
					}
				}
				else if (canBoost == false)
				{
					if (boostRechargeTimer >= boostRechargeTime)
					{
						canBoost = true;
					}
				}
				
				if (boosting == true)
				{
					boostTimer += Time.deltaTime;
					if (boostTimer <= boostTime)
					{
						speed = 25;
						moveDirection = boostDirection;
					}
					else
					{
						speed = 7.5f;
						boosting = false;
					}
					rigidbody2D.velocity = moveDirection * speed;
				}
				else
				{
					rigidbody2D.velocity = moveDirection * speed;
				}

				if (direction.magnitude > 0) {

					//angle = angle * 180/Mathf.PI + 90;
					if (direction.magnitude > radialDeadZone)
					{
						Vector3 targetRotation = new Vector3(0,0,angle);
						direction.Normalize();
						bulletDirection.x = direction.x * bulletSpeed;
						bulletDirection.y = direction.y * bulletSpeed;
						timer += Time.deltaTime;
						if (timer >= bulletFireRate)
						{
							FireBullet();
							timer = 0;
						}
						Debug.Log (angle);
						transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(targetRotation), 1f);
						shootingArp.volume = 1f;
					}
					else
					{
						timer = 0;
						shootingArp.volume = 0f;
					}

				}
				else
				{
					shootingArp.volume = 0f;
				}

			} 
			else 
			{
				moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);

				var v3 = Camera.main.ScreenToWorldPoint(Input.mousePosition);

				boostRechargeTimer += Time.deltaTime;

				if (Input.GetMouseButton(0))
				{
					timer += Time.deltaTime;
					Vector3 mouse = Camera.main.WorldToScreenPoint(transform.position);
					Vector3 direction = (Input.mousePosition - mouse).normalized;
					bulletDirection.x = direction.x * bulletSpeed;
					bulletDirection.y = direction.y * bulletSpeed;
					shootingArp.volume = 1f;
					if (timer >= bulletFireRate)
					{
						FireBullet();
						timer = 0;
					}
				}
				else
				{
					shootingArp.volume = 0f;
				}

				if (canBoost == true)
				{
					if (Input.GetMouseButton (1))
					{
						boosting = true;
						canBoost = false;
						boostRechargeTimer = 0;
						boostTimer = 0;
						boostDirection = moveDirection;
					}
				}
				else if (canBoost == false)
				{
					if (boostRechargeTimer >= boostRechargeTime)
					{
						canBoost = true;
					}
				}

				if (boosting == true)
				{
					boostTimer += Time.deltaTime;
					if (boostTimer <= boostTime)
					{
						speed = 15;
						moveDirection = boostDirection;
					}
					else
					{
						speed = 5;
						boosting = false;
					}
					rigidbody2D.velocity = moveDirection * speed;
				}
				else
				{
					rigidbody2D.velocity = moveDirection * speed;
				}

				transform.rotation = Quaternion.LookRotation(Vector3.forward, v3 - this.transform.position);
			}
		}
		else if (alive == false)
		{
			particleSystem.Play();
			this.GetComponent<SpriteRenderer>().enabled = false;
			rigidbody2D.velocity = new Vector2(0, 0);
			respawnTimer += Time.deltaTime;
			respawnPosition = transform.position;
			if (respawnTimer >= respawnTime)
			{
				RespawnPlayer();
			}
		}

		//rigidbody2D.velocity = moveDirection * speed;
	}

	void FireBullet()
	{
		GameObject obj = BulletPooler.current.GetPooledObject();
		
		if (obj == null)
		{
			return;
		}

		obj.transform.position = transform.position;
		obj.transform.rotation = transform.rotation;
		obj.SetActive(true);
		obj.rigidbody2D.velocity = bulletDirection;
	}

	void RespawnPlayer()
	{
		health = 3;
		transform.position = respawnPosition;
		GetComponent<SpriteRenderer>().enabled = true;
		respawnTimer = 0f;
		alive = true;
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		//Debug.Log ("hit");
		if (collision.gameObject.name == "EnemyFollow(Clone)" || collision.gameObject.name == "EnemyStraight(Clone)" || collision.gameObject.name == "EnemyDumb(Clone)" || collision.gameObject.name == "EnemyAvoid(Clone)")
		{
			//health--;
		}
	}
}
