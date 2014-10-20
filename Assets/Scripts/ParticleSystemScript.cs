using UnityEngine;
using System.Collections;

public class ParticleSystemScript : MonoBehaviour {

	private ParticleSystem particles;
	private bool enabled = false;

	// Use this for initialization
	void Start () {

		particles = GetComponent<ParticleSystem>();
	
	}
	
	// Update is called once per frame
	void Update () {

		if (enabled == true)
		{
			if (particles.isPlaying == false)
			{
				enabled = false;
				gameObject.SetActive(false);
			}
		}
	
	}

	void OnEnable()
	{
		enabled = true;
	}
}
