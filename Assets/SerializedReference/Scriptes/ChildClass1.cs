using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

[Serializable]
public partial class ChildClass1 : MyBaseClass
{
	[SerializeField]
	private string m_StringField;

}

#if UNITY_EDITOR
public partial class ChildClass1
{
	public override void OnGUI()
	{
		m_IntField = EditorGUILayout.IntSlider("IntField", m_IntField, 0, 10);
		m_StringField = EditorGUILayout.TextField("StringField", m_StringField);
	}
}
#endif