using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CustomMultipleSelectionPopupExample))]
public class CustomMultipleSelectionPopupExampleEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var Rect = EditorGUILayout.GetControlRect();
        SerializedProperty property = serializedObject.FindProperty("m_ExampleList");
        if(property != null)
        {
            CustomMultipleSelectionPopupDrawer.DrawMultipleSelectionPopup(Rect,property,new GUIContent("ExampleList"),new string[]{ "a","b","c","d","e"});
        }
    }

}
