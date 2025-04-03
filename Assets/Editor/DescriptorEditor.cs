using System.Linq;
using PlayerModel.Behaviours;
using UnityEditor;
using UnityEngine;

namespace PlayerModelProject
{
    [CustomEditor(typeof(ModelDescriptor))]
    public class DescriptorEditor : Editor
    {
        private string[] allProperties;

        private static bool head_foldout = true, lhand_foldout = true, rhand_foldout = true;

        public void OnEnable()
        {
            allProperties = typeof(ModelDescriptor).GetFields().Select(x => x.Name).Append("m_Script").ToArray();
        }

        private void DrawProperties(params string[] properties)
        {
            DrawPropertiesExcluding(serializedObject, allProperties.Except(properties).ToArray());
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            ModelDescriptor targetDescriptor = (ModelDescriptor)target;

            // main properties

            DrawProperties(nameof(ModelDescriptor.ModelName), nameof(ModelDescriptor.Author));
             
            GUILayout.Space(10);

            DrawProperties(nameof(ModelDescriptor.MainMesh), nameof(ModelDescriptor.DisplayMaterial));

            EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

            // rig

            EditorGUILayout.PropertyField(serializedObject.FindProperty(nameof(ModelDescriptor.body)), new GUIContent("Body"));
            head_foldout = EditorGUILayout.Foldout(head_foldout, "Head");
            if (head_foldout)
            {
                GUILayout.BeginHorizontal();
                GUILayout.FlexibleSpace();
                GUILayout.BeginVertical(GUILayout.Width(EditorGUIUtility.currentViewWidth * 0.9f));
                EditorGUILayout.PropertyField(serializedObject.FindProperty(nameof(ModelDescriptor.head)), new GUIContent("Bone"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty(nameof(ModelDescriptor.headPositionOffset)), new GUIContent("Position Offset"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty(nameof(ModelDescriptor.headRotationOffset)), new GUIContent("Rotation Offset"));
                GUILayout.EndVertical();
                GUILayout.EndHorizontal();
            }
            lhand_foldout = EditorGUILayout.Foldout(lhand_foldout, "Left Hand");
            if (lhand_foldout)
            {
                GUILayout.BeginHorizontal();
                GUILayout.FlexibleSpace();
                GUILayout.BeginVertical(GUILayout.Width(EditorGUIUtility.currentViewWidth * 0.9f));
                EditorGUILayout.PropertyField(serializedObject.FindProperty(nameof(ModelDescriptor.leftHand)), new GUIContent("Bone"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty(nameof(ModelDescriptor.leftHandPositionOffset)), new GUIContent("Position Offset"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty(nameof(ModelDescriptor.leftHandRotationOffset)), new GUIContent("Rotation Offset"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty(nameof(ModelDescriptor.leftHandDigits)), new GUIContent("Fingers"));
                GUILayout.EndVertical();
                GUILayout.EndHorizontal();
            }
            rhand_foldout = EditorGUILayout.Foldout(rhand_foldout, "Right Hand");
            if (rhand_foldout)
            {
                GUILayout.BeginHorizontal();
                GUILayout.FlexibleSpace();
                GUILayout.BeginVertical(GUILayout.Width(EditorGUIUtility.currentViewWidth * 0.9f));
                EditorGUILayout.PropertyField(serializedObject.FindProperty(nameof(ModelDescriptor.rightHand)), new GUIContent("Bone"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty(nameof(ModelDescriptor.rightHandPositionOffset)), new GUIContent("Position Offset"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty(nameof(ModelDescriptor.rightHandRotationOffset)), new GUIContent("Rotation Offset"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty(nameof(ModelDescriptor.rightHandDigits)), new GUIContent("Fingers"));
                GUILayout.EndVertical();
                GUILayout.EndHorizontal();
            }

            GUILayout.Space(5);
            EditorGUILayout.PropertyField(serializedObject.FindProperty(nameof(ModelDescriptor.IKType)), new GUIContent("IK Solver"));

            EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

            // configuration

            EditorGUILayout.PropertyField(serializedObject.FindProperty(nameof(ModelDescriptor.CustomColors)), new GUIContent("Custom Colours"));
            if (targetDescriptor.CustomColors)
            {
                GUILayout.BeginHorizontal();
                GUILayout.FlexibleSpace();
                GUILayout.BeginVertical(GUILayout.Width(EditorGUIUtility.currentViewWidth * 0.9f));
                EditorGUILayout.PropertyField(serializedObject.FindProperty(nameof(ModelDescriptor.BaseMaterial)), new GUIContent("Reference Material"));
                GUILayout.EndVertical();
                GUILayout.EndHorizontal();
            }

            GUILayout.Space(2);

            EditorGUILayout.PropertyField(serializedObject.FindProperty(nameof(ModelDescriptor.GameModeMaterials)), new GUIContent("Gamemode Materials"));
            if (targetDescriptor.GameModeMaterials)
            {
                GUILayout.BeginHorizontal();
                GUILayout.FlexibleSpace();
                GUILayout.BeginVertical(GUILayout.Width(EditorGUIUtility.currentViewWidth * 0.9f));
                EditorGUILayout.PropertyField(serializedObject.FindProperty(nameof(ModelDescriptor.GameModeMaterialSize)), new GUIContent("Material Size"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty(nameof(ModelDescriptor.GameMaterial)), new GUIContent("Reference Material"));
                GUILayout.EndVertical();
                GUILayout.EndHorizontal();
            }

            GUILayout.Space(2);

            EditorGUILayout.PropertyField(serializedObject.FindProperty(nameof(ModelDescriptor.LipSync)), new GUIContent("Lip Sync"));
            if (targetDescriptor.LipSync)
            {
                GUILayout.BeginHorizontal();
                GUILayout.FlexibleSpace();
                GUILayout.BeginVertical(GUILayout.Width(EditorGUIUtility.currentViewWidth * 0.9f));
                EditorGUILayout.PropertyField(serializedObject.FindProperty(nameof(ModelDescriptor.LipShapeName)), new GUIContent("Blend Shape"));
                GUILayout.EndVertical();
                GUILayout.EndHorizontal();
            }

            EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

            // export

            if (GUILayout.Button("Export PlayerModel"))
            {
                string path = EditorUtility.SaveFilePanel("Save PlayerModel", "", targetDescriptor.ModelName + ".gtplayermodel", "gtplayermodel");

                if (!string.IsNullOrEmpty(path) && !string.IsNullOrWhiteSpace(path))
                {
                    EditorUtility.SetDirty(targetDescriptor);
                    ExporterUtils.ExportPackage(targetDescriptor, path);
                }
            }

            serializedObject?.ApplyModifiedProperties();
        }
    }
}