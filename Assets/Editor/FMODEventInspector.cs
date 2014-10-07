using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FMODAsset))]
public class FMODEventInspector : Editor
{
	FMODAsset currentAsset; //Make an easy shortcut to the Dialogue your editing
	bool isPlaying = false;
	
	void Awake()
	{
		currentAsset=(FMODAsset)target;
		FMODEditorExtension.StopEvent();
		isPlaying = false;
	}
	
	void OnDestroy()
	{
		FMODEditorExtension.StopEvent();		
	}
	
	public override void OnInspectorGUI()
	{
		//GUILayout.Label("Event: " + currentAsset.name);
		GUILayout.Label("Path: " + currentAsset.path);		
		GUILayout.Label("GUID: " + currentAsset.guid);
		
		GUILayout.BeginHorizontal();
		if (!isPlaying && GUILayout.Button("Play", new GUILayoutOption[0]))
		{
			FMODEditorExtension.AuditionEvent(currentAsset.guid);
			isPlaying = true;
		}
		if (isPlaying && GUILayout.Button("Stop", new GUILayoutOption[0]))
		{
			FMODEditorExtension.StopEvent();
			isPlaying = false;
		}
		GUILayout.EndHorizontal();
	}
}
