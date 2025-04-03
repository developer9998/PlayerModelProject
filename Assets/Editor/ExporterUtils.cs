using System.IO;
using PlayerModel.Behaviours;
using UnityEditor.SceneManagement;
using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using PlayerModel.Models;
using UnityEngine.XR;
using UnityEngine.SceneManagement;

namespace PlayerModelProject
{
    public class ExporterUtils
    {
        public static void ExportPackage(ModelDescriptor originalDescriptor, string path)
        {
            GameObject gameObject = Object.Instantiate(originalDescriptor.gameObject);
            gameObject.TryGetComponent(out ModelDescriptor descriptor);
            EditorUtility.SetDirty(descriptor);

            descriptor.Digits = new List<Finger>();

            if ((bool)descriptor.leftHand && descriptor.leftHandDigits != null && descriptor.leftHandDigits.Count != 0)
            {
                foreach (FingerData leftHandDigit in descriptor.leftHandDigits)
                {
                    if ((bool)leftHandDigit.RootBone && leftHandDigit.RootBone.IsChildOf(descriptor.leftHand))
                    {
                        Finger item = leftHandDigit.CreateComponent(XRNode.LeftHand);
                        descriptor.Digits.Add(item);
                    }
                }
            }

            if ((bool)descriptor.rightHand && descriptor.rightHandDigits != null && descriptor.rightHandDigits.Count != 0)
            {
                foreach (FingerData rightHandDigit in descriptor.rightHandDigits)
                {
                    if ((bool)rightHandDigit.RootBone && rightHandDigit.RootBone.IsChildOf(descriptor.rightHand))
                    {
                        Finger item = rightHandDigit.CreateComponent(XRNode.RightHand);
                        descriptor.Digits.Add(item);
                    }
                }
            }

            string fileName = Path.GetFileName(path);

            Debug.Log($"Exporting model {descriptor.ModelName} to {fileName}");

            (bool error, string error_message) = CheckModel(descriptor);
            if (error)
            {
                Object.DestroyImmediate(gameObject);
                if (!PrefabStageUtility.GetCurrentPrefabStage() && !EditorUtility.IsPersistent(originalDescriptor.gameObject)) EditorSceneManager.SaveScene(originalDescriptor.gameObject.scene);
                Debug.Log($"Got error: {error_message}");
                EditorUtility.DisplayDialog($"Warning: {descriptor.ModelName} has an error", error_message, "Ok");
                return;
            }

            Selection.activeObject = gameObject;

            string updatedPath = $"Assets/PlayerModelAsset.prefab";
            PrefabUtility.SaveAsPrefabAsset(Selection.activeObject as GameObject, updatedPath);
            AssetBundleBuild assetBundleBuild = default;
            assetBundleBuild.assetNames = new string[] { updatedPath };
            assetBundleBuild.assetBundleName = fileName;

            BuildPipeline.BuildAssetBundles(Application.temporaryCachePath, new AssetBundleBuild[] { assetBundleBuild }, 0, BuildTarget.StandaloneWindows64);

            string bundle_path = Path.Combine(Application.temporaryCachePath, fileName);

            if (File.Exists(path))
            {
                Debug.Log("Removed existing model at path");
                File.Delete(path);
            }

            if (File.Exists(bundle_path))
            {
                Debug.Log("Moved asset to path");
                File.Move(bundle_path, path);
            }

            if (File.Exists(updatedPath))
            {
                Debug.Log("Removed asset prefab");
                File.Delete(updatedPath);
                File.Delete(string.Concat(updatedPath, ".meta"));
            }

            AssetDatabase.Refresh();
            Object.DestroyImmediate(gameObject);

            var scene = originalDescriptor.gameObject.scene;
            // EditorSceneManager.MarkSceneDirty(scene);
            EditorSceneManager.SaveScene(scene);

            EditorUtility.DisplayDialog($"{descriptor.ModelName}", "The model has been exported", "Ok");
        }

        public static (bool error, string error_message) CheckModel(ModelDescriptor descriptor)
        {
            if (PrefabStageUtility.GetCurrentPrefabStage() || EditorUtility.IsPersistent(descriptor.gameObject))
            {
                return (true, "PlayerModel should be exported in an active scene, much less viewing a prefab");
            }

            var scene = descriptor.gameObject.scene;
            if (!scene.IsValid() || scene != SceneManager.GetActiveScene())
            {
                return (true, "PlayerModel is not in a valid or active scene");
            }

            if (string.IsNullOrEmpty(descriptor.ModelName) || string.IsNullOrWhiteSpace(descriptor.ModelName) || string.IsNullOrEmpty(descriptor.Author) || string.IsNullOrWhiteSpace(descriptor.Author))
            {
                return (true, "ModelName and Author can not be empty. These properties are shown on the model selector and communicated through Photon for networking.");
            }
            /*
            if (!descriptor.DisplayMaterial)
            {
                return (true, "DisplayMaterial does not exist. When a PlayerModel requires any form of symbolism (e.g., scoreboard icon, model selector) it refers to the DisplayMaterial.");
            }
            */
            if (!descriptor.MainMesh || !descriptor.MainMesh.sharedMesh)
            {
                return (true, "SkinnedMeshRenderer property (Model) is not defined or needs a mesh");
            }
            if (!descriptor.body || !descriptor.head || !descriptor.leftHand || !descriptor.rightHand)
            {
                return (true, "All four bone transforms require a value");
            }
            if (descriptor.CustomColors && !descriptor.BaseMaterial)
            {
                return (true, "BaseMaterial requires a value when using custom colors"); // *colours
            }
            if (descriptor.GameModeMaterials && !descriptor.GameMaterial)
            {
                return (true, "GameMaterial requires a value when using game mode materials");
            }
            if (descriptor.LipSync && descriptor.MainMesh.sharedMesh.GetBlendShapeIndex(descriptor.LipShapeName) == -1)
            {
                return (true, $"Blend shape for lip sync \"{descriptor.LipShapeName}\" does not exist");
            }
            return (false, string.Empty);
        }
    }
}