using UnityEditor;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
public class CreatePlayerModel
{

    static private string prefabPath;

    static public string filePath;

    [MenuItem("Assets/Create Player Model")]
    static public void BuildAssetBundle()
    {

        GameObject obj = Selection.activeGameObject;

        
        string PlayerModelName = obj.GetComponent<PlayerModelDescriptor>().PlayerModelName;
        string Author = obj.GetComponent<PlayerModelDescriptor>().Author;

        bool bool1 = obj.GetComponent<PlayerModelDescriptor>().CustomColors;
        bool bool2 = obj.GetComponent<PlayerModelDescriptor>().GameModeTextures;

        string CustomColors = bool1.ToString();
        string GameModeTextures = bool2.ToString();


        if (!AssetDatabase.IsValidFolder("Assets/PlayerModelOutput"))
        {
            AssetDatabase.CreateFolder("Assets", "PlayerModelOutput");
        }

        if (PlayerModelName == null)
        {
            Debug.Log("Assigning PlayerModel Name to" + obj.name);
            PlayerModelName = obj.name;
        }

        prefabPath = "Assets/PlayerModelOutput/" + PlayerModelName + ".prefab";
        filePath = "Assets/PlayerModelOutput";

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();



        var prefabAsset = PrefabUtility.SaveAsPrefabAsset(obj.gameObject, prefabPath);

        GameObject contentsRoot = PrefabUtility.LoadPrefabContents(prefabPath);


        contentsRoot.name = "playermodel.ParentObject";

        string newprefabPath = "Assets/PlayerModelOutput/" + contentsRoot.name + ".prefab";
        Debug.Log("Finding bones to rename");

        var desc = contentsRoot.GetComponent<PlayerModelDescriptor>();

        desc.head.name = "playermodel.head";

        desc.lefthand.name = "playermodel.lefthand";

        desc.righthand.name = "playermodel.righthand";

        desc.torso.name = "playermodel.torso";
        /*
        if(desc.left_finger != null && desc.right_finger != null)
        {
            desc.left_finger.name = "playermodel.leftfinger";
            desc.right_finger.name = "playermodel.rightfinger";

        }
        */
        desc.body.name = "playermodel.body";

        desc.body.GetComponent<SkinnedMeshRenderer>().updateWhenOffscreen = true;

        Debug.Log("Renamed bones");

        
        Debug.Log(desc);

        Text player_info = contentsRoot.AddComponent<Text>();
        string split = "$";
        player_info.text = PlayerModelName + split + Author + split + CustomColors + split + GameModeTextures;

        Object.DestroyImmediate(contentsRoot.GetComponent<PlayerModelDescriptor>());

        PrefabUtility.SaveAsPrefabAsset(contentsRoot, newprefabPath);
        PrefabUtility.UnloadPrefabContents(contentsRoot);

        if (File.Exists(prefabPath))
        {
            File.Delete(prefabPath);
        }

        AssetImporter.GetAtPath(newprefabPath).SetAssetBundleNameAndVariant("playermodel.assetbundle", "");



        string assetBundleDirectory = "Assets/PlayerModelOutput";

        if (!Directory.Exists("Assets/PlayerModelOutput"))
        {
            Directory.CreateDirectory(assetBundleDirectory);
        }
        string asset_new = filePath + "/" + PlayerModelName;

        string asset_temp = filePath + "/playermodel.assetbundle";

        if (File.Exists(asset_new + ".gtmodel"))
        {

            File.Delete(asset_new + ".gtmodel");
        }


        BuildPipeline.BuildAssetBundles(assetBundleDirectory, BuildAssetBundleOptions.None, EditorUserBuildSettings.activeBuildTarget);

        if (File.Exists(newprefabPath))
        {
            File.Delete(newprefabPath);
        }

        string asset_manifest = assetBundleDirectory + "/playermodel.assetbundle.manifest";
        Debug.Log(asset_manifest);
        if (File.Exists(asset_manifest))
        {
            File.Delete(asset_manifest);
        }

        string folder_manifest = assetBundleDirectory + "/PlayerModelOutput";
        //Debug.Log(folder_manifest);
        if (File.Exists(folder_manifest))
        {
            File.Delete(folder_manifest);

            File.Delete(folder_manifest + ".manifest");
        }



        string metafile = asset_temp + ".meta";
        if (File.Exists(asset_temp))
        {

            Debug.Log("Created " + PlayerModelName);
            File.Move(asset_temp, asset_new + ".gtmodel");
            Debug.Log(metafile);
        }



        AssetDatabase.Refresh();
        Debug.ClearDeveloperConsole();
        Debug.Log("Created " + PlayerModelName);



    }
}