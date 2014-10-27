using UnityEngine;
using System.Collections;

public class SongScript : MonoBehaviour {
	
	
	private MetronomeTimer metronome;
	private AudioXFade audioXFade;
	
	private int[] subdivisions = new int[16]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
	private int[] subdivisionsNotOpposite = new int[16]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
	private int[] subdivisionsLeft = new int[16]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
	private int[] subdivisionsLeftNotOpposite = new int[16]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
	private int[] subdivisionsLong = new int[16]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
	private int[] subdivisionsLongLeft = new int[16]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
	private int[] subdivisionsLongNotOpposite = new int[16]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
	private int[] subdivisionsLongLeftNotOpposite = new int[16]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};

	private EnemyController kickController;
	private EnemyController snareController;
	private EnemyController hatController;
	private EnemyController clapController;
	private EnemyController glitchController;
	private EnemyController gb1Pul1Controller;
	private EnemyController gb1Pul2Controller;
	private EnemyController gb1WavController;
	private EnemyController gb2Pul1Controller;
	private EnemyController gb2Pul2AndWavController;

	private GameObject kick;
	private GameObject snare;
	private GameObject hat;
	private GameObject clap;
	private GameObject glitch;
	private GameObject gb1pul1;
	private GameObject gb1pul2;
	private GameObject gb1wav;
	private GameObject gb2pul1;
	private GameObject gb2pul2andwav;

	private bool kickActive = false;
	private bool snareActive = false;
	private bool hatActive = false;
	private bool clapActive = false;
	private bool glitchActive = false;
	private bool gb1Pul1Active = false;
	private bool gb1Pul2Active = false;
	private bool gb1WavActive = false;
	private bool gb2Pul1Active = false;
	private bool gb2Pul2AndWavActive = false;

	public bool activeChecked = false;

	private Camera theCamera;
	private float cameraSize = 8f;
	public Color cameraColor;



	private PlayerController player;
	
	// Use this for initialization
	void Start () {

		kick = GameObject.Find ("Kick");
		snare = GameObject.Find ("Snare");
		hat = GameObject.Find ("Hat");
		clap = GameObject.Find("Clap");
		glitch = GameObject.Find ("AltPerc");
		gb1pul1 = GameObject.Find ("GB1Pulse1");
		gb1pul2 = GameObject.Find ("GB1Pulse2");
		gb1wav = GameObject.Find ("GB1Wav");
		gb2pul1 = GameObject.Find ("GB2Pulse1");
		gb2pul2andwav = GameObject.Find("GB2PulseAndWav");

		kickController = GameObject.Find ("Kick").GetComponent<EnemyController>();
		snareController = GameObject.Find ("Snare").GetComponent<EnemyController>();
		hatController = GameObject.Find ("Hat").GetComponent<EnemyController>();
		clapController = GameObject.Find("Clap").GetComponent<EnemyController>();
		glitchController = GameObject.Find ("AltPerc").GetComponent<EnemyController>();
		gb1Pul1Controller = GameObject.Find ("GB1Pulse1").GetComponent<EnemyController>();
		gb1Pul2Controller = GameObject.Find ("GB1Pulse2").GetComponent<EnemyController>();
		gb1WavController = GameObject.Find ("GB1Wav").GetComponent<EnemyController>();
		gb2Pul1Controller = GameObject.Find ("GB2Pulse1").GetComponent<EnemyController>();
		gb2Pul2AndWavController = GameObject.Find ("GB2PulseAndWav").GetComponent<EnemyController>();

		kickController.gameObject.SetActive(false);
		snareController.gameObject.SetActive(false);
		hatController.gameObject.SetActive(false);
		clapController.gameObject.SetActive(false);
		gb1Pul1Controller.gameObject.SetActive(false);
		gb1Pul2Controller.gameObject.SetActive(false);
		gb2Pul1Controller.gameObject.SetActive(false);
		gb2Pul2AndWavController.gameObject.SetActive(false);

		metronome = GameObject.Find ("AudioSource").GetComponent<MetronomeTimer>();
		audioXFade = GameObject.Find ("AudioSource").GetComponent<AudioXFade>();

		theCamera = GameObject.Find ("Main Camera").GetComponent<Camera>();
		cameraColor = theCamera.backgroundColor;

		player = GameObject.Find ("Player").GetComponent<PlayerController>();

		//kickController.instrumentColor = new Color (.5f, .5f, .5f);
		//snareController.instrumentColor = new Color(.75f, .75f, .75f);
		//clapController.instrumentColor = new Color(.25f, .25f, .25f);
		//hatController.instrumentColor = new Color(.9f, .9f, .9f);

	}

	void SongSectionZero()
	{
		gb1WavController.transform.position = new Vector2(-6, 0);
		glitchController.transform.position = new Vector2(6, 0);

		if (metronome.onSixteenth == true)
		{
			switch(metronome.sixteenthNote)
			{
			case 2:
				glitchController.LaunchEnemy(1, 1);
				break;
			case 5:
				glitchController.LaunchEnemy(1, 1);
				break;
			case 6:
				glitchController.LaunchEnemy(1, 2);
				break;
			case 8:
				glitchController.LaunchEnemy(1, 1);
				break;
			}
		}

		if (metronome.measure == 1 || metronome.measure == 2 || metronome.measure == 5 || metronome.measure == 6 || metronome.measure == 9 || metronome.measure == 10 || metronome.measure == 13 || metronome.measure == 14)
		{
			if (metronome.onSixteenth == true)
			{
				switch(metronome.sixteenthNote)
				{
				case 0:
					gb1WavController.LaunchEnemy(2, 1);
					break;
				case 1:
					gb1WavController.LaunchEnemy(2, 1);
					break;
				case 2:
					gb1WavController.LaunchEnemy(2, 1);
					break;
				case 3:
					gb1WavController.LaunchEnemy(2, 1);
					break;
				case 4:
					gb1WavController.LaunchEnemy(2, 1);
					break;
				case 5:
					gb1WavController.LaunchEnemy(2, 1);
					break;
				case 6:
					gb1WavController.LaunchEnemy(2, 1);
					break;
				case 7:
					gb1WavController.LaunchEnemy(2, 1);
					break;
				}
			}
		}
		if (metronome.measure == 3 || metronome.measure == 7 || metronome.measure == 11 || metronome.measure == 15)
		{
			if (metronome.onSixteenth == true)
			{
				switch(metronome.sixteenthNote)
				{
				case 0:
					gb1WavController.LaunchEnemy(2, 1);
					break;
				case 1:
					gb1WavController.LaunchEnemy(2, 1);
					break;
				case 2:
					gb1WavController.LaunchEnemy(2, 1);
					break;
				case 3:
					gb1WavController.LaunchEnemy(2, 1);
					break;
				case 4:
					gb1WavController.LaunchEnemy(2, 1);
					break;
				case 5:
					gb1WavController.LaunchEnemy(2, 1);
					break;
				case 6:
					gb1WavController.LaunchEnemy(2, 1);
					break;
				case 7:
					gb1WavController.LaunchEnemy(2, 1);
					break;
				case 12:
					gb1WavController.LaunchEnemy(2, 1);
					break;
				case 13:
					gb1WavController.LaunchEnemy(2, 1);
					break;
				case 14:
					gb1WavController.LaunchEnemy(2, 1);
					break;
				case 15:
					gb1WavController.LaunchEnemy(2, 1);
					break;
				}
			}
		}
		else if (metronome.measure == 4 || metronome.measure == 8 || metronome.measure == 12 || metronome.measure == 16)
		{
			if (metronome.onSixteenth == true)
			{
				switch(metronome.sixteenthNote)
				{
				case 0:
					gb1WavController.LaunchEnemy(2, 1);
					break;
				case 1:
					gb1WavController.LaunchEnemy(2, 1);
					break;
				case 2:
					gb1WavController.LaunchEnemy(2, 1);
					break;
				case 3:
					gb1WavController.LaunchEnemy(2, 1);
					break;
				case 4:
					gb1WavController.LaunchEnemy(2, 1);
					break;
				case 5:
					gb1WavController.LaunchEnemy(2, 1);
					break;
				case 6:
					gb1WavController.LaunchEnemy(2, 1);
					break;
				case 7:
					gb1WavController.LaunchEnemy(2, 1);
					break;
				}
			}
		}
	}

	void SongSectionOne()
	{
		gb1WavController.transform.position = new Vector2(-6, 0);
		glitchController.transform.position = new Vector2(6, 0);
		hatController.transform.position = new Vector2(0, 6);
		gb1Pul2Controller.transform.position = new Vector2(0, -6);

		if (metronome.onSixteenth == true)
		{
			switch(metronome.sixteenthNote)
			{
			case 2:
				glitchController.LaunchEnemy(1, 1);
				break;
			case 5:
				glitchController.LaunchEnemy(1, 1);
				break;
			case 6:
				glitchController.LaunchEnemy(1, 2);
				break;
			case 8:
				glitchController.LaunchEnemy(1, 1);
				break;
			}
		}

		if (metronome.measure % 2 == 1)
		{
			if (metronome.onSixteenth == true)
			{
				switch(metronome.sixteenthNote)
				{
				case 2:
					hatController.LaunchEnemy(2, 1);
					break;
				case 3:
					hatController.LaunchEnemy(2, 1);
					break;
				case 4:
					hatController.LaunchEnemy(2, 1);
					break;
				case 11:
					hatController.LaunchEnemy(2, 1);
					break;
				case 12:
					hatController.LaunchEnemy(2, 1);
					break;
				}
			}
		}
		else if (metronome.measure % 2 == 0)
		{
			if (metronome.onSixteenth == true)
			{
				switch(metronome.sixteenthNote)
				{
				case 2:
					hatController.LaunchEnemy(2, 1);
					break;
				case 3:
					hatController.LaunchEnemy(2, 1);
					break;
				case 4:
					hatController.LaunchEnemy(2, 1);
					break;
				case 5:
					hatController.LaunchEnemy(2, 1);
					break;
				case 10:
					hatController.LaunchEnemy(2, 1);
					break;
				case 11:
					hatController.LaunchEnemy(2, 1);
					break;
				case 12:
					hatController.LaunchEnemy(2, 1);
					break;
				}
			}
		}

		if (metronome.measure == 1 || metronome.measure == 2 || metronome.measure == 5 || metronome.measure == 6 || metronome.measure == 9 || metronome.measure == 10 || metronome.measure == 13 || metronome.measure == 14)
		{
			if (metronome.onSixteenth == true)
			{
				switch(metronome.sixteenthNote)
				{
				case 0:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 1:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 2:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 3:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 4:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 5:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 6:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 7:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				}
			}
		}
		if (metronome.measure == 3 || metronome.measure == 7 || metronome.measure == 11 || metronome.measure == 15)
		{
			if (metronome.onSixteenth == true)
			{
				switch(metronome.sixteenthNote)
				{
				case 0:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 1:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 2:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 3:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 4:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 5:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 6:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 7:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 12:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 13:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 14:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 15:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				}
			}
		}
		else if (metronome.measure == 4 || metronome.measure == 8 || metronome.measure == 12 || metronome.measure == 16)
		{
			if (metronome.onSixteenth == true)
			{
				switch(metronome.sixteenthNote)
				{
				case 0:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 1:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 2:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 3:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 4:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 5:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 6:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 7:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				}
			}
		}
	}

	void SongSectionTwo()
	{
		gb1WavController.transform.position = new Vector2(-6, 0);
		glitchController.transform.position = new Vector2(6, 0);
		hatController.transform.position = new Vector2(0, 6);
		gb1Pul2Controller.transform.position = new Vector2(0, -6);
		gb1Pul1Controller.transform.position = new Vector2(12, 12);
		snareController.transform.position = new Vector2(-12, -12);
		
		if (metronome.onSixteenth == true)
		{
			switch(metronome.sixteenthNote)
			{
			case 2:
				glitchController.LaunchEnemy(1, 1);
				break;
			case 5:
				glitchController.LaunchEnemy(1, 1);
				break;
			case 6:
				glitchController.LaunchEnemy(1, 2);
				break;
			case 8:
				glitchController.LaunchEnemy(1, 1);
				break;
			}
		}
		
		if (metronome.measure % 2 == 1)
		{
			if (metronome.onSixteenth == true)
			{
				switch(metronome.sixteenthNote)
				{
				case 2:
					hatController.LaunchEnemy(2, 1);
					break;
				case 3:
					hatController.LaunchEnemy(2, 1);
					break;
				case 4:
					hatController.LaunchEnemy(2, 1);
					break;
				case 8:
					snareController.LaunchEnemy(1, 3);
					break;
				case 11:
					hatController.LaunchEnemy(2, 1);
					break;
				case 12:
					hatController.LaunchEnemy(2, 1);
					break;
				}
			}
		}
		else if (metronome.measure % 2 == 0)
		{
			if (metronome.onSixteenth == true)
			{
				switch(metronome.sixteenthNote)
				{
				case 2:
					hatController.LaunchEnemy(2, 1);
					break;
				case 3:
					hatController.LaunchEnemy(2, 1);
					break;
				case 4:
					hatController.LaunchEnemy(2, 1);
					break;
				case 5:
					hatController.LaunchEnemy(2, 1);
					break;
				case 8:
					snareController.LaunchEnemy(1, 3);
					break;
				case 10:
					hatController.LaunchEnemy(2, 1);
					break;
				case 11:
					hatController.LaunchEnemy(2, 1);
					break;
				case 12:
					hatController.LaunchEnemy(2, 1);
					break;
				}
			}
		}

		if (metronome.measure % 4 == 1)
		{
			if (metronome.onSixteenth == true)
			{
				switch(metronome.sixteenthNote)
				{
				case 0:
					gb1Pul1Controller.LaunchEnemy(1, 2);
					break;
				case 2:
					gb1Pul1Controller.LaunchEnemy(1, 2);
					break;
				case 4:
					gb1Pul1Controller.LaunchEnemy(1, 2);
					break;
				}
			}
		}
		
		if (metronome.measure == 1 || metronome.measure == 2 || metronome.measure == 5 || metronome.measure == 6 || metronome.measure == 9 || metronome.measure == 10 || metronome.measure == 13 || metronome.measure == 14)
		{
			if (metronome.onSixteenth == true)
			{
				switch(metronome.sixteenthNote)
				{
				case 0:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 1:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 2:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 3:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 4:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 5:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 6:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 7:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				}
			}
		}
		if (metronome.measure == 3 || metronome.measure == 7 || metronome.measure == 11 || metronome.measure == 15)
		{
			if (metronome.onSixteenth == true)
			{
				switch(metronome.sixteenthNote)
				{
				case 0:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 1:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 2:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 3:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 4:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 5:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 6:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 7:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 12:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 13:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 14:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 15:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				}
			}
		}
		else if (metronome.measure == 4 || metronome.measure == 8 || metronome.measure == 12 || metronome.measure == 16)
		{
			if (metronome.onSixteenth == true)
			{
				switch(metronome.sixteenthNote)
				{
				case 0:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 1:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 2:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 3:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 4:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 5:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 6:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 7:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				}
			}
		}
	}

	void SongSectionThree()
	{
		gb1WavController.transform.position = new Vector2(-6, 0);
		glitchController.transform.position = new Vector2(6, 0);
		hatController.transform.position = new Vector2(0, 6);
		gb1Pul2Controller.transform.position = new Vector2(0, -6);
		gb1Pul1Controller.transform.position = new Vector2(12, 12);
		snareController.transform.position = new Vector2(-12, -12);
		kickController.transform.position = new Vector2(12, -12);
		clapController.transform.position = new Vector2(-12, 12);
		
		if (metronome.onSixteenth == true)
		{
			switch(metronome.sixteenthNote)
			{
			case 2:
				glitchController.LaunchEnemy(1, 1);
				break;
			case 5:
				glitchController.LaunchEnemy(1, 1);
				break;
			case 6:
				glitchController.LaunchEnemy(1, 2);
				break;
			case 8:
				glitchController.LaunchEnemy(1, 1);
				break;
			}
		}
		
		if (metronome.measure % 2 == 1)
		{
			if (metronome.onSixteenth == true)
			{
				switch(metronome.sixteenthNote)
				{
				case 2:
					hatController.LaunchEnemy(2, 1);
					break;
				case 3:
					hatController.LaunchEnemy(2, 1);
					break;
				case 4:
					hatController.LaunchEnemy(2, 1);
					break;
				case 8:
					snareController.LaunchEnemy(1, 3);
					break;
				case 11:
					hatController.LaunchEnemy(2, 1);
					break;
				case 12:
					hatController.LaunchEnemy(2, 1);
					break;
				}
			}
		}
		else if (metronome.measure % 2 == 0)
		{
			if (metronome.onSixteenth == true)
			{
				switch(metronome.sixteenthNote)
				{
				case 2:
					hatController.LaunchEnemy(2, 1);
					break;
				case 3:
					hatController.LaunchEnemy(2, 1);
					break;
				case 4:
					hatController.LaunchEnemy(2, 1);
					break;
				case 5:
					hatController.LaunchEnemy(2, 1);
					break;
				case 8:
					snareController.LaunchEnemy(1, 3);
					break;
				case 10:
					hatController.LaunchEnemy(2, 1);
					break;
				case 11:
					hatController.LaunchEnemy(2, 1);
					break;
				case 12:
					hatController.LaunchEnemy(2, 1);
					break;
				}
			}
		}
		
		if (metronome.measure % 4 == 1)
		{
			if (metronome.onSixteenth == true)
			{
				switch(metronome.sixteenthNote)
				{
				case 0:
					gb1Pul1Controller.LaunchEnemy(1, 2);
					break;
				case 2:
					gb1Pul1Controller.LaunchEnemy(1, 2);
					break;
				case 4:
					gb1Pul1Controller.LaunchEnemy(1, 2);
					break;
				}
			}
		}

		if (metronome.measure % 4 == 0)
		{
			if (metronome.onSixteenth == true)
			{
				switch(metronome.sixteenthNote)
				{
				case 8:
					clapController.LaunchEnemy(3, 10);
					break;
				case 10:
					kickController.LaunchEnemy(2, 3);
					break;
				}
			}
		}

		if (metronome.measure % 2 == 1)
		{
			if (metronome.onSixteenth == true)
			{
				switch(metronome.sixteenthNote)
				{
				case 0:
					kickController.LaunchEnemy(2, 3);
					break;
				case 6:
					kickController.LaunchEnemy(2, 3);
					break;
				}
			}
		}
		
		if (metronome.measure == 1 || metronome.measure == 2 || metronome.measure == 5 || metronome.measure == 6 || metronome.measure == 9 || metronome.measure == 10 || metronome.measure == 13 || metronome.measure == 14)
		{
			if (metronome.onSixteenth == true)
			{
				switch(metronome.sixteenthNote)
				{
				case 0:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 1:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 2:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 3:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 4:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 5:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 6:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 7:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				}
			}
		}
		if (metronome.measure == 3 || metronome.measure == 7 || metronome.measure == 11 || metronome.measure == 15)
		{
			if (metronome.onSixteenth == true)
			{
				switch(metronome.sixteenthNote)
				{
				case 0:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 1:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 2:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 3:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 4:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 5:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 6:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 7:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 12:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 13:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 14:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 15:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				}
			}
		}
		else if (metronome.measure == 4 || metronome.measure == 8 || metronome.measure == 12 || metronome.measure == 16)
		{
			if (metronome.onSixteenth == true)
			{
				switch(metronome.sixteenthNote)
				{
				case 0:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 1:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 2:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 3:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 4:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 5:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 6:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 7:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				}
			}
		}
	}

	void SongSectionFour()
	{
		gb1WavController.transform.position = new Vector2(-6, 0);
		glitchController.transform.position = new Vector2(6, 0);
		hatController.transform.position = new Vector2(0, 6);
		gb1Pul2Controller.transform.position = new Vector2(0, -6);
		gb1Pul1Controller.transform.position = new Vector2(12, 12);
		snareController.transform.position = new Vector2(-12, -12);
		kickController.transform.position = new Vector2(12, -12);
		clapController.transform.position = new Vector2(-12, 12);
		gb2Pul1Controller.transform.position = new Vector2(14, 0);
		
		if (metronome.onSixteenth == true)
		{
			switch(metronome.sixteenthNote)
			{
			case 2:
				gb2Pul1Controller.LaunchEnemy(2, 1);
				glitchController.LaunchEnemy(1, 1);
				break;
			case 3:
				gb2Pul1Controller.LaunchEnemy(2, 1);
				break;
				glitchController.LaunchEnemy(1, 1);
				break;
			case 6:
				gb2Pul1Controller.LaunchEnemy(2, 1);
				glitchController.LaunchEnemy(1, 2);
				break;
			case 7:
				gb2Pul1Controller.LaunchEnemy(2, 1);
				break;
			case 8:
				glitchController.LaunchEnemy(1, 1);
				break;
			case 10:
				gb2Pul1Controller.LaunchEnemy(2, 1);
				break;
			case 11:
				gb2Pul1Controller.LaunchEnemy(2, 1);
				break;
			case 14:
				gb2Pul1Controller.LaunchEnemy(2, 1);
				break;
			case 15:
				gb2Pul1Controller.LaunchEnemy(2, 1);
				break;
			}
		}

		
		if (metronome.measure % 2 == 1)
		{
			if (metronome.onSixteenth == true)
			{
				switch(metronome.sixteenthNote)
				{
				case 2:
					hatController.LaunchEnemy(2, 1);
					break;
				case 3:
					hatController.LaunchEnemy(2, 1);
					break;
				case 4:
					hatController.LaunchEnemy(2, 1);
					break;
				case 8:
					snareController.LaunchEnemy(1, 3);
					break;
				case 11:
					hatController.LaunchEnemy(2, 1);
					break;
				case 12:
					hatController.LaunchEnemy(2, 1);
					break;
				}
			}
		}
		else if (metronome.measure % 2 == 0)
		{
			if (metronome.onSixteenth == true)
			{
				switch(metronome.sixteenthNote)
				{
				case 2:
					hatController.LaunchEnemy(2, 1);
					break;
				case 3:
					hatController.LaunchEnemy(2, 1);
					break;
				case 4:
					hatController.LaunchEnemy(2, 1);
					break;
				case 5:
					hatController.LaunchEnemy(2, 1);
					break;
				case 8:
					snareController.LaunchEnemy(1, 3);
					break;
				case 10:
					hatController.LaunchEnemy(2, 1);
					break;
				case 11:
					hatController.LaunchEnemy(2, 1);
					break;
				case 12:
					hatController.LaunchEnemy(2, 1);
					break;
				}
			}
		}
		
		if (metronome.measure % 4 == 1)
		{
			if (metronome.onSixteenth == true)
			{
				switch(metronome.sixteenthNote)
				{
				case 0:
					gb1Pul1Controller.LaunchEnemy(1, 2);
					break;
				case 2:
					gb1Pul1Controller.LaunchEnemy(1, 2);
					break;
				case 4:
					gb1Pul1Controller.LaunchEnemy(1, 2);
					break;
				}
			}
		}
		
		if (metronome.measure % 4 == 0)
		{
			if (metronome.onSixteenth == true)
			{
				switch(metronome.sixteenthNote)
				{
				case 8:
					clapController.LaunchEnemy(3, 10);
					break;
				case 10:
					kickController.LaunchEnemy(2, 3);
					break;
				}
			}
		}
		
		if (metronome.measure % 2 == 1)
		{
			if (metronome.onSixteenth == true)
			{
				switch(metronome.sixteenthNote)
				{
				case 0:
					kickController.LaunchEnemy(2, 3);
					break;
				case 6:
					kickController.LaunchEnemy(2, 3);
					break;
				}
			}
		}
		
		if (metronome.measure == 1 || metronome.measure == 2 || metronome.measure == 5 || metronome.measure == 6 || metronome.measure == 9 || metronome.measure == 10 || metronome.measure == 13 || metronome.measure == 14)
		{
			if (metronome.onSixteenth == true)
			{
				switch(metronome.sixteenthNote)
				{
				case 0:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 1:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 2:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 3:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 4:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 5:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 6:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 7:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				}
			}
		}
		if (metronome.measure == 3 || metronome.measure == 7 || metronome.measure == 11 || metronome.measure == 15)
		{
			if (metronome.onSixteenth == true)
			{
				switch(metronome.sixteenthNote)
				{
				case 0:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 1:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 2:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 3:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 4:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 5:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 6:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 7:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 12:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 13:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 14:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 15:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				}
			}
		}
		else if (metronome.measure == 4 || metronome.measure == 8 || metronome.measure == 12 || metronome.measure == 16)
		{
			if (metronome.onSixteenth == true)
			{
				switch(metronome.sixteenthNote)
				{
				case 0:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 1:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 2:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 3:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 4:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 5:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 6:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 7:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				}
			}
		}
	}

	void SongSectionFive()
	{
		gb1WavController.transform.position = new Vector2(-6, 0);
		glitchController.transform.position = new Vector2(6, 0);
		hatController.transform.position = new Vector2(0, 6);
		gb1Pul2Controller.transform.position = new Vector2(0, -6);
		gb1Pul1Controller.transform.position = new Vector2(12, 12);
		snareController.transform.position = new Vector2(-12, -12);
		kickController.transform.position = new Vector2(12, -12);
		clapController.transform.position = new Vector2(-12, 12);
		gb2Pul1Controller.transform.position = new Vector2(14, 0);
		gb2Pul2AndWavController.transform.position = new Vector2(-14, 0);
		
		if (metronome.onSixteenth == true)
		{
			switch(metronome.sixteenthNote)
			{
			case 1:
				gb2Pul2AndWavController.LaunchEnemy(2, 1);
				break;
			case 2:
				gb2Pul2AndWavController.LaunchEnemy(2, 1);
				gb2Pul1Controller.LaunchEnemy(2, 1);
				glitchController.LaunchEnemy(1, 1);
				break;
			case 3:
				gb2Pul1Controller.LaunchEnemy(2, 1);
				break;
			case 5:
				gb2Pul2AndWavController.LaunchEnemy(2, 1);
				glitchController.LaunchEnemy(1, 1);
				break;
			case 6:
				gb2Pul2AndWavController.LaunchEnemy(2, 1);
				gb2Pul1Controller.LaunchEnemy(2, 1);
				glitchController.LaunchEnemy(1, 2);
				break;
			case 7:
				gb2Pul1Controller.LaunchEnemy(2, 1);
				break;
			case 8:
				glitchController.LaunchEnemy(1, 1);
				break;
			case 9:
				gb2Pul2AndWavController.LaunchEnemy(2, 1);
				break;
			case 10:
				gb2Pul2AndWavController.LaunchEnemy(2, 1);
				gb2Pul1Controller.LaunchEnemy(2, 1);
				break;
			case 11:
				gb2Pul1Controller.LaunchEnemy(2, 1);
				break;
			case 13:
				gb2Pul2AndWavController.LaunchEnemy(2, 1);
				break;
			case 14:
				gb2Pul2AndWavController.LaunchEnemy(2, 1);
				gb2Pul1Controller.LaunchEnemy(2, 1);
				break;
			case 15:
				gb2Pul1Controller.LaunchEnemy(2, 1);
				break;
			}
		}
		
		
		if (metronome.measure % 2 == 1)
		{
			if (metronome.onSixteenth == true)
			{
				switch(metronome.sixteenthNote)
				{
				case 2:
					hatController.LaunchEnemy(2, 1);
					break;
				case 3:
					hatController.LaunchEnemy(2, 1);
					break;
				case 4:
					hatController.LaunchEnemy(2, 1);
					break;
				case 8:
					snareController.LaunchEnemy(1, 3);
					break;
				case 11:
					hatController.LaunchEnemy(2, 1);
					break;
				case 12:
					hatController.LaunchEnemy(2, 1);
					break;
				}
			}
		}
		else if (metronome.measure % 2 == 0)
		{
			if (metronome.onSixteenth == true)
			{
				switch(metronome.sixteenthNote)
				{
				case 2:
					hatController.LaunchEnemy(2, 1);
					break;
				case 3:
					hatController.LaunchEnemy(2, 1);
					break;
				case 4:
					hatController.LaunchEnemy(2, 1);
					break;
				case 5:
					hatController.LaunchEnemy(2, 1);
					break;
				case 8:
					snareController.LaunchEnemy(1, 3);
					break;
				case 10:
					hatController.LaunchEnemy(2, 1);
					break;
				case 11:
					hatController.LaunchEnemy(2, 1);
					break;
				case 12:
					hatController.LaunchEnemy(2, 1);
					break;
				}
			}
		}
		
		if (metronome.measure % 4 == 1)
		{
			if (metronome.onSixteenth == true)
			{
				switch(metronome.sixteenthNote)
				{
				case 0:
					gb1Pul1Controller.LaunchEnemy(1, 2);
					break;
				case 2:
					gb1Pul1Controller.LaunchEnemy(1, 2);
					break;
				case 4:
					gb1Pul1Controller.LaunchEnemy(1, 2);
					break;
				}
			}
		}
		
		if (metronome.measure % 4 == 0)
		{
			if (metronome.onSixteenth == true)
			{
				switch(metronome.sixteenthNote)
				{
				case 8:
					clapController.LaunchEnemy(3, 10);
					break;
				case 10:
					kickController.LaunchEnemy(2, 3);
					break;
				}
			}
		}
		
		if (metronome.measure % 2 == 1)
		{
			if (metronome.onSixteenth == true)
			{
				switch(metronome.sixteenthNote)
				{
				case 0:
					kickController.LaunchEnemy(2, 3);
					break;
				case 6:
					kickController.LaunchEnemy(2, 3);
					break;
				}
			}
		}
		
		if (metronome.measure == 1 || metronome.measure == 2 || metronome.measure == 5 || metronome.measure == 6 || metronome.measure == 9 || metronome.measure == 10 || metronome.measure == 13 || metronome.measure == 14)
		{
			if (metronome.onSixteenth == true)
			{
				switch(metronome.sixteenthNote)
				{
				case 0:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 1:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 2:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 3:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 4:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 5:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 6:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 7:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				}
			}
		}
		if (metronome.measure == 3 || metronome.measure == 7 || metronome.measure == 11 || metronome.measure == 15)
		{
			if (metronome.onSixteenth == true)
			{
				switch(metronome.sixteenthNote)
				{
				case 0:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 1:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 2:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 3:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 4:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 5:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 6:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 7:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 12:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 13:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 14:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 15:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				}
			}
		}
		else if (metronome.measure == 4 || metronome.measure == 8 || metronome.measure == 12 || metronome.measure == 16)
		{
			if (metronome.onSixteenth == true)
			{
				switch(metronome.sixteenthNote)
				{
				case 0:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 1:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 2:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 3:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 4:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 5:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 6:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 7:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
			}
			}
		}
	}

	void SongSectionSix()
	{
		gb1WavController.transform.position = new Vector2(-6, 0);
		glitchController.transform.position = new Vector2(6, 0);
		gb1Pul2Controller.transform.position = new Vector2(0, -6);
		gb1Pul1Controller.transform.position = new Vector2(0, 6);
		
		if (metronome.onSixteenth == true)
		{
			switch(metronome.sixteenthNote)
			{
			case 2:
				glitchController.LaunchEnemy(1, 1);
				break;
			case 5:
				glitchController.LaunchEnemy(1, 1);
				break;
			case 6:
				glitchController.LaunchEnemy(1, 2);
				break;
			case 8:
				glitchController.LaunchEnemy(1, 1);
				break;
			}
		}
		
		if (metronome.measure % 4 == 1)
		{
			if (metronome.onSixteenth == true)
			{
				switch(metronome.sixteenthNote)
				{
				case 0:
					gb1Pul1Controller.LaunchEnemy(1, 2);
					break;
				case 2:
					gb1Pul1Controller.LaunchEnemy(1, 2);
					break;
				case 4:
					gb1Pul1Controller.LaunchEnemy(1, 2);
					break;
				}
			}
		}
		
		if (metronome.measure % 4 == 0)
		{
			if (metronome.onSixteenth == true)
			{
				switch(metronome.sixteenthNote)
				{
				case 8:
					clapController.LaunchEnemy(3, 10);
					break;
				case 10:
					kickController.LaunchEnemy(2, 3);
					break;
				}
			}
		}
		
		if (metronome.measure == 1 || metronome.measure == 2 || metronome.measure == 5 || metronome.measure == 6 || metronome.measure == 9 || metronome.measure == 10 || metronome.measure == 13 || metronome.measure == 14)
		{
			if (metronome.onSixteenth == true)
			{
				switch(metronome.sixteenthNote)
				{
				case 0:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 1:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 2:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 3:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 4:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 5:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 6:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 7:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				}
			}
		}
		if (metronome.measure == 3 || metronome.measure == 7 || metronome.measure == 11 || metronome.measure == 15)
		{
			if (metronome.onSixteenth == true)
			{
				switch(metronome.sixteenthNote)
				{
				case 0:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 1:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 2:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 3:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 4:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 5:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 6:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 7:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 12:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 13:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 14:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 15:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				}
			}
		}
		else if (metronome.measure == 4 || metronome.measure == 8 || metronome.measure == 12 || metronome.measure == 16)
		{
			if (metronome.onSixteenth == true)
			{
				switch(metronome.sixteenthNote)
				{
				case 0:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 1:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 2:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 3:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 4:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 5:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 6:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 7:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				}
			}
		}
	}

	void SongSectionSeven()
	{
		gb1WavController.transform.position = new Vector2(-6, 0);
		glitchController.transform.position = new Vector2(6, 0);
		gb1Pul2Controller.transform.position = new Vector2(0, -6);
		gb1Pul1Controller.transform.position = new Vector2(0, 6);
		gb2Pul1Controller.transform.position = new Vector2(12, 12);
		hatController.transform.position = new Vector2(-12, 12);
		snareController.transform.position = new Vector2(0, -12);
		
		if (metronome.onSixteenth == true)
		{
			switch(metronome.sixteenthNote)
			{
			case 2:
				glitchController.LaunchEnemy(1, 1);
				break;
			case 5:
				glitchController.LaunchEnemy(1, 1);
				break;
			case 6:
				glitchController.LaunchEnemy(1, 2);
				break;
			case 8:
				glitchController.LaunchEnemy(1, 1);
				break;
			}
		}

		if (metronome.onSixteenth == true)
		{
			switch(metronome.sixteenthNote)
			{
			case 8:
				snareController.LaunchEnemy(1, 3);
				break;
			}
		}

		if (metronome.measure < 15)
		{
			if (metronome.onSixteenth == true)
			{
				switch(metronome.sixteenthNote)
				{
				case 0:
					hatController.LaunchEnemy (2, 1);
					break;
				case 2:
					hatController.LaunchEnemy (2, 1);
					break;
				case 6:
					hatController.LaunchEnemy (2, 1);
					break;
				case 8:
					snareController.LaunchEnemy(1, 3);
					hatController.LaunchEnemy (2, 1);
					break;
				case 10:
					hatController.LaunchEnemy (2, 1);
					break;
				case 14:
					hatController.LaunchEnemy (2, 1);
					break;
				}
			}
		}
		else if (metronome.measure >= 15)
		{
			if (metronome.onSixteenth == true)
			{
				switch(metronome.sixteenthNote)
				{
				case 0:
					snareController.LaunchEnemy(1, 3);
					hatController.LaunchEnemy (2, 1);
					break;
				case 2:
					snareController.LaunchEnemy(1, 3);
					hatController.LaunchEnemy (2, 1);
					break;
				case 4:
					snareController.LaunchEnemy(1, 3);
					hatController.LaunchEnemy (2, 1);
					break;
				case 6:
					snareController.LaunchEnemy(1, 3);
					hatController.LaunchEnemy (2, 1);
					break;
				case 8:
					snareController.LaunchEnemy(1, 3);
					hatController.LaunchEnemy (2, 1);
					break;
				case 10:
					snareController.LaunchEnemy(1, 3);
					hatController.LaunchEnemy (2, 1);
					break;
				case 12:
					snareController.LaunchEnemy(1, 3);
					hatController.LaunchEnemy (2, 1);
					break;
				case 14:
					snareController.LaunchEnemy(1, 3);
					hatController.LaunchEnemy (2, 1);
					break;
				}
			}
			else if (metronome.measure == 16)
			{
				switch(metronome.sixteenthNote)
				{
				case 0:
					snareController.LaunchEnemy(1, 1);
					break;
				case 2:
					snareController.LaunchEnemy(1, 1);
					break;
				case 3:
					snareController.LaunchEnemy(1, 1);
					break;
				case 4:
					snareController.LaunchEnemy(1, 1);
					break;
				case 6:
					snareController.LaunchEnemy(1, 1);
					break;
				case 7:
					snareController.LaunchEnemy(1, 1);
					break;
				case 8:
					snareController.LaunchEnemy(1, 1);
					break;
				case 10:
					snareController.LaunchEnemy(1, 1);
					break;
				case 11:
					snareController.LaunchEnemy(1, 1);
					break;
				case 12:
					snareController.LaunchEnemy(1, 1);
					break;
				case 14:
					snareController.LaunchEnemy(1, 1);
					break;
				case 15:
					snareController.LaunchEnemy(1, 1);
					break;
				}
			}
		}
		
		if (metronome.measure % 4 == 1)
		{
			if (metronome.onSixteenth == true)
			{
				switch(metronome.sixteenthNote)
				{
				case 0:
					gb1Pul1Controller.LaunchEnemy(1, 2);
					break;
				case 2:
					gb1Pul1Controller.LaunchEnemy(1, 2);
					break;
				case 4:
					gb1Pul1Controller.LaunchEnemy(1, 2);
					break;
				}
			}
		}
		
		if (metronome.measure % 4 == 0)
		{
			if (metronome.onSixteenth == true)
			{
				switch(metronome.sixteenthNote)
				{
				case 8:
					clapController.LaunchEnemy(3, 10);
					break;
				case 10:
					kickController.LaunchEnemy(2, 3);
					break;
				}
			}
		}

		if (metronome.onSixteenth == true)
		{
			switch(metronome.sixteenthNote)
			{
			case 2:
				gb2Pul1Controller.LaunchEnemy(2, 1);
				break;
			case 3:
				gb2Pul1Controller.LaunchEnemy(2, 1);
				break;
			case 6:
				gb2Pul1Controller.LaunchEnemy(2, 1);
				break;
			case 7:
				gb2Pul1Controller.LaunchEnemy(2, 1);
				break;
			case 10:
				gb2Pul1Controller.LaunchEnemy(2, 1);
				break;
			case 11:
				gb2Pul1Controller.LaunchEnemy(2, 1);
				break;
			case 14:
				gb2Pul1Controller.LaunchEnemy(2, 1);
				break;
			case 15:
				gb2Pul1Controller.LaunchEnemy(2, 1);
				break;
			}
		}


		
		if (metronome.measure == 1 || metronome.measure == 2 || metronome.measure == 5 || metronome.measure == 6 || metronome.measure == 9 || metronome.measure == 10 || metronome.measure == 13 || metronome.measure == 14)
		{
			if (metronome.onSixteenth == true)
			{
				switch(metronome.sixteenthNote)
				{
				case 0:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 1:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 2:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 3:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 4:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 5:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 6:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 7:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				}
			}
		}
		if (metronome.measure == 3 || metronome.measure == 7 || metronome.measure == 11 || metronome.measure == 15)
		{
			if (metronome.onSixteenth == true)
			{
				switch(metronome.sixteenthNote)
				{
				case 0:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 1:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 2:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 3:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 4:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 5:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 6:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 7:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 12:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 13:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 14:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 15:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				}
			}
		}
		else if (metronome.measure == 4 || metronome.measure == 8 || metronome.measure == 12 || metronome.measure == 16)
		{
			if (metronome.onSixteenth == true)
			{
				switch(metronome.sixteenthNote)
				{
				case 0:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 1:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 2:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 3:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 4:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 5:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 6:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 7:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				}
			}
		}
	}

	void SongSectionEight()
	{
		gb1WavController.transform.position = new Vector2(-6, 0);
		glitchController.transform.position = new Vector2(6, 0);
		gb1Pul2Controller.transform.position = new Vector2(0, -6);
		gb1Pul1Controller.transform.position = new Vector2(0, 6);
		gb2Pul1Controller.transform.position = new Vector2(12, 12);
		hatController.transform.position = new Vector2(-12, 12); //redo
		snareController.transform.position = new Vector2(12, -12);
		kickController.transform.position = new Vector2(-12, -12); //redo
		gb2Pul2AndWavController.transform.position = new Vector2(-16, 0);
		clapController.transform.position = new Vector2(16, 0);

		if (metronome.onSixteenth == true)
		{
			switch(metronome.sixteenthNote)
			{
			case 1:
				gb2Pul2AndWavController.LaunchEnemy(2, 1);
				break;
			case 2:
				gb2Pul2AndWavController.LaunchEnemy(2, 1);
				break;
			case 5:
				gb2Pul2AndWavController.LaunchEnemy(2, 1);
				break;
			case 6:
				gb2Pul2AndWavController.LaunchEnemy(2, 1);
				break;
			case 9:
				gb2Pul2AndWavController.LaunchEnemy(2, 1);
				break;
			case 10:
				gb2Pul2AndWavController.LaunchEnemy(2, 1);
				break;
			case 13:
				gb2Pul2AndWavController.LaunchEnemy(2, 1);
				break;
			case 14:
				gb2Pul2AndWavController.LaunchEnemy(2, 1);
				break;
			}
		}
		
		if (metronome.onSixteenth == true)
		{
			switch(metronome.sixteenthNote)
			{
			case 2:
				glitchController.LaunchEnemy(1, 1);
				break;
			case 5:
				glitchController.LaunchEnemy(1, 1);
				break;
			case 6:
				glitchController.LaunchEnemy(1, 2);
				break;
			case 8:
				glitchController.LaunchEnemy(1, 1);
				break;
			}
		}
		
		if (metronome.onSixteenth == true)
		{
			switch(metronome.sixteenthNote)
			{
			case 0:
				hatController.LaunchEnemy(2, 1);
				break;
			case 1:
				hatController.LaunchEnemy(2, 1);
				break;
			case 2:
				hatController.LaunchEnemy(2, 1);
				break;
			case 3:
				hatController.LaunchEnemy(2, 1);
				break;
			case 4:
				hatController.LaunchEnemy(2, 1);
				break;
			case 5:
				hatController.LaunchEnemy(2, 1);
				break;
			case 6:
				hatController.LaunchEnemy(2, 1);
				break;
			case 7:
				hatController.LaunchEnemy(2, 1);
				break;
			case 8:
				hatController.LaunchEnemy(2, 1);
				snareController.LaunchEnemy(1, 3);
				break;
			case 9:
				hatController.LaunchEnemy(2, 1);
				break;
			case 10:
				hatController.LaunchEnemy(2, 1);
				break;
			case 11:
				hatController.LaunchEnemy(2, 1);
				break;
			case 12:
				hatController.LaunchEnemy(2, 1);
				break;
			case 13:
				hatController.LaunchEnemy(2, 1);
				break;
			case 14:
				hatController.LaunchEnemy(2, 1);
				break;
			case 15:
				hatController.LaunchEnemy(2, 1);
				break;
			}
			if (metronome.measure % 4 == 0)
			{
				switch(metronome.sixteenthNote)
				{
				case 2:
					hatController.LaunchEnemy(2, 4);
					break;
				case 4:
					hatController.LaunchEnemy(2, 4);
					break;
				case 6:
					hatController.LaunchEnemy(2, 4);
					snareController.LaunchEnemy(1, 3);
					break;
				case 8:
					snareController.LaunchEnemy(1, 3);
					break;
				case 9:
					hatController.LaunchEnemy(2, 1);
					break;
				case 10:
					hatController.LaunchEnemy(2, 1);
					break;
				case 11:
					hatController.LaunchEnemy(2, 1);
					break;
				case 12:
					hatController.LaunchEnemy(2, 1);
					break;
				case 13:
					hatController.LaunchEnemy(2, 1);
					break;
				case 14:
					hatController.LaunchEnemy(2, 1);
					break;
				case 15:
					hatController.LaunchEnemy(2, 1);
					break;
				}
			}
		}
		

		
		if (metronome.measure % 4 == 1)
		{
			if (metronome.onSixteenth == true)
			{
				switch(metronome.sixteenthNote)
				{
				case 0:
					gb1Pul1Controller.LaunchEnemy(1, 2);
					break;
				case 2:
					gb1Pul1Controller.LaunchEnemy(1, 2);
					break;
				case 4:
					gb1Pul1Controller.LaunchEnemy(1, 2);
					break;
				}
			}
		}

		if (metronome.measure == 1 || metronome.measure == 5 || metronome.measure == 9 || metronome.measure == 13)
		{
			if (metronome.onSixteenth == true)
			{
				switch(metronome.sixteenthNote)
				{
				case 0:
					kickController.LaunchEnemy(1, 2);
					break;
				case 6:
					kickController.LaunchEnemy(1, 2);
					break;
				case 10:
					kickController.LaunchEnemy(1, 2);
					break;
				}
			}
		}
		else if (metronome.measure == 2 || metronome.measure == 6 || metronome.measure == 10 || metronome.measure == 14)
		{
			if (metronome.onSixteenth == true)
			{
				switch(metronome.sixteenthNote)
				{
				case 2:
					kickController.LaunchEnemy(1, 2);
					break;
				case 6:
					kickController.LaunchEnemy(1, 2);
					break;
				}
			}
		}
		else if (metronome.measure == 3 || metronome.measure == 7 || metronome.measure == 11 || metronome.measure == 15)
		{
			if (metronome.onSixteenth == true)
			{
				switch(metronome.sixteenthNote)
				{
				case 0:
					kickController.LaunchEnemy(1, 2);
					break;
				case 6:
					kickController.LaunchEnemy(1, 2);
					break;
				}
			}
		}
		else if (metronome.measure == 4 || metronome.measure == 8 || metronome.measure == 12 || metronome.measure == 16)
		{
			if (metronome.onSixteenth == true)
			{
				switch(metronome.sixteenthNote)
				{
				case 2:
					kickController.LaunchEnemy(1, 2);
					break;
				case 6:
					kickController.LaunchEnemy(1, 2);
					break;
				case 10:
					kickController.LaunchEnemy(1, 2);
					break;
				}
			}
		}
		
		if (metronome.measure % 4 == 0)
		{
			if (metronome.onSixteenth == true)
			{
				switch(metronome.sixteenthNote)
				{
				case 8:
					clapController.LaunchEnemy(3, 10);
					break;
				case 10:
					kickController.LaunchEnemy(2, 3);
					break;
				}
			}
		}
		
		if (metronome.onSixteenth == true)
		{
			switch(metronome.sixteenthNote)
			{
			case 2:
				gb2Pul1Controller.LaunchEnemy(2, 1);
				break;
			case 3:
				gb2Pul1Controller.LaunchEnemy(2, 1);
				break;
			case 6:
				gb2Pul1Controller.LaunchEnemy(2, 1);
				break;
			case 7:
				gb2Pul1Controller.LaunchEnemy(2, 1);
				break;
			case 10:
				gb2Pul1Controller.LaunchEnemy(2, 1);
				break;
			case 11:
				gb2Pul1Controller.LaunchEnemy(2, 1);
				break;
			case 14:
				gb2Pul1Controller.LaunchEnemy(2, 1);
				break;
			case 15:
				gb2Pul1Controller.LaunchEnemy(2, 1);
				break;
			}
		}
		
		if (metronome.measure == 1 || metronome.measure == 2 || metronome.measure == 5 || metronome.measure == 6 || metronome.measure == 9 || metronome.measure == 10 || metronome.measure == 13 || metronome.measure == 14)
		{
			if (metronome.onSixteenth == true)
			{
				switch(metronome.sixteenthNote)
				{
				case 0:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 1:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 2:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 3:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 4:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 5:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 6:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 7:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				}
			}
		}
		if (metronome.measure == 3 || metronome.measure == 7 || metronome.measure == 11 || metronome.measure == 15)
		{
			if (metronome.onSixteenth == true)
			{
				switch(metronome.sixteenthNote)
				{
				case 0:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 1:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 2:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 3:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 4:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 5:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 6:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 7:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 12:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 13:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 14:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 15:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				}
			}
		}
		else if (metronome.measure == 4 || metronome.measure == 8 || metronome.measure == 12 || metronome.measure == 16)
		{
			if (metronome.onSixteenth == true)
			{
				switch(metronome.sixteenthNote)
				{
				case 0:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 1:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 2:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 3:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 4:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 5:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 6:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				case 7:
					gb1WavController.LaunchEnemy(2, 1);
					gb1Pul2Controller.LaunchEnemy(2, 1);
					break;
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (cameraColor.r < 1f)
		{
			cameraColor.r += .01f;
		}

		if (cameraColor.g < 1f)
		{
			cameraColor.g += .01f;
		}

		if (cameraColor.b < 1)
		{
			cameraColor.b += .01f;
		}

		theCamera.backgroundColor = cameraColor;
		UpdateCameraSize();
	}

	void FixedUpdate()
	{

		if (audioXFade.songSection == 0)
		{
			gb1WavController.colorWorks = true;
			gb1WavController.instrumentColor = new Color(.75f, .75f, 1f);
			SongSectionZero();
		}
		else if (audioXFade.songSection == 1)
		{
			gb1WavController.colorWorks = true;
			gb1WavController.instrumentColor = new Color(.5f, .5f, 1f);
			hatActive = true;
			gb1WavActive = true;
			glitchActive = true;
			gb1Pul2Active = true;
			cameraSize = 10f;
			if (activeChecked == false)
			{
				ActiveCheck ();
			}
			SongSectionOne();
		}
		else if (audioXFade.songSection == 2)
		{
			gb1WavController.colorWorks = false;
			gb1Pul1Controller.colorWorks = true;
			snareController.colorWorks = true;
			gb1Pul1Controller.instrumentColor = new Color(1f, .5f, .5f);
			snareController.instrumentColor = new Color(.65f, .65f, .65f);
			gb1Pul1Active = true;
			snareActive = true;
			cameraSize = 14f;
			if (activeChecked == false)
			{
				ActiveCheck();
			}

			SongSectionTwo();
		}
		else if (audioXFade.songSection == 3)
		{
			snareController.colorWorks = false;
			clapController.colorWorks = true;
			gb1Pul1Controller.colorWorks = true;
			kickController.colorWorks = true;
			gb1Pul1Controller.instrumentColor = new Color(1f, .5f, .5f);
			clapController.instrumentColor = new Color(.4f, .4f, .4f);
			kickController.instrumentColor = new Color(.6f, .6f, .6f);
			kickActive = true;
			clapActive = true;
			cameraSize = 15f;
			if (activeChecked == false)
			{
				ActiveCheck ();
			}
			SongSectionThree ();
		}
		else if (audioXFade.songSection == 4)
		{
			clapController.colorWorks = true;
			gb1Pul1Controller.colorWorks = true;
			gb2Pul1Controller.colorWorks = true;
			gb1Pul1Controller.instrumentColor = new Color(1f, .4f, .4f);
			clapController.instrumentColor = new Color(.4f, .4f, .4f);
			gb2Pul1Controller.instrumentColor = new Color(.5f, .5f, 1f);
			gb2Pul1Active = true;
			cameraSize = 16f;
			if (activeChecked == false)
			{
				ActiveCheck();
			}
			SongSectionFour();
		}
		else if (audioXFade.songSection == 5)
		{
			clapController.colorWorks = true;
			gb1Pul1Controller.colorWorks = true;
			gb2Pul1Controller.colorWorks = true;
			gb1Pul1Controller.instrumentColor = new Color(1f, .4f, .4f);
			clapController.instrumentColor = new Color(.4f, .4f, .4f);
			gb2Pul1Controller.instrumentColor = new Color(.5f, .5f, 1f);
			gb2Pul2AndWavActive = true;
			cameraSize = 17f;
			if (activeChecked == false)
			{
				ActiveCheck();
			}
			SongSectionFive ();
		}
		else if (audioXFade.songSection == 6)
		{
			hatActive = false;
			gb1WavActive = true;
			glitchActive = true;
			gb1Pul2Active = true;
			gb1Pul1Active = true;
			snareActive = false;
			kickActive = false;
			clapActive = false;
			gb2Pul1Active = false;
			gb2Pul2AndWavActive = false;

			gb2Pul1Controller.colorWorks = false;
			clapController.colorWorks = false;
			gb1Pul1Controller.colorWorks = true;
			gb1Pul1Controller.instrumentColor = new Color(1f, .4f, .4f);
			if (activeChecked == false)
			{
				ActiveCheck();
			}
			SongSectionSix();
		}
		else if (audioXFade.songSection == 7)
		{
			gb2Pul1Active = true;
			hatActive = true;
			snareActive = true;
			gb2Pul1Controller.colorWorks = true;
			gb2Pul1Controller.instrumentColor = new Color(.5f,.5f, 1f);
			if (activeChecked == false)
			{
				ActiveCheck();
			}
			SongSectionSeven();
		}
		else if(audioXFade.songSection == 8)
		{
			hatActive = true;
			gb1WavActive = true;
			glitchActive = true;
			gb1Pul2Active = true;
			gb1Pul1Active = true;
			snareActive = true;
			kickActive = true;
			clapActive = true;
			gb2Pul1Active = true;
			gb2Pul2AndWavActive = true;

			gb2Pul1Controller.colorWorks = true;
			gb1Pul1Controller.colorWorks = true;
			clapController.colorWorks = true;
			clapController.instrumentColor = new Color(.4f, .4f, .4f);
			gb1Pul1Controller.instrumentColor = new Color(1f, .4f, .4f);
			gb2Pul1Controller.instrumentColor = new Color(.5f, .5f, 1f);

			cameraSize = 20f;
			if (activeChecked == false)
			{
				ActiveCheck();
			}
			SongSectionEight ();
		}
	}


	void ActiveCheck()
	{
		if (kickActive == true)
		{
			if (kick.gameObject.activeInHierarchy == false)
			{
				kick.gameObject.SetActive(true);
			}
			else if (kickController.alive == false)
			{
				kickController.controllerColor = new Color(0f, 0f, 0f);
				kickController.health = 50;
				kickController.alive = true;
			}
		}

		if (hatActive == true)
		{
			if (hat.gameObject.activeInHierarchy == false)
			{
				hat.gameObject.SetActive(true);
			}
			else if (hatController.alive == false)
			{
				hatController.controllerColor = new Color(0f, 0f, 0f);
				hatController.health = 50;
				hatController.alive = true;
			}
		}

		if (clapActive == true)
		{
			if (clap.gameObject.activeInHierarchy == false)
			{
				clap.gameObject.SetActive(true);
			}
			else if (clapController.alive == false)
			{
				clapController.controllerColor = new Color(0f, 0f, 0f);
				clapController.health = 50;
				clapController.alive = true;
			}
		}

		if (snareActive == true)
		{
			if (snare.gameObject.activeInHierarchy == false)
			{
				snare.gameObject.SetActive(true);
			}
			else if (snareController.alive == false)
			{
				snareController.controllerColor = new Color(0f, 0f, 0f);
				snareController.health = 50;
				snareController.alive = true;
			}
		}

		if (glitchActive == true)
		{
			if (glitch.gameObject.activeInHierarchy == false)
			{
				glitch.gameObject.SetActive(true);
			}
			else if (glitchController.alive == false)
			{
				glitchController.controllerColor = new Color(0f, 0f, 0f);
				glitchController.health = 50;
				glitchController.alive = true;
			}
		}

		if (gb1Pul1Active == true)
		{
			if (gb1pul1.gameObject.activeInHierarchy == false)
			{
				gb1pul1.gameObject.SetActive(true);
			}
			else if (gb1Pul1Controller.alive == false)
			{
				gb1Pul1Controller.controllerColor = new Color(0f, 0f, 0f);
				gb1Pul1Controller.health = 50;
				gb1Pul1Controller.alive = true;
			}
		}

		if (gb1Pul2Active == true)
		{
			if (gb1pul2.gameObject.activeInHierarchy == false)
			{
				gb1pul2.gameObject.SetActive(true);
			}
			else if (gb1Pul2Controller.alive == false)
			{
				gb1Pul2Controller.controllerColor = new Color(0f, 0f, 0f);
				gb1Pul2Controller.health = 50;
				gb1Pul2Controller.alive = true;
			}
		}

		if (gb1WavActive == true)
		{
			if (gb1wav.gameObject.activeInHierarchy == false)
			{
				gb1wav.gameObject.SetActive(true);
			}
			else if (gb1WavController.alive == false)
			{
				gb1WavController.controllerColor = new Color(0f, 0f, 0f);
				gb1WavController.health = 50;
				gb1WavController.alive = true;
			}
		}

		if (gb2Pul1Active == true)
		{
			if (gb2pul1.gameObject.activeInHierarchy == false)
			{
				gb2pul1.gameObject.SetActive(true);
			}
			else if (gb2Pul1Controller.alive == false)
			{
				gb2Pul1Controller.controllerColor = new Color(0f, 0f, 0f);
				gb2Pul1Controller.health = 50;
				gb2Pul1Controller.alive = true;
			}
		}

		if (gb2Pul2AndWavActive == true)
		{
			if (gb2pul2andwav.gameObject.activeInHierarchy == false)
			{
				gb2pul2andwav.gameObject.SetActive(true);
			}
			else if (gb2Pul2AndWavController.alive == false)
			{
				gb2Pul2AndWavController.controllerColor = new Color(0f, 0f, 0f);
				gb2Pul2AndWavController.health = 50;
				gb2Pul2AndWavController.alive = true;
			}
		}

		activeChecked = true;
	}

	void UpdateCameraSize()
	{
		if (theCamera.orthographicSize < cameraSize)
		{
			theCamera.orthographicSize += .01f;
		}
	}
}
