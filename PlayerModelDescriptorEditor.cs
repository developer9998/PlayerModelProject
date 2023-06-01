using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PlayerModelDescriptor))]
public class PlayerModelDescriptorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        /*if(GUILayout.Button("GUI BUTTON"))
        {
            Debug.Log("gui button pressed");
        }*/
    }

}