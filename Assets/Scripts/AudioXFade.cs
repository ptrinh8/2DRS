using UnityEngine;
using System.Collections;

public class AudioXFade : MonoBehaviour {
	
	private AudioSource silence;
	private AudioSource loop;
	private AudioSource loop2;
	public AudioSource[] loopArray;

	private AudioSource kickLoop1;
	private AudioSource kickLoop2;
	public AudioSource[] kickArray;

	private AudioSource snareLoop1;
	private AudioSource snareLoop2;
	public AudioSource[] snareArray;

	private AudioSource hatLoop1;
	private AudioSource hatLoop2;
	public AudioSource[] hatArray;

	private AudioSource clapLoop1;
	private AudioSource clapLoop2;
	public AudioSource[] clapArray;

	private int spawnKillAmount1;
	private int spawnKillAmount2;
	private int numberOfSongSections = 2;
	private int[] spawnKillArray;
	public int loopArrayIterator = 0;
	private AudioSource numberOfLoops;
	public int spawnsKilled = 0;
	public int songSection = 0;
	public double dspOffset = 0;
	public double dspTime = 0;
	//private PauseScript pauseScript;
	
	public bool isStarted = false;
	
	public float offset;
	
	private MetronomeTimer metronome;
	public bool clipTriggered = false;
	public bool songEnded = false;
	
	public bool isLoopPlaying = false;

	public SongScript songScript;

	
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
		loop = GameObject.Find ("SeeYaLoop1").GetComponent<AudioSource>();
		loop2 = GameObject.Find ("SeeYaLoop2").GetComponent<AudioSource>();
		loopArray = new AudioSource[]{loop, loop2};
		spawnsKilled = GameObject.Find ("Player").GetComponent<PlayerController>().spawnsKilled;
		numberOfSongSections = 2;
		spawnKillAmount1 = 1;
		spawnKillAmount2 = 5;
		spawnKillArray = new int[]{spawnKillAmount1, spawnKillAmount2};

		kickLoop1 = GameObject.Find ("KickLoop1").GetComponent<AudioSource>();
		kickLoop2 = GameObject.Find ("KickLoop2").GetComponent<AudioSource>();
		kickArray = new AudioSource[]{kickLoop1, kickLoop2};

		hatLoop1 = GameObject.Find ("HatLoop1").GetComponent<AudioSource>();
		hatLoop2 = GameObject.Find ("HatLoop2").GetComponent<AudioSource>();
		hatArray = new AudioSource[]{hatLoop1, hatLoop2};

		clapLoop1 = GameObject.Find ("ClapLoop1").GetComponent<AudioSource>();
		clapLoop2 = GameObject.Find ("ClapLoop2").GetComponent<AudioSource>();
		clapArray = new AudioSource[]{clapLoop1, clapLoop2};

		snareLoop1 = GameObject.Find ("SnareLoop1").GetComponent<AudioSource>();
		snareLoop2 = GameObject.Find ("SnareLoop2").GetComponent<AudioSource>();
		snareArray = new AudioSource[]{snareLoop1, snareLoop2};

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
			}
		}
		yield return null;
	}
	
	void FixedUpdate()
	{
		spawnsKilled = GameObject.Find ("Player").GetComponent<PlayerController>().spawnsKilled;
		StartCoroutine(waitUntilEnd());
		isLoopPlaying = loopArray[songSection].isPlaying;
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
				offset = loopArray[songSection].clip.length - loopArray[songSection].time;
				//offset = (AudioSettings.dspTime + (double)loopArray[songSection].clip.length) - (AudioSettings.dspTime + (double)loopArray[songSection].time) + AudioSettings.dspTime;
				//dspOffset = AudioSettings.dspTime + offset;
				loopArray[songSection + 1].PlayDelayed(offset);
				loopArray[songSection].loop = false;

				kickArray[songSection + 1].PlayDelayed(offset);
				hatArray[songSection + 1].PlayDelayed(offset);
				snareArray[songSection + 1].PlayDelayed(offset);
				clapArray[songSection + 1].PlayDelayed(offset);

				kickArray[songSection].loop = false;
				hatArray[songSection].loop = false;
				snareArray[songSection].loop = false;
				clapArray[songSection].loop = false;
				clipTriggered = true;
				songScript.activeChecked = false;
				//Debug.Log ("ClipPlaying");
				//Debug.Log (clipTriggered);
			}
		}


		
		/*
		if ((dspTime + 1.0 > dspOffset) && clipTriggered == true)
		{
			loopArray[songSection + 1].PlayScheduled(offset);
			Debug.Log ("Really playing this time!");
		}*/
	}
}
