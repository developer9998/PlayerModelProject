using UnityEditor;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class CreateMisc : MonoBehaviour
{
    static private string prefabPath;

    static public string filePath;

    [MenuItem("Assets/Create Misc")]
    static public void BuildAssetBundle()
    {
        Debug.Log("Start Export");
        GameObject obj = Selection.activeGameObject;

        misc_descriptor misc = obj.GetComponent<misc_descriptor>();
        

        

        

        prefabPath = "Assets/MISC/" + "misc" + ".prefab";
        filePath = "Assets/MISC";

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();



        var prefabAsset = PrefabUtility.SaveAsPrefabAsset(obj.gameObject, prefabPath);

        GameObject contentsRoot = PrefabUtility.LoadPrefabContents(prefabPath);


        contentsRoot.name = "misc";

        contentsRoot.GetComponent<misc_descriptor>().Selector.name = "misc.selector";

        contentsRoot.GetComponent<misc_descriptor>().LeftPage.name = "misc.leftpage";

        contentsRoot.GetComponent<misc_descriptor>().RightPage.name = "misc.rightpage";

        Object.DestroyImmediate(contentsRoot.GetComponent<misc_descriptor>());

        PrefabUtility.SaveAsPrefabAsset(contentsRoot, prefabPath);
        PrefabUtility.UnloadPrefabContents(contentsRoot);

        

        AssetImporter.GetAtPath(prefabPath).SetAssetBundleNameAndVariant("misc", "");

        string assetBundleDirectory = "Assets/MISC/output";

        if (!Directory.Exists(assetBundleDirectory))
        {
            Directory.CreateDirectory(assetBundleDirectory);
            Debug.Log("created misc output folder");
        }

        BuildPipeline.BuildAssetBundles(assetBundleDirectory, BuildAssetBundleOptions.None, EditorUserBuildSettings.activeBuildTarget);
        Debug.Log("created misc");
        if (File.Exists(prefabPath))
        {
            File.Delete(prefabPath);
        }

        AssetDatabase.Refresh();



    }
}
