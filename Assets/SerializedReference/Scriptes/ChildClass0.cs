using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

[Serializable]
public partial class ChildClass0 : MyBaseClass
{
	[SerializeField]
	private float m_FloatField;
}

#if UNITY_EDITOR
public partial class ChildClass0
{
	public override void OnGUI()
	{
		m_IntField = EditorGUILayout.IntSlider("IntField", m_IntField, 0, 10);
		m_FloatField = EditorGUILayout.Slider("FloatField", m_FloatField, 0f, 10f);
	}
}
#endif