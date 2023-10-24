using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

// A behaviour that is attached to a playable
public class TimeLinePlayableBehaviour : PlayableBehaviour
{
    Camera camera;
    GameObject gameControl;
    GameObject playerObject,timeLinePlayer;
    public bool end = false;
    bool start = false;
    // Called when the owning graph starts playing
    public override void OnGraphStart(Playable playable)
    {
        gameControl = GameObject.Find("GameControl");
        gameControl.transform.Find("StartMovie").gameObject.SetActive(true);
        camera = GameObject.Find("Camera").GetComponent<Camera>();
        playerObject = GameObject.Find("Player");
        playerObject.transform.Find("Robot").gameObject.SetActive(false);
        playerObject.transform.Find("mixamorig:Hips").gameObject.SetActive(false);
        playerObject.transform.Find("Mirror").gameObject.SetActive(false);
        playerObject.GetComponent<PlayerController>().enabled = false;
        camera.depth = 2;
    }

    // Called when the owning graph stops playing
    public override void OnGraphStop(Playable playable)
    {
        
    }

    // Called when the state of the playable is set to Play
    public override void OnBehaviourPlay(Playable playable, FrameData info)
    {

    }

    // Called when the state of the playable is set to Paused
    public override void OnBehaviourPause(Playable playable, FrameData info)
    {
        if (start == true)
        {
            camera = GameObject.Find("Camera").GetComponent<Camera>();
            camera.depth = 0;
            gameControl = GameObject.Find("GameControl");
            gameControl.transform.Find("StartMovie").gameObject.SetActive(false);
            playerObject.transform.Find("Robot").gameObject.SetActive(true);
            playerObject.transform.Find("mixamorig:Hips").gameObject.SetActive(true);
            playerObject.transform.Find("Mirror").gameObject.SetActive(true);
            playerObject.GetComponent<PlayerController>().enabled = true;
            GameObject.Find("Player (1)").SetActive(false);
            GameControl Control = gameControl.GetComponent<GameControl>();
            GameObject.Find("StartGame").transform.Find("BGMObject").gameObject.SetActive(true);
            Control.end = true;
        }
        start = true;

    }

    // Called each frame while the state is set to Play
    public override void PrepareFrame(Playable playable, FrameData info)
    {

    }

}
