using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

//[CreateAssetMenu(fileName = "Parent Asset")]
public class ParentAsset : PlayableAsset
{
    public List<SubAsset> m_SubAssetList = new List<SubAsset>();

    public int m_Index = 2000;

    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        throw new System.NotImplementedException();
    }
}
