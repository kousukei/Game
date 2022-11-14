using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using enemy;

public class Enemy_1: MonoBehaviour
{
    Enemy enemy = new Enemy();
    public float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemy.move(this.transform,speed);
    }
}
