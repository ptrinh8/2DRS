using UnityEngine;
using System.Collections;

public class VolumeControl : MonoBehaviour {

	private Vector2 kick;
	private Vector2 clap;
	private Vector2 hat;
	private Vector2 snare;
	private AudioSource kickAudio;
	private AudioSource clapAudio;
	private AudioSource hatAudio;
	private AudioSource snareAudio;
	private float kickDistance;
	private float clapDistance;
	private float hatDistance;
	private float snareDistance;

	private EnemyController kickController;
	private EnemyController snareController;
	private EnemyController clapController;
	private EnemyController hatController;

	public float kicktheaudio;

	public int kickHealth;
	private int clapHealth;
	private int hatHealth;
	private int snareHealth;

	public float kickLowestVolume;
	private float clapLowestVolume;
	private float hatLowestVolume;
	private float snareLowestVolume;

	private int songSection;
	private Vector2 playerPosition;

	// Use this for initialization
	void Start () {

		songSection = GameObject.Find ("AudioSource").GetComponent<AudioXFade>().songSection;

		kick = GameObject.Find ("Kick").transform.position;
		hat = GameObject.Find ("Hat").transform.position;
		clap = GameObject.Find ("Clap").transform.position;
		snare = GameObject.Find ("Snare").transform.position;

		playerPosition = GameObject.Find ("Player").transform.position;

		kickDistance = Vector2.Distance(kick, playerPosition);
		hatDistance = Vector2.Distance(hat, playerPosition);
		snareDistance = Vector2.Distance(snare, playerPosition);
		clapDistance = Vector2.Distance(clap, playerPosition);

		kickHealth = GameObject.Find ("Kick").GetComponent<EnemyController>().health;
		clapHealth = GameObject.Find ("Clap").GetComponent<EnemyController>().health;
		hatHealth = GameObject.Find ("Hat").GetComponent<EnemyController>().health;
		snareHealth = GameObject.Find ("Snare").GetComponent<EnemyController>().health;

		kickController = GameObject.Find ("Kick").GetComponent<EnemyController>();
		snareController = GameObject.Find ("Snare").GetComponent<EnemyController>();
		clapController = GameObject.Find ("Clap").GetComponent<EnemyController>();
		hatController = GameObject.Find ("Hat").GetComponent<EnemyController>();

		kickLowestVolume = 0f;
		clapLowestVolume = 0f;
		hatLowestVolume = 0f;
		snareLowestVolume = 0f;

	
	}
	
	// Update is called once per frame
	void Update () {

		UpdatePositions();
		UpdateVolume();

		kicktheaudio = kickAudio.volume;


		if (kickDistance < 4)
		{
			if (kickAudio.volume < .5 && kickLowestVolume < .5)
			{
				kickAudio.volume += .001f;
			}
			else
			{
				kickAudio.volume = .5f;
			}
		}
		else
		{
			if (kickAudio.volume < kickLowestVolume)
			{
				kickAudio.volume += .001f;
			}

			if (kickAudio.volume > kickLowestVolume)
			{
				kickAudio.volume -= .001f;
			}
		}

		if (hatDistance < 4)
		{
			if (hatAudio.volume < .5 && hatLowestVolume < .5)
			{
				hatAudio.volume += .001f;
			}
			else
			{
				hatAudio.volume = .5f;
			}
		}
		else
		{
			if (hatAudio.volume < hatLowestVolume)
			{
				hatAudio.volume += .001f;
			}

			if (hatAudio.volume > hatLowestVolume)
			{
				hatAudio.volume -= .001f;
			}
		}

		if (clapDistance < 4)
		{
			if (clapAudio.volume < .5 && clapLowestVolume < .5)
			{
				clapAudio.volume += .001f;
			}
			else
			{
				clapAudio.volume = .5f;
			}
		}
		else
		{
			if (clapAudio.volume < clapLowestVolume)
			{
				clapAudio.volume += .001f;
			}

			if (clapAudio.volume > clapLowestVolume)
			{
				clapAudio.volume -= .001f;
			}
		}

		if (snareDistance < 4)
		{
			if (snareAudio.volume < .5 && snareLowestVolume < .5)
			{
				snareAudio.volume += .001f;
			}
			else
			{
				snareAudio.volume = .5f;
			}
		}
		else
		{
			if (snareAudio.volume < snareLowestVolume)
			{
				snareAudio.volume += .001f;
			}

			if (snareAudio.volume > snareLowestVolume)
			{
				snareAudio.volume -= .001f;
			}
		}
	
	}

	void UpdatePositions()
	{
		songSection = GameObject.Find ("AudioSource").GetComponent<AudioXFade>().songSection;
		playerPosition = GameObject.Find ("Player").transform.position;

		if (kickController.gameObject.activeInHierarchy == true)
		{
			kick = GameObject.Find ("Kick").transform.position;
			kickHealth = GameObject.Find ("Kick").GetComponent<EnemyController>().health;
		}
		if (hatController.gameObject.activeInHierarchy == true)
		{
			hat = GameObject.Find ("Hat").transform.position;
			hatHealth = GameObject.Find ("Hat").GetComponent<EnemyController>().health;
		}
		if (clapController.gameObject.activeInHierarchy == true)
		{
			clap = GameObject.Find ("Clap").transform.position;
			clapHealth = GameObject.Find ("Clap").GetComponent<EnemyController>().health;
		}
		if (snareController.gameObject.activeInHierarchy == true)
		{
			snare = GameObject.Find ("Snare").transform.position;
			snareHealth = GameObject.Find ("Snare").GetComponent<EnemyController>().health;
		}
		
		kickAudio = GameObject.Find ("AudioSource").GetComponent<AudioXFade>().kickArray[songSection];
		clapAudio = GameObject.Find ("AudioSource").GetComponent<AudioXFade>().clapArray[songSection];
		hatAudio = GameObject.Find ("AudioSource").GetComponent<AudioXFade>().hatArray[songSection];
		snareAudio = GameObject.Find ("AudioSource").GetComponent<AudioXFade>().snareArray[songSection];

		kickDistance = Vector2.Distance(kick, playerPosition);
		hatDistance = Vector2.Distance(hat, playerPosition);
		snareDistance = Vector2.Distance(snare, playerPosition);
		clapDistance = Vector2.Distance(clap, playerPosition);
	}

	void UpdateVolume()
	{
		if (kickHealth == 50)
		{
			kickLowestVolume = 0f;
		}
		else
		{
			kickLowestVolume = 1f - (kickHealth * .02f);
		}

		if (clapHealth == 50)
		{
			clapLowestVolume = 0f;
		}
		else
		{
			clapLowestVolume = 1f - (clapHealth * .02f);
		}

		if (hatLowestVolume == 50)
		{
			hatLowestVolume = 0f;
		}
		else
		{
			hatLowestVolume = 1f - (hatHealth * .02f);
		}

		if (snareLowestVolume == 50)
		{
			snareLowestVolume = 0f;
		}
		else
		{
			snareLowestVolume = 1f - (snareHealth * .02f);
		}
							

	}
}
