using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_Script : MonoBehaviour
{
    Text text;
    int point=0;
    public int Score;
    public GameObject Score_Object;
    void Start()
    {
        text = Score_Object.GetComponent<Text>();
        text.text = "0";
    }


    void Update()
    {
        Score = point;
    }
    public void score(int score)
    {
        point += score;
        text.text = "" + point;
    }
}
