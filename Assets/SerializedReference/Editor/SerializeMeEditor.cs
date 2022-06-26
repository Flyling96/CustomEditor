using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SerializeMe))]
public class SerializeMeEditor : Editor
{
    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        var serializeMe = target as SerializeMe;
        serializeMe.OnGUI();
    }
}
