using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

// A behaviour that is attached to a playable
public class TimeLinePlayableBehaviour : PlayableBehaviour
{
    Camera camera;
    GameObject gameControl;
    // Called when the owning graph starts playing
    public override void OnGraphStart(Playable playable)
    {
        gameControl = GameObject.Find("GameControl");
        gameControl.transform.Find("StartMovie").gameObject.SetActive(true);
        camera = GameObject.Find("Camera").GetComponent<Camera>();
        camera.depth = 2;
    }

    // Called when the owning graph stops playing
    public override void OnGraphStop(Playable playable)
    {
        
    }

    // Called when the state of the playable is set to Play
    public override void OnBehaviourPlay(Playable playable, FrameData info)
    {
        //Debug.Log("111");
        ////ÉJÉÅÉâ1Çê›íu
        //gameControl = GameObject.Find("GameControl");
        //gameControl.transform.Find("StartMovie").gameObject.SetActive(true);
        //camera = GameObject.Find("Camera").GetComponent<Camera>();
        //camera.depth = 2;
    }

    // Called when the state of the playable is set to Paused
    public override void OnBehaviourPause(Playable playable, FrameData info)
    {
        //Debug.Log("222");
        //camera = GameObject.Find("Camera").GetComponent<Camera>();
        //camera.depth = 0;
        //gameControl = GameObject.Find("GameControl");
        //gameControl.transform.Find("StartMovie").gameObject.SetActive(false);

    }

    // Called each frame while the state is set to Play
    public override void PrepareFrame(Playable playable, FrameData info)
    {
        Debug.Log("333");
    }
}
