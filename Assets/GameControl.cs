using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GameControl : MonoBehaviour
{
    PlayableDirector playableDirector;
    TimeLinePlayableBehaviour timeLine;
    public bool end; 
    // Start is called before the first frame update
    void Start()
    {
        playableDirector = transform.Find("TimeLine").GetComponent<PlayableDirector>();
        end = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (end == true)
        {
            playableDirector.Stop();
        }
    }
}
