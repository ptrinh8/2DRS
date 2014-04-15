using UnityEngine;
using System.Collections;

[RequireComponent (typeof (CharacterController))]
public class PlayerController : MonoBehaviour {

	//Handling
	public float rotationSpeed = 450f;
	public float speed = 10;
	//public float gravity = 20.0f;
	private float deltaX;
	private float deltaY;
	private Vector3 direction;
	private float radialDeadZone = .25f;

	//Components
	private CharacterController controller;

	//System
	private Vector3 moveDirection = Vector3.zero;
	private bool gamePad;

	void Start () {
		controller = GetComponent<CharacterController>();

		if (Input.GetJoystickNames().Length == 0) {
			gamePad = false;
		} else {
			gamePad = true;
		}
	}
	
	void Update () {

		if (gamePad) {
			moveDirection = new Vector3(Input.GetAxis("GamepadMoveHorizontal"), (-1 * Input.GetAxis("GamepadMoveVertical")), 0);


			deltaX = Input.GetAxis("GamepadAimHorizontal");
			deltaY = Input.GetAxis("GamepadAimVertical");
			direction = new Vector3(deltaX, deltaY, 0);


			float angle = Mathf.Atan2(deltaY,deltaX) * 180/Mathf.PI + 90;



			if (direction.magnitude > 0) {

			//angle = angle * 180/Mathf.PI + 90;
				if (direction.magnitude > radialDeadZone){
					Vector3 targetRotation = new Vector3(0,0,angle);
					Debug.Log (angle);
					transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(targetRotation), 1f);
				}

			}

		} else {
			moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);

			var v3 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			//v3.z = 25f;

			transform.rotation = Quaternion.LookRotation(Vector3.forward, v3 - this.transform.position);
		}

		moveDirection *= speed;

		//moveDirection.y -= gravity * Time.deltaTime;

		controller.Move(moveDirection * Time.deltaTime);
	}
}
