using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranking : MonoBehaviour
{
    string[] name;
    int[] score;
    string []rank = new string[5] { "1.","2.","3.","4.","5."};
    void Start()
    {

    }

 
    void Update()
    {
        
    }
    void Get()
    {
        
    }
    void Set(int value)
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
            
        }
    }
}
public class ranking
{
    public string[] name;
    public int[] score;
}

