using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ranking : MonoBehaviour
{
    int point;
    int[] score=new int[5];
    string []rank = new string[5] { "1.","2.","3.","4.","5."};
    public Text[] rankingText = new Text[5];
    Score_Script sco_Script;
    
    void Start()
    {
        sco_Script = GameObject.Find("ScriptObject").GetComponent<Score_Script>();
        
        point = sco_Script.Score;
        Get();
        Set(point);
        for(int i = 0; i < rankingText.Length; i++)
        {
            rankingText[i].text = score[i].ToString();
        }
    }

 
    void Update()
    {
        
    }
    public void Get()
    {
        for(int i = 0; i < rank.Length; i++)
        {
            score[i] = PlayerPrefs.GetInt(rank[i]);
        }
        
    }
    public void Set(int value)
    {
        for(int i = 0; i < rank.Length; i++)
        {
            if (value > score[i])
            {
                var change = score[i];
                score[i] = value;
                value = change;
            }
        }
        for(int i = 0; i < rank.Length; i++)
        {
            PlayerPrefs.SetInt(rank[i], score[i]);
        }
    }
}


