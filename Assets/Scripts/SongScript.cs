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

	private EnemyController kick;
	private EnemyController snare;
	private EnemyController hat;
	private EnemyController altSnare;
	private EnemyController gb1;
	private EnemyController gb2;
	
	// Use this for initialization
	void Start () {
		kick = GameObject.Find ("Kick").GetComponent<EnemyController>();
		snare = GameObject.Find ("Snare").GetComponent<EnemyController>();
		hat = GameObject.Find ("Hat").GetComponent<EnemyController>();
		altSnare = GameObject.Find("AltSnare").GetComponent<EnemyController>();
		gb1 = GameObject.Find ("GB1").GetComponent<EnemyController>();
		gb2 = GameObject.Find ("GB2").GetComponent<EnemyController>();
		metronome = GameObject.Find ("AudioSource").GetComponent<MetronomeTimer>();
		audioXFade = GameObject.Find ("AudioSource").GetComponent<AudioXFade>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate()
	{
		if (metronome.onSixteenth == true)
		{
			if (metronome.measure % 2 == 1)
			{
				switch(metronome.sixteenthNote)
				{
				case 0:
					kick.LaunchEnemy(1);
					break;
				case 2:
					hat.LaunchEnemy(2);
					break;
				case 3:
					kick.LaunchEnemy(1);
					break;
				case 4:
					break;
				case 6:
					hat.LaunchEnemy(2);
					break;
				case 8:
					snare.LaunchEnemy(1);
					break;
				case 10:
					hat.LaunchEnemy(2);
					break;
				case 12:
					break;
				case 14:
					hat.LaunchEnemy(2);
					break;
				}
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
}
