using UnityEditor;
using System.IO;
using UnityEngine;

public class CreateAssetBundles
{
	[MenuItem("Assets/Build AssetBundles")]
	static void BuildAllAssetBundles()
	{
		string assetBundleDirectory = "Assets/TestAB111";
		if(!Directory.Exists(assetBundleDirectory))
		{
			Directory.CreateDirectory(assetBundleDirectory);
		}
		BuildTarget currentTarget = EditorUserBuildSettings.activeBuildTarget;
		Debug.LogError ("currentTarget is:"+currentTarget);
		AssetBundleManifest manifest = BuildPipeline.BuildAssetBundles(assetBundleDirectory, BuildAssetBundleOptions.None, currentTarget);
		string[] all = manifest.GetAllAssetBundles ();
		Debug.LogError (all.Length);
		Debug.LogError (all[0]);
		Debug.LogError (all[1]);

		string[] all01 = manifest.GetAllDependencies (all[0]);
		string[] all02 = manifest.GetDirectDependencies (all[0]);
		string[] all11 = manifest.GetAllDependencies (all[1]);
	}
}