using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class BaseShell : MonoBehaviour
{
    public GameObject m_Prefab;

    private void OnDisable()
    {
        var obj = UnityEditor.PrefabUtility.GetCorrespondingObjectFromOriginalSource<GameObject>(this.gameObject);
        //var obj = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(path);
        if (obj != null)
        {
            int childCount = obj.transform.childCount;
            for (int i = 0; i < childCount; i++)
            {
                var child = obj.transform.GetChild(0);
                GameObject.DestroyImmediate(child.gameObject, true);
            }
        }
    }
}
