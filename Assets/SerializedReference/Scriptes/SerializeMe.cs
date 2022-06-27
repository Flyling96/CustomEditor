using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

[Serializable]
public partial class SerializeMe : ScriptableObject
{
	[SerializeField]
	private List<MyBaseClass> m_Instances;

	public void OnEnable()
	{
		if (m_Instances == null)
			m_Instances = new List<MyBaseClass>();

		//hideFlags = HideFlags.HideAndDontSave;
	}
}


#if UNITY_EDITOR

public partial class SerializeMe
{
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
#endif
