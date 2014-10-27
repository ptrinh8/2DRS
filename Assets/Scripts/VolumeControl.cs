using UnityEngine;
using System.Collections;

public class VolumeControl : MonoBehaviour {

	private Vector2 kick;
	private Vector2 clap;
	private Vector2 hat;
	private Vector2 snare;
	private Vector2 glitch;
	private Vector2 gb1Pul1;
	private Vector2 gb1Pul2;
	private Vector2 gb1Wav;
	private Vector2 gb2Pul1;
	private Vector2 gb2Pul2AndWav;

	private float kickAudio;
	private float clapAudio;
	private float hatAudio;
	private float snareAudio;
	private float glitchAudio;
	private float gb1Pul1Audio;
	private float gb1Pul2Audio;
	private float gb1WavAudio;
	private float gb2Pul1Audio;
	private float gb2Pul2AndWavAudio;

	private float kickDistance;
	private float clapDistance;
	private float hatDistance;
	private float snareDistance;
	private float glitchDistance;
	private float gb1Pul1Distance;
	private float gb1Pul2Distance;
	private float gb1WavDistance;
	private float gb2Pul1Distance;
	private float gb2Pul2AndWavDistance;

	private EnemyController kickController;
	private EnemyController snareController;
	private EnemyController clapController;
	private EnemyController hatController;
	private EnemyController glitchController;
	private EnemyController gb1Pul1Controller;
	private EnemyController gb1Pul2Controller;
	private EnemyController gb1WavController;
	private EnemyController gb2Pul1Controller;
	private EnemyController gb2Pul2AndWavController;

	public float kicktheaudio;

	public int kickHealth;
	private int clapHealth;
	private int hatHealth;
	private int snareHealth;
	private int glitchHealth;
	private int gb1Pul1Health;
	private int gb1Pul2Health;
	private int gb1WavHealth;
	private int gb2Pul1Health;
	private int gb2Pul2AndWavHealth;

	public float kickLowestVolume;
	private float clapLowestVolume;
	private float hatLowestVolume;
	private float snareLowestVolume;
	private float glitchLowestVolume;
	private float gb1Pul1LowestVolume;
	private float gb1Pul2LowestVolume;
	private float gb1WavLowestVolume;
	private float gb2Pul1LowestVolume;
	private float gb2Pul2AndWavLowestVolume;

	public AudioSource[] kickArray;
	private AudioSource[] hatArray;
	private AudioSource[] clapArray;
	private AudioSource[] snareArray;
	private AudioSource[] glitchArray;
	private AudioSource[] gb1Pul1Array;
	private AudioSource[] gb1Pul2Array;
	private AudioSource[] gb1WavArray;
	private AudioSource[] gb2Pul1Array;
	private AudioSource[] gb2Pul2AndWavArray;

	private int songSection;
	private Vector2 playerPosition;

	private PlayerController player;
	// Use this for initialization
	void Start () {

		songSection = GameObject.Find ("AudioSource").GetComponent<AudioXFade>().songSection;

		kick = GameObject.Find ("Kick").transform.position;
		hat = GameObject.Find ("Hat").transform.position;
		clap = GameObject.Find ("Clap").transform.position;
		snare = GameObject.Find ("Snare").transform.position;
		glitch = GameObject.Find ("AltPerc").transform.position;
		gb1Pul1 = GameObject.Find ("GB1Pulse1").transform.position;
		gb1Pul2 = GameObject.Find ("GB1Pulse2").transform.position;
		gb1Wav = GameObject.Find ("GB1Wav").transform.position;
		gb2Pul1 = GameObject.Find ("GB2Pulse1").transform.position;
		gb2Pul2AndWav = GameObject.Find ("GB2PulseAndWav").transform.position;


		playerPosition = GameObject.Find ("Player").transform.position;

		kickDistance = Vector2.Distance(kick, playerPosition);
		hatDistance = Vector2.Distance(hat, playerPosition);
		snareDistance = Vector2.Distance(snare, playerPosition);
		clapDistance = Vector2.Distance(clap, playerPosition);
		glitchDistance = Vector2.Distance(glitch, playerPosition);
		gb1Pul1Distance = Vector2.Distance(gb1Pul1, playerPosition);
		gb1Pul2Distance = Vector2.Distance(gb1Pul2, playerPosition);
		gb1WavDistance = Vector2.Distance(gb1Wav, playerPosition);
		gb2Pul1Distance = Vector2.Distance(gb2Pul1, playerPosition);
		gb2Pul2AndWavDistance = Vector2.Distance(gb2Pul2AndWav, playerPosition);

		kickController = GameObject.Find ("Kick").GetComponent<EnemyController>();
		snareController = GameObject.Find ("Snare").GetComponent<EnemyController>();
		clapController = GameObject.Find ("Clap").GetComponent<EnemyController>();
		hatController = GameObject.Find ("Hat").GetComponent<EnemyController>();
		glitchController = GameObject.Find ("AltPerc").GetComponent<EnemyController>();
		gb1Pul1Controller = GameObject.Find ("GB1Pulse1").GetComponent<EnemyController>();
		gb1Pul2Controller = GameObject.Find ("GB1Pulse2").GetComponent<EnemyController>();
		gb1WavController = GameObject.Find ("GB1Wav").GetComponent<EnemyController>();
		gb2Pul1Controller = GameObject.Find ("GB2Pulse1").GetComponent<EnemyController>();
		gb2Pul2AndWavController = GameObject.Find ("GB2PulseAndWav").GetComponent<EnemyController>();

		kickArray = GameObject.Find ("AudioSource").GetComponent<AudioXFade>().kickArray;
		hatArray = GameObject.Find ("AudioSource").GetComponent<AudioXFade>().hatArray;
		clapArray = GameObject.Find ("AudioSource").GetComponent<AudioXFade>().clapArray;
		snareArray = GameObject.Find ("AudioSource").GetComponent<AudioXFade>().snareArray;
		glitchArray = GameObject.Find ("AudioSource").GetComponent<AudioXFade>().glitchArray;
		gb1Pul1Array = GameObject.Find ("AudioSource").GetComponent<AudioXFade>().gb1Pul1Array;
		gb1Pul2Array = GameObject.Find ("AudioSource").GetComponent<AudioXFade>().gb1Pul2Array;
		gb1WavArray = GameObject.Find ("AudioSource").GetComponent<AudioXFade>().gb1WavArray;
		gb2Pul1Array = GameObject.Find ("AudioSource").GetComponent<AudioXFade>().gb2Pul1Array;
		gb2Pul2AndWavArray = GameObject.Find ("AudioSource").GetComponent<AudioXFade>().gb2Pul2AndWavArray;


		kickHealth = kickController.health;
		clapHealth = clapController.health;
		hatHealth = hatController.health;
		snareHealth = snareController.health;
		glitchHealth = glitchController.health;
		gb1Pul1Health = gb1Pul1Controller.health;
		gb1Pul2Health = gb1Pul2Controller.health;
		gb1WavHealth = gb1WavController.health;
		gb2Pul1Health = gb2Pul1Controller.health;
		gb2Pul2AndWavHealth = gb2Pul2AndWavController.health;

		kickLowestVolume = 0f;
		clapLowestVolume = 0f;
		hatLowestVolume = 0f;
		snareLowestVolume = 0f;
		glitchLowestVolume = 0f;
		gb1Pul1LowestVolume = 0f;
		gb1Pul2LowestVolume = 0f;
		gb1WavLowestVolume = 0f;
		gb2Pul1LowestVolume = 0f;
		gb2Pul2AndWavLowestVolume = 0f;

		player = GameObject.Find ("Player").GetComponent<PlayerController>();
	
	}
	
	// Update is called once per frame
	void Update () {

		UpdatePositions();
		UpdateLowestVolume();

		kicktheaudio = kickAudio;


		if (kickDistance < 6)
		{
			if (kickAudio < .5 && kickLowestVolume < .5)
			{
				kickAudio += .01f;
			}
			else
			{
				kickAudio = .5f;
			}
		}
		else
		{
			if (kickAudio < kickLowestVolume)
			{
				kickAudio += .01f;
			}

			if (kickAudio > kickLowestVolume)
			{
				kickAudio -= .01f;
			}
		}

		if (hatDistance < 6)
		{
			if (hatAudio < .5 && hatLowestVolume < .5)
			{
				hatAudio += .01f;
			}
			else
			{
				hatAudio = .5f;
			}
		}
		else
		{
			if (hatAudio < hatLowestVolume)
			{
				hatAudio += .01f;
			}

			if (hatAudio > hatLowestVolume)
			{
				hatAudio -= .01f;
			}
		}

		if (clapDistance < 6)
		{
			if (clapAudio < .5 && clapLowestVolume < .5)
			{
				clapAudio += .01f;
			}
			else
			{
				clapAudio = .5f;
			}
		}
		else
		{
			if (clapAudio < clapLowestVolume)
			{
				clapAudio += .01f;
			}

			if (clapAudio > clapLowestVolume)
			{
				clapAudio -= .01f;
			}
		}

		if (snareDistance < 6)
		{
			if (snareAudio < .5 && snareLowestVolume < .5)
			{
				snareAudio += .01f;
			}
			else
			{
				snareAudio = .5f;
			}
		}
		else
		{
			if (snareAudio < snareLowestVolume)
			{
				snareAudio += .01f;
			}

			if (snareAudio > snareLowestVolume)
			{
				snareAudio -= .01f;
			}
		}

		if (glitchDistance < 6)
		{
			if (glitchAudio < .5 && glitchLowestVolume < .5)
			{
				glitchAudio += .01f;
			}
			else
			{
				glitchAudio = .5f;
			}
		}
		else
		{
			if (glitchAudio < glitchLowestVolume)
			{
				glitchAudio += .01f;
			}
			
			if (glitchAudio > glitchLowestVolume)
			{
				glitchAudio -= .01f;
			}
		}

		if (gb1Pul1Distance < 6)
		{
			if (gb1Pul1Audio < .5 && gb1Pul1LowestVolume < .5)
			{
				gb1Pul1Audio += .01f;
			}
			else
			{
				gb1Pul1Audio = .5f;
			}
		}
		else
		{
			if (gb1Pul1Audio < gb1Pul1LowestVolume)
			{
				gb1Pul1Audio += .01f;
			}
			
			if (gb1Pul1Audio > gb1Pul1LowestVolume)
			{
				gb1Pul1Audio -= .01f;
			}
		}

		if (gb1Pul2Distance < 6)
		{
			if (gb1Pul2Audio < .5 && gb1Pul2LowestVolume < .5)
			{
				gb1Pul2Audio += .01f;
			}
			else
			{
				gb1Pul2Audio = .5f;
			}
		}
		else
		{
			if (gb1Pul2Audio < gb1Pul2LowestVolume)
			{
				gb1Pul2Audio += .01f;
			}
			
			if (gb1Pul2Audio > gb1Pul2LowestVolume)
			{
				gb1Pul2Audio -= .01f;
			}
		}

		if (gb1WavDistance < 6)
		{
			if (gb1WavAudio < .5 && gb1WavLowestVolume < .5)
			{
				gb1WavAudio += .01f;
			}
			else
			{
				gb1WavAudio = .5f;
			}
		}
		else
		{
			if (gb1WavAudio < gb1WavLowestVolume)
			{
				gb1WavAudio += .01f;
			}
			
			if (gb1WavAudio > gb1WavLowestVolume)
			{
				gb1WavAudio -= .01f;
			}
		}

		if (gb2Pul1Distance < 6)
		{
			if (gb2Pul1Audio < .5 && gb2Pul1LowestVolume < .5)
			{
				gb2Pul1Audio += .01f;
			}
			else
			{
				gb2Pul1Audio = .5f;
			}
		}
		else
		{
			if (gb2Pul1Audio < gb2Pul1LowestVolume)
			{
				gb2Pul1Audio += .01f;
			}
			
			if (gb2Pul1Audio > gb2Pul1LowestVolume)
			{
				gb2Pul1Audio -= .01f;
			}
		}

		if (gb2Pul2AndWavDistance < 6)
		{
			if (gb2Pul2AndWavAudio < .5 && gb2Pul2AndWavLowestVolume < .5)
			{
				gb2Pul2AndWavAudio += .01f;
			}
			else
			{
				gb2Pul2AndWavAudio = .5f;
			}
		}
		else
		{
			if (gb2Pul2AndWavAudio < gb2Pul2AndWavLowestVolume)
			{
				gb2Pul2AndWavAudio += .01f;
			}
			
			if (gb2Pul2AndWavAudio > gb2Pul2AndWavLowestVolume)
			{
				gb2Pul2AndWavAudio -= .01f;
			}
		}

		UpdateAudioVolume();
	}

	void UpdatePositions()
	{
		songSection = GameObject.Find ("AudioSource").GetComponent<AudioXFade>().songSection;
		if (player.gameObject.activeInHierarchy == true)
		{
			playerPosition = GameObject.Find ("Player").transform.position;
		}

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
		if (glitchController.gameObject.activeInHierarchy == true)
		{
			glitch = GameObject.Find ("AltPerc").transform.position;
			glitchHealth = GameObject.Find ("AltPerc").GetComponent<EnemyController>().health;
		}
		if (gb1Pul1Controller.gameObject.activeInHierarchy == true)
		{
			gb1Pul1 = GameObject.Find ("GB1Pulse1").transform.position;
			gb1Pul1Health = GameObject.Find ("GB1Pulse1").GetComponent<EnemyController>().health;
		}
		if (gb1Pul2Controller.gameObject.activeInHierarchy == true)
		{
			gb1Pul2 = GameObject.Find ("GB1Pulse2").transform.position;
			gb1Pul2Health = GameObject.Find ("GB1Pulse2").GetComponent<EnemyController>().health;
		}
		if (gb1WavController.gameObject.activeInHierarchy == true)
		{
			gb1Wav = GameObject.Find ("GB1Wav").transform.position;
			gb1WavHealth = GameObject.Find ("GB1Wav").GetComponent<EnemyController>().health;
		}
		if (gb2Pul1Controller.gameObject.activeInHierarchy == true)
		{
			gb2Pul1 = GameObject.Find ("GB2Pulse1").transform.position;
			gb2Pul1Health = GameObject.Find ("GB2Pulse1").GetComponent<EnemyController>().health;
		}
		if (gb2Pul2AndWavController.gameObject.activeInHierarchy == true)
		{
			gb2Pul2AndWav = GameObject.Find ("GB2PulseAndWav").transform.position;
			gb2Pul2AndWavHealth = GameObject.Find ("GB2PulseAndWav").GetComponent<EnemyController>().health;
		}

		/*
		kickAudio = GameObject.Find ("AudioSource").GetComponent<AudioXFade>().kickArray[songSection];
		clapAudio = GameObject.Find ("AudioSource").GetComponent<AudioXFade>().clapArray[songSection];
		hatAudio = GameObject.Find ("AudioSource").GetComponent<AudioXFade>().hatArray[songSection];
		snareAudio = GameObject.Find ("AudioSource").GetComponent<AudioXFade>().snareArray[songSection];
		glitchAudio = GameObject.Find ("AudioSource").GetComponent<AudioXFade>().glitchArray[songSection];
		gb1Pul1Audio = GameObject.Find ("AudioSource").GetComponent<AudioXFade>().gb1Pul1Array[songSection];
		gb1Pul2Audio = GameObject.Find ("AudioSource").GetComponent<AudioXFade>().gb1Pul2Array[songSection];
		gb1WavAudio = GameObject.Find ("AudioSource").GetComponent<AudioXFade>().gb1WavArray[songSection];
		gb2Pul1Audio = GameObject.Find ("AudioSource").GetComponent<AudioXFade>().gb2Pul1Array[songSection];
		gb2Pul2AndWavAudio = GameObject.Find ("AudioSource").GetComponent<AudioXFade>().gb2Pul2AndWavArray[songSection];*/

		kickArray = GameObject.Find ("AudioSource").GetComponent<AudioXFade>().kickArray;
		hatArray = GameObject.Find ("AudioSource").GetComponent<AudioXFade>().hatArray;
		clapArray = GameObject.Find ("AudioSource").GetComponent<AudioXFade>().clapArray;
		snareArray = GameObject.Find ("AudioSource").GetComponent<AudioXFade>().snareArray;
		glitchArray = GameObject.Find ("AudioSource").GetComponent<AudioXFade>().glitchArray;
		gb1Pul1Array = GameObject.Find ("AudioSource").GetComponent<AudioXFade>().gb1Pul1Array;
		gb1Pul2Array = GameObject.Find ("AudioSource").GetComponent<AudioXFade>().gb1Pul2Array;
		gb1WavArray = GameObject.Find ("AudioSource").GetComponent<AudioXFade>().gb1WavArray;
		gb2Pul1Array = GameObject.Find ("AudioSource").GetComponent<AudioXFade>().gb2Pul1Array;
		gb2Pul2AndWavArray = GameObject.Find ("AudioSource").GetComponent<AudioXFade>().gb2Pul2AndWavArray;

		kickDistance = Vector2.Distance(kick, playerPosition);
		hatDistance = Vector2.Distance(hat, playerPosition);
		snareDistance = Vector2.Distance(snare, playerPosition);
		clapDistance = Vector2.Distance(clap, playerPosition);
		glitchDistance = Vector2.Distance(glitch, playerPosition);
		gb1Pul1Distance = Vector2.Distance(gb1Pul1, playerPosition);
		gb1Pul2Distance = Vector2.Distance(gb1Pul2, playerPosition);
		gb1WavDistance = Vector2.Distance(gb1Wav, playerPosition);
		gb2Pul1Distance = Vector2.Distance(gb2Pul1, playerPosition);
		gb2Pul2AndWavDistance = Vector2.Distance(gb2Pul2AndWav, playerPosition);
	}

	void UpdateLowestVolume()
	{
		if (kickController.gameObject.activeInHierarchy == true && kickController.killedOnce == false)
		{
			if (kickHealth == 50)
			{
				kickLowestVolume = 0f;
			}
			else
			{
				kickLowestVolume = 1f - (kickHealth * .02f);
			}
		}
		else if (kickController.killedOnce == true)
		{
			kickLowestVolume = 1f;
		}

		if (clapController.gameObject.activeInHierarchy == true && clapController.killedOnce == false)
		{
			if (clapHealth == 50)
			{
				clapLowestVolume = 0f;
			}
			else
			{
				clapLowestVolume = 1f - (clapHealth * .02f);
			}
		}
		else if (clapController.killedOnce == true)
		{
			clapLowestVolume = 1f;
		}

		if (hatController.gameObject.activeInHierarchy == true && hatController.killedOnce == false)
		{
			if (hatLowestVolume == 50)
			{
				hatLowestVolume = 0f;
			}
			else
			{
				hatLowestVolume = 1f - (hatHealth * .02f);
			}
		}
		else if (hatController.killedOnce == true)
		{
			hatLowestVolume = 1f;
		}

		if (snareController.gameObject.activeInHierarchy == true && snareController.killedOnce == false)
		{
			if (snareLowestVolume == 50)
			{
				snareLowestVolume = 0f;
			}
			else
			{
				snareLowestVolume = 1f - (snareHealth * .02f);
			}
		}
		else if (snareController.killedOnce == true)
		{
			snareLowestVolume = 1f;
		}

		if (glitchController.gameObject.activeInHierarchy == true && glitchController.killedOnce == false)
		{
			if (glitchLowestVolume == 50)
			{
				glitchLowestVolume = 0f;
			}
			else
			{
				glitchLowestVolume = 1f - (glitchHealth * .02f);
			}
		}
		else if (glitchController.killedOnce == true)
		{
			glitchLowestVolume = 1f;
		}

		if (gb1Pul1Controller.gameObject.activeInHierarchy == true && gb1Pul1Controller.killedOnce == false)
		{
			if (gb1Pul1LowestVolume == 50)
			{
				gb1Pul1LowestVolume = 0f;
			}
			else
			{
				gb1Pul1LowestVolume = 1f - (gb1Pul1Health * .02f);
			}
		}
		else if (gb1Pul1Controller.killedOnce == true)
		{
			gb1Pul1LowestVolume = 1f;
		}

		if (gb1Pul2Controller.gameObject.activeInHierarchy == true && gb1Pul2Controller.killedOnce == false)
		{
			if (gb1Pul2LowestVolume == 50)
			{
				gb1Pul2LowestVolume = 0f;
			}
			else
			{
				gb1Pul2LowestVolume = 1f - (gb1Pul2Health * .02f);
			}
		}
		else if (gb1Pul2Controller.killedOnce == true)
		{
			gb1Pul2LowestVolume = 1f;
		}

		if (gb1WavController.gameObject.activeInHierarchy == true && gb1WavController.killedOnce == false)
		{
			if (gb1WavLowestVolume == 50)
			{
				gb1WavLowestVolume = 0f;
			}
			else
			{
				gb1WavLowestVolume = 1f - (gb1WavHealth * .02f);
			}
		}
		else if (gb1WavController.killedOnce == true)
		{
			gb1WavLowestVolume = 1f;
		}

		if (gb2Pul1Controller.gameObject.activeInHierarchy == true && gb2Pul1Controller.killedOnce == false)
		{
			if (gb2Pul1LowestVolume == 50)
			{
				gb2Pul1LowestVolume = 0f;
			}
			else
			{
				gb2Pul1LowestVolume = 1f - (gb2Pul1Health * .02f);
			}
		}
		else if (gb2Pul1Controller.killedOnce == true)
		{
			gb2Pul1LowestVolume = 1f;
		}
			
		if (gb2Pul2AndWavController.gameObject.activeInHierarchy == true && gb2Pul2AndWavController.killedOnce == false)
		{
			if (gb2Pul2AndWavLowestVolume == 50)
			{
				gb2Pul2AndWavLowestVolume = 0f;
			}
			else
			{
				gb2Pul2AndWavLowestVolume = 1f - (gb2Pul2AndWavHealth * .02f);
			}
		}
		else if (gb2Pul2AndWavController.killedOnce == true)
		{
			gb2Pul2AndWavLowestVolume = 1f;
		}
	}

	void UpdateAudioVolume()
	{
		for (int i = 0; i < 10; i++)
		{
			kickArray[i].volume = kickAudio;
			clapArray[i].volume = clapAudio;
			hatArray[i].volume = hatAudio;
			snareArray[i].volume = snareAudio;
			glitchArray[i].volume = glitchAudio;
			gb1Pul1Array[i].volume = gb1Pul1Audio;
			gb1Pul2Array[i].volume = gb1Pul2Audio;
			gb1WavArray[i].volume = gb1WavAudio;
			gb2Pul1Array[i].volume = gb2Pul1Audio;
			gb2Pul2AndWavArray[i].volume = gb2Pul2AndWavAudio;
		}
	}
}
