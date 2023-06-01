using UnityEditor;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class CreatePlayerModel
{

    static private string prefabPath;

    static public string filePath;

    static Material gamemat;
    static Material basemat;
    static bool lipsync;
    [MenuItem("Assets/Create Player Model")]
    static public void BuildAssetBundle()
    {
        bool build = true;
        while(true)
        {
            GameObject obj = Selection.activeGameObject;

            if (obj == null)
            {
                Debug.LogError("PlayerModelDescriptor object not selected");
                build = false;
                break;
            }

            
            
            
            string PlayerModelName = obj.GetComponent<PlayerModelDescriptor>().PlayerModelName;
            string Author = obj.GetComponent<PlayerModelDescriptor>().Author;
            
            GameObject LeftHand = obj.GetComponent<PlayerModelDescriptor>().lefthand;
            GameObject RightHand = obj.GetComponent<PlayerModelDescriptor>().righthand;
            GameObject head = obj.GetComponent<PlayerModelDescriptor>().head;
            GameObject torso = obj.GetComponent<PlayerModelDescriptor>().torso;
            GameObject model = obj.GetComponent<PlayerModelDescriptor>().model;

            bool customcolors = obj.GetComponent<PlayerModelDescriptor>().CustomColors;
            bool gametextures = obj.GetComponent<PlayerModelDescriptor>().GameModeTextures;
            basemat = obj.GetComponent<PlayerModelDescriptor>().BaseMaterial;
            gamemat = obj.GetComponent<PlayerModelDescriptor>().GameMaterial;

            lipsync = obj.GetComponent<PlayerModelDescriptor>().LipSync;


            SkinnedMeshRenderer model_render = model.GetComponent<SkinnedMeshRenderer>();

            int blendShapeCount = model_render.sharedMesh.blendShapeCount;

            if (model.transform.parent.transform.parent != obj.transform || obj.transform.childCount != 1)
            {
                Debug.Log(model.transform.parent.transform.parent + " == " + obj.transform);
                if(model.transform.parent == obj.transform)
                {
                    Debug.LogError("PlayerModelDescriptor is not assigned to the proper gameobject - Need to be assigned to an empty gameobject.");
                }
                else
                {
                    Debug.LogError("PlayerModelDescriptor is not assigned to the proper gameobject.");
                }
                
                build = false;
                break;
            }

            


            if (PlayerModelName == null || PlayerModelName == "")
            {
                Debug.LogError("'Player Model Name' field is empty");
                build = false;
                
            }
            
            if (Author == null || Author == "")
            {
                Debug.LogError("'Author' field is empty");
                build = false;
                
            }
            
            if(LeftHand == null)
            {
                Debug.LogError("'LeftHand' Bone is missing");
                build = false;
            }

            if (RightHand == null)
            {
                Debug.LogError("'RightHand' Bone is missing");
                build = false;
            }

            if (head == null)
            {
                Debug.LogError("'head' Bone is missing");
                build = false;
            }

            if (torso == null)
            {
                Debug.LogError("'torso' Bone is missing");
                build = false;
            }

            if (model == null)
            {
                Debug.LogError("'model' gameobject is missing");
                build = false;
            }

            
            if(model_render == null)
            {
                Debug.LogError("Your 'Model' gameobject has to be a rigged model (Missing SkinnedMeshRenderer)");
                build = false;
            }

            if(customcolors && basemat == null)
            {
                Debug.LogError("'CustomColors' is true but 'Base Material' is missing");
                build = false;
            }
            if (gametextures && gamemat == null)
            {
                Debug.LogError("'GameModeTextures' is true but 'Game Material' is missing");
                build = false;
            }
            if(lipsync && blendShapeCount == 0)
            {
                Debug.LogError("You have 'LipSync' checked On, but your model is missing blend shapes/shape keys");
                build = false;
            }

            break;
        }
        

        

        if (build)
        {
            //Debug.Log("Playermodel building");
            var createplayermodel = new CreatePlayerModel();
            createplayermodel.BuildPlayerModel();
        }
    }



    public void BuildPlayerModel()
    {
        GameObject obj = Selection.activeGameObject;


        string PlayerModelName = obj.GetComponent<PlayerModelDescriptor>().PlayerModelName;
        string Author = obj.GetComponent<PlayerModelDescriptor>().Author;

        bool bool1 = obj.GetComponent<PlayerModelDescriptor>().CustomColors;
        bool bool2 = obj.GetComponent<PlayerModelDescriptor>().GameModeTextures;

        string CustomColors = bool1.ToString();
        string GameModeTextures = bool2.ToString();


        if (!AssetDatabase.IsValidFolder("Assets/Temp"))
        {
            AssetDatabase.CreateFolder("Assets", "Temp");
        }


        prefabPath = "Assets/Temp/" + PlayerModelName + ".prefab";
        if (File.Exists(prefabPath))
        {
            File.Delete(prefabPath);
            File.Delete(prefabPath + ".meta");
        }

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        var prefabAsset = PrefabUtility.SaveAsPrefabAsset(obj.gameObject, prefabPath);

        GameObject contentsRoot = PrefabUtility.LoadPrefabContents(prefabPath);


        contentsRoot.name = "playermodel.ParentObject";

        string newprefabPath = "Assets/Temp/" + contentsRoot.name + ".prefab";
        //Debug.Log("Finding bones to rename");

        var desc = contentsRoot.GetComponent<PlayerModelDescriptor>();

        desc.head.name = "playermodel.head";

        desc.lefthand.name = "playermodel.lefthand";

        desc.righthand.name = "playermodel.righthand";

        desc.torso.name = "playermodel.torso";

        desc.model.name = "playermodel.body";

        desc.model.GetComponent<SkinnedMeshRenderer>().updateWhenOffscreen = true;

        //Debug.Log("Renamed bones");

        //Debug.Log(desc);

        Text player_info = contentsRoot.AddComponent<Text>();
        string split = "$";
        string mat = "";
        string gameMat = "";

        if (bool1)
        {
            mat = basemat.name + " (Instance)";
        }

        if (bool2)
        {
            gameMat = gamemat.name + " (Instance)";
        }
        

        List<string> data = new List<string>();

        data.Add(PlayerModelName);
        data.Add(Author);
        data.Add(CustomColors);
        data.Add(GameModeTextures);
        data.Add(mat);
        data.Add(gameMat);
        data.Add(lipsync.ToString()); //PlayerModel Version (proper scaling, finger movement, mouth movement)

        for (int i = 0; i < data.Count; i++)
        {
            player_info.text += data[i];
            if (i < data.Count - 1)
            {
                player_info.text += split;
            }
        }
        //player_info.text = PlayerModelName + split + Author + split + CustomColors + split + GameModeTextures + split + mat;

        Object.DestroyImmediate(contentsRoot.GetComponent<PlayerModelDescriptor>());
        fingermovement fingerscript = contentsRoot.GetComponent<fingermovement>();
        if (fingerscript != null)
        {
            //Debug.Log("Removed FingerScript");
            Object.DestroyImmediate(contentsRoot.GetComponent<fingermovement>());
        }

        PrefabUtility.SaveAsPrefabAsset(contentsRoot, newprefabPath);
        PrefabUtility.UnloadPrefabContents(contentsRoot);

        if (File.Exists(prefabPath))
        {
            File.Delete(prefabPath);
            
        }

        AssetImporter.GetAtPath(newprefabPath).SetAssetBundleNameAndVariant("playermodel.assetbundle", "");


        string assetBundleDirectory = "Assets/StreamingAssets";

        if (!Directory.Exists(assetBundleDirectory))
        {
            Directory.CreateDirectory(assetBundleDirectory);
        }
        filePath = "Assets/";
        string asset_new = filePath + PlayerModelName;

        string asset_temp = assetBundleDirectory + "/playermodel.assetbundle";

        string gtfile = asset_new + ".gtmodel";
        if (File.Exists(asset_temp))
        {

            File.Delete(asset_temp);
            File.Delete(asset_temp + ".meta");
        }

        //creates assetbundle
        BuildPipeline.BuildAssetBundles(assetBundleDirectory, BuildAssetBundleOptions.None, EditorUserBuildSettings.activeBuildTarget);

        if (File.Exists(newprefabPath))
        {
            File.Delete(newprefabPath);
            File.Delete(newprefabPath + ".meta");
        }



        if (File.Exists(gtfile))
        {
            File.Delete(gtfile);
            File.Move(asset_temp, gtfile);
            Debug.Log("Updated " + gtfile);

        }
        else
        {
            File.Move(asset_temp, gtfile);
            Debug.Log("Created " + gtfile);
        }


        AssetDatabase.Refresh();
        Debug.ClearDeveloperConsole();

    }
}