using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	private Vector2 bulletForce;

	private float vertExtent;
	private float horzExtent;

	// Use this for initialization
	void Start () {
		
	}

	void OnEnable()
	{
		vertExtent = Camera.main.camera.orthographicSize;
		horzExtent = vertExtent * Screen.width / Screen.height;
	}

	// Update is called once per frame
	void Update () {
		//bulletForce = new Vector2(5, 5);
		//transform.rigidbody2D.velocity = bulletForce;
		//transform.position.x +=
		if (this.transform.position.x > horzExtent || this.transform.position.y > vertExtent || this.transform.position.x < (-1 * horzExtent) || this.transform.position.y < (-1 * vertExtent))
		{
			Deactivate ();
		}
	}

	public void Deactivate()
	{
		gameObject.SetActive(false);
	}

	public void Activate()
	{
		gameObject.SetActive(true);
	}
}
