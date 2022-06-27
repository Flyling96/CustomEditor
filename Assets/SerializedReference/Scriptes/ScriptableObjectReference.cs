using System;
using UnityEditor;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class MyBaseClass : ScriptableObject
{
	[SerializeField]
	protected int m_IntField;

	public void OnEnable() { } //hideFlags = HideFlags.HideAndDontSave; }

	public abstract void OnGUI();
}


public static class ScriptableObjectHelper
{
	[MenuItem("SerializedReference/ScriptableObject")]
	public static void CreateSerializeMe()
    {
		var path = EditorUtility.SaveFilePanelInProject("Save ScriptableObject", "SerializeMe", "asset","");
		if(!string.IsNullOrEmpty(path))
        {
			var @object = ScriptableObject.CreateInstance(typeof(SerializeMe));
			AssetDatabase.CreateAsset(@object, path);
		}
    }
}
