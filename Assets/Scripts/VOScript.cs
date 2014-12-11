using UnityEngine;
using System.Collections;

public class VOScript : MonoBehaviour {

	private AudioSource[] voArray;
	private int voIterator;
	private float voTimer;
	private float voTime;
	private bool startPlayedOnce;

	// Use this for initialization
	void Start () {

		voArray = new AudioSource[7];

		voArray[0] = GameObject.Find ("WelcomeToRythmic").GetComponent<AudioSource>();
		voArray[1] = GameObject.Find ("UseTheWASDKeys").GetComponent<AudioSource>();
		voArray[2] = GameObject.Find ("UseTheMouseToAim").GetComponent<AudioSource>();
		voArray[3] = GameObject.Find ("LeftClickShoots").GetComponent<AudioSource>();
		voArray[4] = GameObject.Find ("RightClickBoosts").GetComponent<AudioSource>();
		voArray[5] = GameObject.Find ("Controller").GetComponent<AudioSource>();
		voArray[6] = GameObject.Find ("PressSpace").GetComponent<AudioSource>();
		voTime = 4f;
		voIterator = 0;
		startPlayedOnce = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		voTimer += Time.deltaTime;
		if (voIterator < 7)
		{
			if (voIterator == 0)
			{
				voTime = .5f;
			}
			else
			{
				voTime = 4f;
			}

			if (voTimer > voTime)
			{
				voArray[voIterator].Play();
				voIterator++;
				voTimer = 0;
			}
		}

		if (Input.GetKey (KeyCode.Space))
		{
			if (startPlayedOnce == false)
			{
				voArray[0].Play();
				startPlayedOnce = true;
			}
		}
	}
}
