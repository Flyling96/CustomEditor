using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SaveExtractHelper
{
    [MenuItem("Assets/Create/ParentAsset")]
    public static void CreateAsset()
    {
        var asset = ScriptableObject.CreateInstance(typeof(ParentAsset)) as ParentAsset;
        asset.m_SubAssetList.Clear();
        var subAsset = ScriptableObject.CreateInstance(typeof(SubAsset)) as SubAsset;
        asset.m_SubAssetList.Add(subAsset);

        var path = AssetDatabase.GetAssetPath(Selection.activeObject.GetInstanceID()) + "/ParentAsset.asset";

        AssetDatabase.CreateAsset(asset, path);
        AssetDatabase.AddObjectToAsset(subAsset, path);
    }

    public void ExtractAsset()
    {

    }
}
