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

[Serializable]
public class ChildClass0 : MyBaseClass
{
	[SerializeField]
	private float m_FloatField;

	public override void OnGUI()
	{
		m_IntField = EditorGUILayout.IntSlider("IntField", m_IntField, 0, 10);
		m_FloatField = EditorGUILayout.Slider("FloatField", m_FloatField, 0f, 10f);
	}
}

[Serializable]
public class ChildClass1 : MyBaseClass
{
	[SerializeField]
	private string m_StringField;

	public override void OnGUI()
	{
		m_IntField = EditorGUILayout.IntSlider("IntField", m_IntField, 0, 10);
		m_StringField = EditorGUILayout.TextField("StringField", m_StringField);
	}
}

[Serializable]
public class SerializeMe : ScriptableObject
{
	[SerializeField]
	private List<MyBaseClass> m_Instances;

	public void OnEnable()
	{
		if (m_Instances == null)
			m_Instances = new List<MyBaseClass>();

		//hideFlags = HideFlags.HideAndDontSave;
	}

	public void OnGUI()
	{
		foreach (var instance in m_Instances)
			instance.OnGUI();

		if (GUILayout.Button("Add Child 0"))
		{
			var @object = CreateInstance(typeof(ChildClass0)) as MyBaseClass;
			AssetDatabase.AddObjectToAsset(@object, this);
			m_Instances.Add(@object);
		}

		if (GUILayout.Button("Add Child 1"))
        {
			var @object = CreateInstance(typeof(ChildClass1)) as MyBaseClass;
			AssetDatabase.AddObjectToAsset(@object, this);
			m_Instances.Add(@object);
		}
	}
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
