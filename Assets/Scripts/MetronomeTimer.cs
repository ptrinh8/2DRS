/* Stuff to do:
 * implement array of sixteenth notes that can be passed to other classes
 * maybe the array doesn't need to be in this class and the metronome can just pass an int?
 * 
 * 
 * 
 * */

using UnityEngine;
using System.Collections;

public class MetronomeTimer : MonoBehaviour {
	
	public int beatPosition;
	public bool onSixteenth;
	public bool onEighth;
	public int sixteenthNote = 1;
	public int measure = 1;
	public int[] subdivisions;
	public bool notFullPhrase = false;
	public int notFullPhraseNumber = 0;
	public float bpm = 0;
	public float measureSixteenth = 0;

	public AudioSource currentLoop;
	public int currentLoopPosition;
	private float measureLengthInSamples;
	public int[] loopSubdivisions;
	public int compareLoopMeasure = 1;
	
	// Use this for initialization
	void Start () {
		//subdivisions = new int[]{5335, 10669, 16004, 21339, 26673, 32008, 37343, 42677, 48012, 53346, 58681, 64016, 69350, 74685, 80020, 85335};

		currentLoop = this.GetComponent<AudioSource>();
		bpm = 140f;
		/*
		if (Application.loadedLevelName == "GlaciersScene")
		{
			bpm = 128;
			//subdivisions = new int[]{0, 5169, 10338, 15507, 20677, 25846, 31015, 36184, 41353, 46522, 51691, 56861, 62030, 67199, 72368, 77537};
		}
		else if (Application.loadedLevelName == "EhyoScene")
		{
			bpm = 126;
			//subdivisions = new int[]{0, 5250, 10500, 15750, 21000, 26250, 31500, 36750, 42000, 47250, 52500, 57750, 63000, 68250, 73500, 78750};	
		}
		else if (Application.loadedLevelName == "PhoenixScene")
		{
			bpm = 130;
			//subdivisions = new int[]{0, 5088, 10177, 15265, 20354, 25442, 30531, 35619, 40708, 45796, 50884, 55973, 61061, 66150, 71238, 76327};
		}
		else if (Application.loadedLevelName == "IcarusScene")
		{
			bpm = 129;
			//subdivisions = new int[]{0, 5128, 10256, 15384, 20512, 25640, 30768, 35896, 41024, 46151, 51279, 56407, 61535, 66663, 71791, 76919};
			//subdivisions = new int[]{0, 5148, 10296, 15444, 20591, 25739, 30887, 36035, 41183, 46331, 51479, 56626, 61774, 66922, 72070, 77218}; 
		}
		else if (Application.loadedLevelName == "LooksGoodScene")
		{
			bpm = 126;
			//subdivisions = new int[]{0, 5250, 10500, 15750, 21000, 26250, 31500, 36750, 42000, 47250, 52500, 57750, 63000, 68250, 73500, 78750};	
		}
		else if (Application.loadedLevelName == "FutureMusicScene")
		{
			bpm = 128;
			//subdivisions = new int[]{0, 5209, 10417, 15626, 20835, 26043, 31252, 36461, 41669, 46878, 52087, 57295, 62504, 67713, 72921, 78130};
		}
		else if (Application.loadedLevelName == "SkullCatScene")
		{
			bpm = 120;
			//subdivisions = new int[]{0, 5513, 11025, 16538, 22050, 27563, 33075, 38588, 44100, 49613, 55125, 60638, 66150, 71663, 77175, 82688};	
		}
		else if (Application.loadedLevelName == "CopiousScene")
		{
			bpm = 122;	
		}
		else if (Application.loadedLevelName == "FateScene")
		{
			bpm = 130;	
		}
		else if (Application.loadedLevelName == "WetikoScene")
		{
			bpm = 128;	
		}
		else if (Application.loadedLevelName == "SplashRaveScene")
		{
			bpm = 130;	
		}
		else if (Application.loadedLevelName == "TutorialScene")
		{
			bpm = 124;	
		}*/
		measureLengthInSamples = (240f / bpm) * 48000f;
		measureSixteenth = measureLengthInSamples / 16f;
		subdivisions = new int[]{(int)measureSixteenth * 0, (int)measureSixteenth * 1, (int)measureSixteenth * 2, (int)measureSixteenth * 3, (int)measureSixteenth * 4, (int)measureSixteenth * 5, (int)measureSixteenth * 6, 
								 (int)measureSixteenth * 7, (int)measureSixteenth * 8, (int)measureSixteenth * 9, (int)measureSixteenth * 10, (int)measureSixteenth * 11, (int)measureSixteenth * 12, (int)measureSixteenth * 13, 
								 (int)measureSixteenth * 14, (int)measureSixteenth * 15};
		sixteenthNote = 1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void FixedUpdate()
	{


		beatPosition = audio.timeSamples;
		//CompareLoopPosition();
		/*
		if (beatSpeed >= clipLength)
		{
			beatSpeed = ((60/bpm) * 44100) / 8;	
		}*/
		if((beatPosition >= subdivisions[sixteenthNote]) && beatPosition < (subdivisions[sixteenthNote] + subdivisions[1]))
		{
			onSixteenth = true;
			sixteenthNote++;
			
			if(sixteenthNote % 2 == 0)
			{
				onEighth = true;
			}
			else
			{
				onEighth = false;	
			}
			
			if (notFullPhrase == true)
			{
				if (sixteenthNote > 15)
				{
					measure++;
					if (measure == notFullPhraseNumber + 1)
					{
						measure = 1;	
					}
					sixteenthNote = 0;
				}
			}
			else
			{
				if (sixteenthNote > 15)
				{
					measure++;
					if (measure == 17)
					{
						measure = 1;
					}
					sixteenthNote = 0;
				}
			}
		}
		else
		{
			onSixteenth = false;	
		}
		//pass in current song section
		//multiply beatposition by however long the audio for the song section is
		//grab position of current song section
		//compare measure to current song section position
		//if different, beatposition's measure = song section measure


	}

	void CompareLoopPosition()
	{
		//currentLoop = audioXFade.loopArray[audioXFade.songSection];
		currentLoopPosition = currentLoop.timeSamples;
		if (notFullPhrase == true)
		{
			loopSubdivisions = new int[notFullPhraseNumber];
			for (int i = 0; i < notFullPhraseNumber; i++)
			{
				loopSubdivisions[i] = (int)measureLengthInSamples * i;
			}
		}
		else
		{
			loopSubdivisions = new int[]{(int)measureLengthInSamples * 0, (int)measureLengthInSamples * 1, (int)measureLengthInSamples * 2, (int)measureLengthInSamples * 3, (int)measureLengthInSamples * 4, (int)measureLengthInSamples * 5, (int)measureLengthInSamples * 6, (int)measureLengthInSamples * 7, (int)measureLengthInSamples * 8, (int)measureLengthInSamples * 9, (int)measureLengthInSamples * 10, (int)measureLengthInSamples * 11, (int)measureLengthInSamples * 12, (int)measureLengthInSamples * 13, (int)measureLengthInSamples * 14, (int)measureLengthInSamples * 15};
		}

		if (notFullPhrase == true)
		{
			for (int i = 0; i <= notFullPhraseNumber - 1; i++)
			{
				if (currentLoopPosition >= loopSubdivisions[notFullPhraseNumber - 1])
				{
					compareLoopMeasure = notFullPhraseNumber - 1;
				}
				else if (currentLoopPosition >= loopSubdivisions[i] && currentLoopPosition < loopSubdivisions[i + 1])
				{
					compareLoopMeasure = i;
				}
			}
		}
		else
		{
			for (int i = 0; i <= 15; i++)
			{
				if (currentLoopPosition >= loopSubdivisions[15])
				{
					compareLoopMeasure = 15;
				}
				else if (currentLoopPosition >= loopSubdivisions[i] && currentLoopPosition < loopSubdivisions[i + 1])
				{
					compareLoopMeasure = i;
				}
			}
		}

		if (measure != compareLoopMeasure + 1)
		{
			measure = compareLoopMeasure + 1;
		}
	}
}
