using UnityEditor;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class CreateAssetBundle : MonoBehaviour
{
    static private string prefabPath;

    static public string filePath;

    [MenuItem("Assets/Create AssetBundle")]
    static public void BuildAssetBundle()
    {
        
        
        string assetBundleDirectory = "Assets/StreamingAssets";

        if (!Directory.Exists(assetBundleDirectory))
        {
            Directory.CreateDirectory(assetBundleDirectory);
            
        }

        BuildPipeline.BuildAssetBundles(assetBundleDirectory, BuildAssetBundleOptions.None, EditorUserBuildSettings.activeBuildTarget);

        AssetDatabase.Refresh();



    }
}
