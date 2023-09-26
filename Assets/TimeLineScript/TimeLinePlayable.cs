using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

[System.Serializable]
public class TimeLinePlayable : PlayableAsset
{
    // Factory method that generates a playable based on this asset
    public override Playable CreatePlayable(PlayableGraph graph, GameObject go)
    {
        TimeLinePlayableBehaviour timeLine = new TimeLinePlayableBehaviour();
        ScriptPlayable<TimeLinePlayableBehaviour> playable = ScriptPlayable<TimeLinePlayableBehaviour>.Create(graph, timeLine);
        return playable;
    }
}
