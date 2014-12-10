using UnityEngine;
using System.Collections;

public class AudioXFade : MonoBehaviour {
	
	private AudioSource silence;
	private AudioSource loop;
	private AudioSource loop2;
	private AudioSource shootingArp;
	public AudioSource[] loopArray;
	
	public AudioSource[] kickArray;
	public AudioSource[] snareArray;
	public AudioSource[] hatArray;
	public AudioSource[] clapArray;
	public AudioSource[] glitchArray;
	public AudioSource[] gb1Pul1Array;
	public AudioSource[] gb1Pul2Array;
	public AudioSource[] gb1WavArray;
	public AudioSource[] gb2Pul1Array;
	public AudioSource[] gb2Pul2AndWavArray;
	public AudioSource[] gb1NoiseArray;

	private int loopLoopNumber;

	private int spawnKillAmount1;
	private int spawnKillAmount2;
	private int spawnKillAmount3;
	private int spawnKillAmount4;
	private int spawnKillAmount5;
	private int spawnKillAmount6;
	private int spawnKillAmount7;
	private int spawnKillAmount8;
	private int spawnKillAmount9;
	private int spawnKillAmount10;
	private int spawnKillAmount11;
	private int spawnKillAmount12;
	private int spawnKillAmount13;
	private int numberOfSongSections;
	private int[] spawnKillArray;
	private int loopArrayIterator = 0;
	private AudioSource numberOfLoops;
	public int spawnsKilled = 0;
	public int songSection = 0;
	private double dspOffset = 0;
	private double dspTime = 0;
	//private PauseScript pauseScript;
	
	public bool isStarted = false;
	
	public float offset;
	
	private MetronomeTimer metronome;
	public bool clipTriggered = false;
	public bool songEnded = false;
	
	public bool isLoopPlaying = false;

	public SongScript songScript;

	private PlayerController player;

	
	// Use this for initialization
	void Start () {

		
		//AudioSettings.outputSampleRate = 44100;
		//Debug.Log(AudioSettings.outputSampleRate);
		/*
		if (Application.loadedLevelName == "GlaciersScene")
		{
			silence = GameObject.Find("AudioSource").GetComponent<AudioSource>();
			loop = GameObject.Find ("GlaciersLoop1").GetComponent<AudioSource>();
			loop2 = GameObject.Find ("GlaciersLoop2").GetComponent<AudioSource>();
			loop3 = GameObject.Find ("GlaciersLoop3").GetComponent<AudioSource>();
			loop4 = GameObject.Find ("GlaciersLoop4").GetComponent<AudioSource>();
			loop5 = GameObject.Find ("GlaciersLoop5").GetComponent<AudioSource>();
			loop6 = GameObject.Find ("GlaciersLoop6").GetComponent<AudioSource>();
			loop7 = GameObject.Find ("GlaciersLoop7").GetComponent<AudioSource>();
			loop8 = GameObject.Find ("GlaciersLoop8").GetComponent<AudioSource>();
			loop9 = GameObject.Find ("GlaciersLoop9").GetComponent<AudioSource>();
			loop10 = GameObject.Find ("GlaciersLoop10").GetComponent<AudioSource>();
			loop11 = GameObject.Find ("GlaciersLoop11").GetComponent<AudioSource>();
			loop12 = GameObject.Find ("GlaciersLoop12").GetComponent<AudioSource>();
			cubeKillAmount1 = 80;
			cubeKillAmount2 = 200;
			cubeKillAmount3 = 330;
			cubeKillAmount4 = 500;
			cubeKillAmount5 = 750;
			cubeKillAmount6 = 1000;
			cubeKillAmount7 = 1250;
			cubeKillAmount8 = 1450;
			cubeKillAmount8 = 2150;
			cubeKillAmount9 = 2550;
			cubeKillAmount10 = 3050;
			cubeKillAmount11 = 3250;
			loopArray = new AudioSource[]{loop, loop2, loop3, loop4, loop5, loop6, loop7, loop8, loop9, loop10, loop11, loop12};
			cubeKillArray = new int[]{cubeKillAmount1, cubeKillAmount2, cubeKillAmount3, cubeKillAmount4, cubeKillAmount5, cubeKillAmount6, cubeKillAmount7, cubeKillAmount8, cubeKillAmount9, cubeKillAmount10, cubeKillAmount11};
			numberOfSongSections = 11;
		}*/

		silence = GameObject.Find ("AudioSource").GetComponent<AudioSource>();
		isStarted = false;
		metronome = GameObject.Find ("AudioSource").GetComponent<MetronomeTimer>();
		loop = GameObject.Find ("LoopLoop1").GetComponent<AudioSource>();
		spawnsKilled = GameObject.Find ("Player").GetComponent<PlayerController>().spawnsKilled;
		numberOfSongSections = 10;
		spawnKillAmount1 = 2;
		spawnKillAmount2 = 6;
		spawnKillAmount3 = 12;
		spawnKillAmount4 = 20;
		spawnKillAmount5 = 29;
		spawnKillAmount6 = 39;
		spawnKillAmount7 = 43;
		spawnKillAmount8 = 50;
		spawnKillAmount9 = 55;

		spawnKillArray = new int[]{spawnKillAmount1, spawnKillAmount2, spawnKillAmount3, spawnKillAmount4, spawnKillAmount5, spawnKillAmount6, spawnKillAmount7, spawnKillAmount8, spawnKillAmount9, spawnKillAmount10};

		loopLoopNumber = 10;

		player = GameObject.Find ("Player").GetComponent<PlayerController>();
		shootingArp = GameObject.Find ("ShootingArp").GetComponent<AudioSource>();


		loopArray = new AudioSource[loopLoopNumber];
		kickArray = new AudioSource[loopLoopNumber];
		snareArray = new AudioSource[loopLoopNumber];
		clapArray = new AudioSource[loopLoopNumber];
		hatArray = new AudioSource[loopLoopNumber];
		glitchArray = new AudioSource[loopLoopNumber];
		gb1Pul1Array = new AudioSource[loopLoopNumber];
		gb1Pul2Array = new AudioSource[loopLoopNumber];
		gb1WavArray = new AudioSource[loopLoopNumber];
		gb2Pul1Array = new AudioSource[loopLoopNumber];
		gb2Pul2AndWavArray = new AudioSource[loopLoopNumber];
		gb1NoiseArray = new AudioSource[loopLoopNumber];

		SetUpLoopArrays();

		songScript = GameObject.Find ("SongScript").GetComponent<SongScript>();

		//pauseScript = GameObject.Find ("Paused").GetComponent<PauseScript>();
		//StartCoroutine(waitUntilEnd());
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Application.loadedLevelName != "MenuScene")
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				if (isStarted == false && silence.isPlaying == false)
				{
					loopArray[0].Play();
					kickArray[0].Play();
					hatArray[0].Play();
					clapArray[0].Play();
					snareArray[0].Play();
					glitchArray[0].Play();
					gb1Pul1Array[0].Play();
					gb1Pul2Array[0].Play();
					gb1WavArray[0].Play ();
					gb2Pul1Array[0].Play ();
					gb2Pul2AndWavArray[0].Play();
					gb1NoiseArray[0].Play();
					shootingArp.Play();
					silence.Play();
					silence.loop = true;
					songSection = 0;
					isStarted = true;
					clipTriggered = false;
					songEnded = false;
				}
			}
		}
	}
	
	IEnumerator waitUntilEnd()
	{
		//Debug.Log ("waiting");
		if (clipTriggered == true)
		{
			if (loopArray[songSection].isPlaying == false /*&& pauseScript.isPaused == false*/)
			{
				songSection++;
				clipTriggered = false;
				songScript.activeChecked = false;
			}
		}
		yield return null;
	}

	void SetUpLoopArrays()
	{

		for (int i = 0; i < loopLoopNumber; i++)
		{
			string loopString = "LoopLoop" + (i + 1);
			string kickString = "KickLoop" + (i + 1);
			string clapString = "ClapLoop" + (i + 1);
			string hatString = "HatLoop" + (i + 1);
			string snareString = "SnareLoop" + (i + 1);
			string glitchString = "GlitchLoop" + (i + 1);
			string gb1Pul1String = "GB1Pul1Loop" + (i + 1);
			string gb1Pul2String = "GB1Pul2Loop" + (i + 1);
			string gb1WavString = "GB1WavLoop" + (i + 1);
			string gb2Pul1String = "GB2Pul1Loop" + (i + 1);
			string gb2Pul2AndWavString = "GB2Pul2AndWavLoop" + (i + 1);
			string gb1NoiseString = "GB1NoiseLoop" + (i + 1);

			AudioSource loopObject = GameObject.Find (loopString).GetComponent<AudioSource>();
			AudioSource kickObject = GameObject.Find (kickString).GetComponent<AudioSource>();
			AudioSource clapObject = GameObject.Find (clapString).GetComponent<AudioSource>();
			AudioSource hatObject = GameObject.Find (hatString).GetComponent<AudioSource>();
			AudioSource snareObject = GameObject.Find (snareString).GetComponent<AudioSource>();
			AudioSource glitchObject = GameObject.Find (glitchString).GetComponent<AudioSource>();
			AudioSource gb1Pul1Object = GameObject.Find (gb1Pul1String).GetComponent<AudioSource>();
			AudioSource gb1Pul2Object = GameObject.Find (gb1Pul2String).GetComponent<AudioSource>();
			AudioSource gb1WavObject = GameObject.Find (gb1WavString).GetComponent<AudioSource>();
			AudioSource gb2Pul1Object = GameObject.Find (gb2Pul1String).GetComponent<AudioSource>();
			AudioSource gb2Pul2AndWavObject = GameObject.Find (gb2Pul2AndWavString).GetComponent<AudioSource>();
			AudioSource gb1NoiseObject = GameObject.Find (gb1NoiseString).GetComponent<AudioSource>();

			loopArray[i] = loopObject;
			kickArray[i] = kickObject;
			clapArray[i] = clapObject;
			hatArray[i] = hatObject;
			snareArray[i] = snareObject;
			glitchArray[i] = glitchObject;
			gb1Pul1Array[i] = gb1Pul1Object;
			gb1Pul2Array[i] = gb1Pul2Object;
			gb1WavArray[i] = gb1WavObject;
			gb2Pul1Array[i] = gb2Pul1Object;
			gb2Pul2AndWavArray[i] = gb2Pul2AndWavObject;
			gb1NoiseArray[i] = gb1NoiseObject;
		}
	}
	
	void FixedUpdate()
	{
		if (player.gameObject.activeInHierarchy)
		{
			spawnsKilled = GameObject.Find ("Player").GetComponent<PlayerController>().spawnsKilled;
		}
		StartCoroutine(waitUntilEnd());
		isLoopPlaying = loopArray[songSection].isPlaying;
		if (metronome.measure > 2 && clipTriggered == false)
		{
			gb1NoiseArray[songSection].volume = 0f;
			gb1NoiseArray[songSection + 1].volume = 0f;
		}
		//dspTime = AudioSettings.dspTime;
		/*
		if (loopArray[songSection + 1].time > 0 && clipTriggered == true)
		{
			songSection++;
			clipTriggered = false;
		}*/
		
		/*
		if (loopArray[songSection].isPlaying == false && clipTriggered == true)
		{
			//loopArrayIterator++;
			songSection++;
		}
		if (loopArray[songSection].isPlaying == true && clipTriggered == true)
		{
			//songSection = loopArrayIterator;
			//loopArrayIterator = 0;
			clipTriggered = false;
			Debug.Log ("looparrayisplaying");
		}*/
		
		if (spawnsKilled >= spawnKillArray[songSection] && clipTriggered == false/* && pauseScript.isPaused == false*/)
		{
			Debug.Log (spawnsKilled);
			//Debug.Log (spawnsKilled >= spawnKillArray[songSection + 1]);
			if (songSection == numberOfSongSections)
			{
				Debug.Log ("hello");
			}
			if (songSection == numberOfSongSections)
			{
				loopArray[songSection].loop = false;
				//silence.loop = false;
				if (loopArray[numberOfSongSections].isPlaying == false)
				{
					Debug.Log ("stop");
					isStarted = false;
					clipTriggered = false;
					silence.loop = false;
					spawnsKilled = 0;
				}
			}
			else
			{
				/*
				offset = loopArray[songSection].clip.length - loopArray[songSection].time;
				//offset = (AudioSettings.dspTime + (double)loopArray[songSection].clip.length) - (AudioSettings.dspTime + (double)loopArray[songSection].time) + AudioSettings.dspTime;
				//dspOffset = AudioSettings.dspTime + offset;
				loopArray[songSection + 1].PlayDelayed(offset);
				loopArray[songSection].loop = false;

				kickArray[songSection + 1].PlayDelayed(offset);
				hatArray[songSection + 1].PlayDelayed(offset);
				snareArray[songSection + 1].PlayDelayed(offset);
				clapArray[songSection + 1].PlayDelayed(offset);
				glitchArray[songSection + 1].PlayDelayed(offset);
				gb1Pul1Array[songSection + 1].PlayDelayed(offset);
				gb1Pul2Array[songSection + 1].PlayDelayed(offset);
				gb1WavArray[songSection + 1].PlayDelayed(offset);
				gb2Pul1Array[songSection + 1].PlayDelayed(offset);
				gb2Pul2AndWavArray[songSection + 1].PlayDelayed(offset);
				gb1NoiseArray[songSection + 1].PlayDelayed(offset);

				kickArray[songSection].loop = false;
				hatArray[songSection].loop = false;
				snareArray[songSection].loop = false;
				clapArray[songSection].loop = false;
				glitchArray[songSection].loop = false;
				gb1Pul1Array[songSection].loop = false;
				gb1Pul2Array[songSection].loop = false;
				gb1WavArray[songSection].loop = false;
				gb2Pul1Array[songSection].loop = false;
				gb2Pul2AndWavArray[songSection].loop = false;
				gb1NoiseArray[songSection].loop = false;

				gb1NoiseArray[songSection].volume = 1f;
				gb1NoiseArray[songSection + 1].volume = 1f;

				clipTriggered = true;
				//songScript.activeChecked = false;
				*/

				dspOffset = loopArray[songSection].clip.length - loopArray[songSection].time + AudioSettings.dspTime;
				loopArray[songSection + 1].PlayScheduled(dspOffset);
				loopArray[songSection].loop = false;
				
				kickArray[songSection + 1].PlayScheduled(dspOffset);
				hatArray[songSection + 1].PlayScheduled(dspOffset);
				snareArray[songSection + 1].PlayScheduled(dspOffset);
				clapArray[songSection + 1].PlayScheduled(dspOffset);
				glitchArray[songSection + 1].PlayScheduled(dspOffset);
				gb1Pul1Array[songSection + 1].PlayScheduled(dspOffset);
				gb1Pul2Array[songSection + 1].PlayScheduled(dspOffset);
				gb1WavArray[songSection + 1].PlayScheduled(dspOffset);
				gb2Pul1Array[songSection + 1].PlayScheduled(dspOffset);
				gb2Pul2AndWavArray[songSection + 1].PlayScheduled(dspOffset);
				gb1NoiseArray[songSection + 1].PlayScheduled(dspOffset);
				
				kickArray[songSection].loop = false;
				hatArray[songSection].loop = false;
				snareArray[songSection].loop = false;
				clapArray[songSection].loop = false;
				glitchArray[songSection].loop = false;
				gb1Pul1Array[songSection].loop = false;
				gb1Pul2Array[songSection].loop = false;
				gb1WavArray[songSection].loop = false;
				gb2Pul1Array[songSection].loop = false;
				gb2Pul2AndWavArray[songSection].loop = false;
				gb1NoiseArray[songSection].loop = false;
				
				gb1NoiseArray[songSection].volume = 1f;
				gb1NoiseArray[songSection + 1].volume = 1f;
				
				clipTriggered = true;
				//songScript.activeChecked = false;

			}
		}
	}
	
}
