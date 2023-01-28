using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClear : MonoBehaviour
{
    Ranking ranking;
    Animator animator;
    Score_Script score;
    void Start()
    {
        ranking = GameObject.Find("Ranking").GetComponent<Ranking>();
        animator = GameObject.Find("Ranking").GetComponent<Animator>();
        score = GameObject.Find("ScriptObject").GetComponent<Score_Script>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        ranking.Get();
        ranking.Set(score.Score);
        animator.SetBool("start", true);
    }

}
