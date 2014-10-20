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
	private EnemyController gb1Controller;
	private EnemyController gb2Controller;

	private GameObject kick;
	private GameObject snare;
	private GameObject hat;
	private GameObject clap;
	private GameObject gb1;
	private GameObject gb2;

	public bool activeChecked = false;

	private Camera theCamera;
	public Color cameraColor;
	
	// Use this for initialization
	void Start () {

		kick = GameObject.Find ("Kick");
		snare = GameObject.Find ("Snare");
		hat = GameObject.Find ("Hat");
		clap = GameObject.Find("Clap");
		gb1 = GameObject.Find ("GB1");
		gb2 = GameObject.Find ("GB2");

		kickController = GameObject.Find ("Kick").GetComponent<EnemyController>();
		snareController = GameObject.Find ("Snare").GetComponent<EnemyController>();
		hatController = GameObject.Find ("Hat").GetComponent<EnemyController>();
		clapController = GameObject.Find("Clap").GetComponent<EnemyController>();
		gb1Controller = GameObject.Find ("GB1").GetComponent<EnemyController>();
		gb2Controller = GameObject.Find ("GB2").GetComponent<EnemyController>();

		metronome = GameObject.Find ("AudioSource").GetComponent<MetronomeTimer>();
		audioXFade = GameObject.Find ("AudioSource").GetComponent<AudioXFade>();

		theCamera = GameObject.Find ("Main Camera").GetComponent<Camera>();
		cameraColor = theCamera.backgroundColor;

		kickController.instrumentColor = new Color (1f, 1f, .5f);
		snareController.instrumentColor = new Color(1f, .85f, .85f);
		clapController.instrumentColor = new Color(.5f, .5f, 1f);
		hatController.instrumentColor = new Color(.5f, 1f, .5f);

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
	}

	void FixedUpdate()
	{
		if (audioXFade.songSection == 0)
		{
			if (metronome.measure % 2 == 1)
			{
				if (metronome.onSixteenth == true)
				{
					switch(metronome.sixteenthNote)
					{
					case 0:
						kickController.LaunchEnemy(1, 3);
						break;
					case 1:
						hatController.LaunchEnemy(2, 2);
						break;
					case 2:
						hatController.LaunchEnemy(2, 2);
						break;
					case 3:
						hatController.LaunchEnemy(2, 2);
						break;
					case 5:
						kickController.LaunchEnemy(1, 3);
						break;
					case 8:
						snareController.LaunchEnemy(1, 5);
						break;
					case 10:
						hatController.LaunchEnemy(2, 2);
						break;
					case 11:
						hatController.LaunchEnemy(2, 2);
						break;
					}
				}
			}
		}
		else if (audioXFade.songSection == 1)
		{
			if (activeChecked == false)
			{
				ActiveCheck ();
			}
		}
		/*
		if (audioXFade.songSection == 0)
		{
			ColorSwitch (new Color(0f, 0f, 0f, 1f), new Color((216f/255f), (216f/255f), (216f/255f), 1));
			cubeSubdivision = new bool[]{true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true};
			cubeSubdivisionLeft = new bool[]{true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true};
			if (metronome.measure < 9)
			{
				switch(metronome.sixteenthNote)
				{
				case 0:
					positions = new Vector3[]{new Vector3(rightSideBounds.center.x, 560, 0)};
					positionsLeft = new Vector3[]{new Vector3(leftSideBounds.center.x, leftSideBounds.center.y, 0)};
					break;
				case 2:
					positions = new Vector3[]{new Vector3(rightSideBounds.center.x, 360, 0)};
					break;
				case 4:
					positions = new Vector3[]{new Vector3(rightSideBounds.center.x, 160, 0)};
					positionsLeft = new Vector3[]{new Vector3(leftSideBounds.center.x, leftSideBounds.center.y, 0)};
					break;
				case 6:
					positions = new Vector3[]{new Vector3(rightSideBounds.center.x, 460, 0)};
					break;
				case 8:
					positions = new Vector3[]{new Vector3(rightSideBounds.center.x, 560, 0)};
					positionsLeft = new Vector3[]{new Vector3(leftSideBounds.center.x, leftSideBounds.center.y, 0)};
					break;
				case 10:
					positions = new Vector3[]{new Vector3(rightSideBounds.center.x, 360, 0)};
					break;
				case 12:
					positions = new Vector3[]{new Vector3(rightSideBounds.center.x, 160, 0)};
					positionsLeft = new Vector3[]{new Vector3(leftSideBounds.center.x, leftSideBounds.center.y, 0)};
					break;
				case 14:
					positions = new Vector3[]{new Vector3(rightSideBounds.center.x, 460, 0)};
					break;
				}
				
				subdivisions = new int[]{1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0};
				subdivisionsLeft = new int[]{1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0};
				killSubdivisions = new bool[]{false, true, false, true, false, true, false, true, false, true, false, true, false, true, false, true};
				killSubdivisionsLeft = new bool[]{false, false, false, true, false, false, false, true, false, false, false, true, false, false, false, true};
				speedLeft = new Vector3(0, 0, 0);
				speedRight = new Vector3(0, 0, 0);
				
				cubeSpawner.setCubeLaunchSubdivisions(subdivisions, null, subdivisionsLeft, null, null, null, null, null);
				cubeSpawner.setCubeDamageSubdivisions(cubeSubdivision, cubeSubdivisionLeft, null, null);
				cubeSpawner.setCubePositions(positions, null, positionsLeft, null, null, null, null, null);
				cubeSpawner.setCubeSpeed(speedRight, speedLeft);
				cubeSpawner.setCubeTimedKill(killSubdivisions, killSubdivisionsLeft, null, null);
			}
		}*/
	}

	void ActiveCheck()
	{
		if (kick.gameObject.activeInHierarchy == false)
		{
			kick.SetActive(true);
			kickController.health = 50;
		}

		if (hat.gameObject.activeInHierarchy == false)
		{
			hat.SetActive(true);
			hatController.health = 50;
		}

		if (clap.gameObject.activeInHierarchy == false)
		{
			clap.SetActive(true);
			clapController.health = 50;
		}

		if (snare.gameObject.activeInHierarchy == false)
		{
			snare.SetActive(true);
			snareController.health = 50;
		}

		activeChecked = true;
	}
}
