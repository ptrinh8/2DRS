using UnityEngine;
using System.Collections;

//[RequireComponent (typeof (CharacterController))]
public class PlayerController : MonoBehaviour {

	//Handling
	public float rotationSpeed = 450f;
	private float speed = 5;
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

	public float vertExtent;
	public float horzExtent;

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
	}
	
	void Update () {

		if (gamePad) 
		{
			moveDirection = new Vector3(Input.GetAxis("GamepadMoveHorizontal"), (-1 * Input.GetAxis("GamepadMoveVertical")), 0);

			deltaX = Input.GetAxis("GamepadAimHorizontal");
			deltaY = Input.GetAxis("GamepadAimVertical");
			direction = new Vector3(deltaX, deltaY, 0);


			float angle = Mathf.Atan2(deltaY,deltaX) * 180/Mathf.PI + 90;



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
			}
			else
			{
				timer = 0;
			}

			}

		} 
		else 
		{
			moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);

			var v3 = Camera.main.ScreenToWorldPoint(Input.mousePosition);

			if (Input.GetMouseButton(0))
			{
				timer += Time.deltaTime;
				Vector3 mouse = Camera.main.WorldToScreenPoint(transform.position);
				Vector3 direction = (Input.mousePosition - mouse).normalized;
				bulletDirection.x = direction.x * bulletSpeed;
				bulletDirection.y = direction.y * bulletSpeed;
				if (timer >= bulletFireRate)
				{
					FireBullet();
					timer = 0;
				}
			}

			transform.rotation = Quaternion.LookRotation(Vector3.forward, v3 - this.transform.position);
		}

		if (health <= 0)
		{
			this.gameObject.SetActive(false);
		}

		rigidbody2D.velocity = moveDirection * speed;
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

	void OnTriggerEnter2D(Collider2D collision)
	{
		//Debug.Log ("hit");
		if (collision.gameObject.name == "EnemyFollow(Clone)" || collision.gameObject.name == "EnemyStraight(Clone)" || collision.gameObject.name == "EnemyDumb(Clone)")
		{
			//collision.gameObject.SetActive(false);
		}
	}
}
