using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ScriptableReferenceDebugger : MonoBehaviour
{
    public SerializeMe m_SerializeMe;

    private void Awake()
    {
        if(m_SerializeMe == null)
        {
            m_SerializeMe = ScriptableObject.CreateInstance(typeof(SerializeMe)) as SerializeMe;
        }
    }
}
