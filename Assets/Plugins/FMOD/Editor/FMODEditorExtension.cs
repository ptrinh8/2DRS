#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

[InitializeOnLoad]
public class FMODEditorExtension : MonoBehaviour 
{
	public static FMOD.Studio.System sFMODSystem;
	static Dictionary<string, FMOD.Studio.EventDescription> events = new Dictionary<string, FMOD.Studio.EventDescription>();	
	static FMOD.Studio.EventInstance currentInstance = null;
	static List<FMOD.Studio.Bank> loadedBanks = new List<FMOD.Studio.Bank>();
	
	const string AssetFolder = "FMODAssets";
	
	static FMODEditorExtension()
	{
        EditorApplication.update += Update;
		EditorApplication.playmodeStateChanged += HandleOnPlayModeChanged;
	}
 
	static void HandleOnPlayModeChanged()
	{
		if (EditorApplication.isPlayingOrWillChangePlaymode &&
			!EditorApplication.isPaused)
		{
        	UnloadAllBanks();
		}
		
		if (!EditorApplication.isPlaying && !EditorApplication.isPlayingOrWillChangePlaymode &&
			!EditorApplication.isPaused)
		{
	        //LoadAllBanks();
		}
	}
	
	static void Update()
    {
        if (sFMODSystem != null && sFMODSystem.isValid())
		{
			ERRCHECK(sFMODSystem.update());
		}
    }
			
	public static void AuditionEvent(string guid)
	{
		StopEvent();
		
		var desc = GetEventDescription(guid);
					
		ERRCHECK(desc.createInstance(out currentInstance));
		ERRCHECK(currentInstance.start());
	}
	
	public static void StopEvent()
	{
		if (currentInstance != null && currentInstance.isValid())
		{
			ERRCHECK(currentInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE));
			currentInstance = null;
		}
	}
	
	public static void SetEventParameterValue(int index, float val)
	{
		if (currentInstance != null && currentInstance.isValid())
		{
			FMOD.Studio.ParameterInstance param;
			currentInstance.getParameterByIndex(index, out param);
			param.setValue(val);
		}		
	}
	
	public static FMOD.Studio.EventDescription GetEventDescription(string guid)
	{
		FMOD.Studio.EventDescription desc = null;
		if (!events.TryGetValue(guid, out desc))
		{
			if (sFMODSystem == null)
			{
				LoadAllBanks();
			}
			FMOD.GUID id = new FMOD.GUID();
			ERRCHECK(FMOD.Studio.Util.ParseID(guid, out id));
			
			FMOD.RESULT res = FMODEditorExtension.sFMODSystem.getEvent(id, FMOD.Studio.LOADING_MODE.BEGIN_NOW, out desc);
			if (res == FMOD.RESULT.OK && desc != null && desc.isValid())
			{
				events[guid] = desc;
			}
		}
		return desc;
	}	
	
	[MenuItem ("FMOD/Refresh Event List")]
	static void RefreshEventList() 
	{
		//Debug.Log(System.IO.GetCurrentDirectory());
		
		string filePath = "";
		if (!LocateProject(ref filePath))
		{
			return;
		}
		
		if (!LoadAllBanks())
		{
			return;
		}
		
		List<FMODAsset> existingAssets = new List<FMODAsset>();
		GatherExistingAssets(existingAssets);
		
		List<FMODAsset> newAssets = new List<FMODAsset>();
		GatherNewAssets(filePath, newAssets);
		
		var assetsToDelete = existingAssets.Except(newAssets, new FMODAssetEqualityComparer());
		var assetsToAdd = newAssets.Except(existingAssets, new FMODAssetEqualityComparer());
		
		if (!assetsToDelete.Any() && !assetsToAdd.Any())
		{
			EditorUtility.DisplayDialog("FMOD Studio Importer", "Banks updated, events list unchanged", "OK");
		}
		else 
		{
			string assetsToDeleteFormatted = "";
			foreach (var asset in assetsToDelete)
			{
				assetsToDeleteFormatted += asset.path + "\n";
			}
			
			string assetsToAddFormatted = "";
			foreach (var asset in assetsToAdd)
			{
				assetsToAddFormatted += asset.path + "\n";
			}
			
			string deletionMessage = 
					(assetsToDelete.Count() == 0 ? "No assets removed" : "Removed assets: " + assetsToDelete.Count()) + "\n" +
					(assetsToAdd.Count()    == 0 ? "No assets added"   : "Added assets: "   + assetsToAdd.Count())    + "\n" + 
					((assetsToDelete.Count() != 0 || assetsToAdd.Count() != 0) ? "\nSee console for details" : "");
				
			Debug.Log("FMOD Import:\n\n" +
				(assetsToDelete.Count() == 0 ? "No assets removed" : "Removed Assets:\n" + assetsToDeleteFormatted) + "\n" +
				(assetsToAdd.Count()    == 0 ? "No assets added"   : "Added Assets:\n" + assetsToAddFormatted));
			
			if (!EditorUtility.DisplayDialog("FMOD Studio Importer", deletionMessage, "Continue", "Cancel"))
			{
				return; // user clicked cancel
			}
		}
		
		ImportAssets(assetsToAdd);
		DeleteMissingAssets(assetsToDelete);
		
		//Debug.Log(System.IO.GetCurrentDirectory());
	}
	
	
	[MenuItem ("FMOD/About integration")]
	static void AboutIntegration() 
	{
        if (sFMODSystem == null || !sFMODSystem.isValid())
		{
			CreateSystem();
		}
		
		FMOD.System sys = null;
		sFMODSystem.getLowLevelSystem(out sys);
		uint version = 0;
		ERRCHECK (sys.getVersion(ref version));
		
		uint major = (version & 0x00FF0000) >> 16;
		uint minor = (version & 0x0000FF00) >>  8;
		uint patch = (version & 0x000000FF);
		
		EditorUtility.DisplayDialog("FMOD Studio Unity Integration", "Version: " + 
			major.ToString("X1") + "." + 
			minor.ToString("X2") + "." +
			patch.ToString("X2"), "OK");		
	}
	
	static bool LocateProject(ref string filePath)
	{
		const string guidPathKey = "FMODStudioGUIDPath";
		var defaultPath = EditorPrefs.GetString(guidPathKey, Application.dataPath);
		
		{
			var workDir = System.Environment.CurrentDirectory;
			filePath = EditorUtility.OpenFilePanel("Locate GUIDs.txt", defaultPath, "txt");		
			System.Environment.CurrentDirectory = workDir; // HACK: fixes weird Unity bug that causes random crashes after using OpenFilePanel 
		}
		
		EditorPrefs.SetString(guidPathKey, filePath);
		 
		if (System.String.IsNullOrEmpty(filePath))
		{
			Debug.Log("No GUIDs.txt selected");
			return false;
		}
		
		UnloadAllBanks();
		
		var bankPath = filePath.Replace("GUIDs.txt", "Desktop");
		var info = new System.IO.DirectoryInfo(bankPath);
		
		if (info.GetFiles().Count() == 0)
		{
			EditorUtility.DisplayDialog("FMOD Studio Importer", "No bank files found in directory: " + bankPath + 
				"You must build the FMOD Studio project before importing", "OK");
			return false;
		}
		
		string copyBanksString = "";
		foreach (var fileInfo in info.GetFiles())
		{
			string bankMessage = "(added)";
			
			var oldBankPath = Application.dataPath + "/StreamingAssets/" + fileInfo.Name;
			if (System.IO.File.Exists(oldBankPath))
			{
				var oldFileInfo = new System.IO.FileInfo(oldBankPath);
				if (oldFileInfo.LastWriteTime == fileInfo.LastWriteTime)
				{
					bankMessage = "(same)";
				}
				else if(oldFileInfo.LastWriteTime < fileInfo.LastWriteTime)
				{
					//Debug.Log("New because: " + oldBankInfo.LastWriteTime + " < " + newBankInfo.LastWriteTime);
					bankMessage = "(newer)";					
				}
				else
				{
					bankMessage = "(older)";					
				}
			}
			else
			{
				//Debug.Log("File not found: " + oldBankPath);
			}
			
			copyBanksString += fileInfo.Name + " " + bankMessage + "\n";
		}
				
		if (!EditorUtility.DisplayDialog("FMOD Studio Importer", "The import will modify the following files:\n" + copyBanksString, "Continue", "Cancel"))
		{
			return false;
		}
		
		string bankNames = "";
		foreach (var fileInfo in info.GetFiles())
		{
			System.IO.Directory.CreateDirectory(Application.dataPath + "/StreamingAssets");
			var oldBankPath = Application.dataPath + "/StreamingAssets/" + fileInfo.Name;
			fileInfo.CopyTo(oldBankPath, true);
			
			bankNames += fileInfo.Name + "\n";
		}
		
		System.IO.File.WriteAllText(Application.dataPath + "/StreamingAssets/FMOD_bank_list.txt", bankNames);
		
		return true;
	}
	
	static void GatherExistingAssets(List<FMODAsset> existingAssets)
	{
		var assetRoot = Application.dataPath + "/" + AssetFolder;
		if (System.IO.Directory.Exists(assetRoot))
		{
			GatherAssetsFromDirectory(assetRoot, existingAssets);
		}
	}

	static void GatherAssetsFromDirectory(string directory, List<FMODAsset> existingAssets)
	{
		//Debug.Log("GatherAssetsFromDirectory: " + directory);
		
		var info = new System.IO.DirectoryInfo(directory);
		foreach (var file in info.GetFiles())
		{
			var relativePath = new System.Uri(Application.dataPath).MakeRelativeUri(new System.Uri(file.FullName)).ToString();
			//Debug.Log("Relative path: " + relativePath);
			var asset = (FMODAsset)AssetDatabase.LoadAssetAtPath(relativePath, typeof(FMODAsset));
			if (asset != null)
			{
				//Debug.Log(" *asset: " + asset.path);
				existingAssets.Add(asset);
			}			
		}
		
		foreach (var dir in info.GetDirectories())
		{
			GatherAssetsFromDirectory(dir.FullName, existingAssets);
		}
	}
		
	static void GatherNewAssets(string filePath, List<FMODAsset> newAssets)
	{		
		if (System.String.IsNullOrEmpty(filePath))
		{
			Debug.LogError("No GUIDs.txt file selected");
			return;
		}
		
		var regex = new Regex(@"({[a-fA-F0-9]{8}-[a-fA-F0-9]{4}-[a-fA-F0-9]{4}-[a-fA-F0-9]{4}-[a-fA-F0-9]{12}}) ([\w\s\(\)/]*/([\w\s\(\)]+))");
		
		//Debug.Log(filePath);
		
		var lines = System.IO.File.ReadAllLines(filePath);
		foreach(var guidPath in lines)
		{
			var matches = regex.Match(guidPath);
			var guid = matches.Groups[1].Value;
			
			var desc = GetEventDescription(guid);
			if (desc != null && desc.isValid())
			{				
			    var asset = ScriptableObject.CreateInstance<FMODAsset>();
			    asset.name = matches.Groups[3].Value;
				asset.path = matches.Groups[2].Value;
				asset.guid = guid;
				
				//Debug.Log(" ?asset: " + asset.path);
				newAssets.Add(asset);
			}
		}
	}
	
	static void ImportAssets(IEnumerable<FMODAsset> assetsToAdd)
	{
		foreach (var asset in assetsToAdd)
		{
			var path = "Assets/" + AssetFolder + asset.path + ".asset";
			//Debug.Log(" +asset: " + path);
			System.IO.Directory.CreateDirectory(System.IO.Directory.GetParent(path).FullName);
			//Debug.Log("Create directory: " + System.IO.Directory.GetParent(path).FullName);
       		AssetDatabase.CreateAsset(asset, path);
		}
	}
	
	static void DeleteMissingAssets(IEnumerable<FMODAsset> assetsToDelete)
	{
		foreach (var asset in assetsToDelete)
		{
			var path = AssetDatabase.GetAssetPath(asset);
			//Debug.Log(" -asset: " + path);
			AssetDatabase.DeleteAsset(path);
			
			var dirPath = new System.IO.FileInfo(path).DirectoryName;
			var dir = new System.IO.DirectoryInfo(dirPath);
			DeleteDirectoryIfEmpty(dir);
		}
	}
	
	static void DeleteDirectoryIfEmpty(System.IO.DirectoryInfo dir)
	{
		//Debug.Log("Attempt delete directory: " + dir.FullName);
		if (dir.GetFiles().Length == 0 && dir.GetDirectories().Length == 0 && dir.Name != AssetFolder)
		{
			dir.Delete();
			DeleteDirectoryIfEmpty(dir.Parent);
		}
	}
	
	static void ForceLoadLowLevelBinary()
	{
		// Hack: force the low level binary to be loaded before accessing Studio API
		int temp1 = 0, temp2 = 0;
		FMOD.Memory.GetStats(ref temp1, ref temp2);
	}
	
	static void CreateSystem()
	{
		ForceLoadLowLevelBinary();
		
    	ERRCHECK(FMOD.Studio.Factory.System_Create(out sFMODSystem));
		ERRCHECK(sFMODSystem.init(256, FMOD.Studio.INITFLAGS.NORMAL, FMOD.INITFLAGS.NORMAL, System.IntPtr.Zero));
	}
	
	static void UnloadAllBanks()
	{
		if (sFMODSystem != null)
		{
			foreach (var bank in loadedBanks)
			{
				ERRCHECK(bank.unload());
			}
			
			loadedBanks.Clear();
			events.Clear();
			
			sFMODSystem.release();
			sFMODSystem = null;
		}
		else if (loadedBanks.Count != 0)
		{
			Debug.LogError("banks not unloaded!");
		}
	}
	
	static bool LoadAllBanks()
	{
		UnloadAllBanks();
		
		CreateSystem(); //TODO: error check
	
	    string bankPath = Application.dataPath + "/StreamingAssets";
		//Debug.Log("Loading banks in path: " + bankPath);
		
		var info = new System.IO.DirectoryInfo(bankPath);		
		//Debug.Log("Directory " + (info.Exists ? "exists" : "doesn't exist!!"));
		
		if (info.Exists)
		{
			var fileInfo = info.GetFiles();			
			//Debug.Log("number of files: " + fileInfo.Length); //PAS
			
			foreach (var file in fileInfo)
			{		
				//Debug.Log("file: " + file.Name); //PAS				
				var s = info.FullName + "/" + file.Name;				
				var ex = file.Extension;
				
				if (ex.Equals(".bank", System.StringComparison.CurrentCultureIgnoreCase) ||
					ex.Equals(".strings", System.StringComparison.CurrentCultureIgnoreCase))
				{
					FMOD.Studio.Bank bank = null;
					FMOD.RESULT result = sFMODSystem.load(s, out bank);
					if (result != FMOD.RESULT.OK)
					{
						Debug.LogError("An error occured while loading bank " + s + ": " + result.ToString() + "\n  " + FMOD.Error.String(result));
						return false;
					}
					loadedBanks.Add(bank);
				}
			}
		}
		
		return true;
	}
	
	public static void ERRCHECK(FMOD.RESULT result)
	{
		if (result != FMOD.RESULT.OK)
		{
			Debug.LogError("FMOD Error (" + result.ToString() + "): " + FMOD.Error.String(result));
		}
	}
}

public class FMODAssetEqualityComparer : IEqualityComparer<FMODAsset>
{
    public bool Equals(FMODAsset lhs, FMODAsset rhs) 
	{
		return lhs.path.Equals(rhs.path, System.StringComparison.OrdinalIgnoreCase);
	}

    public int GetHashCode(FMODAsset asset) 
	{
        return  asset.path.GetHashCode();
    }
}

#endif
