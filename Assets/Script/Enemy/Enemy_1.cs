using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using enemy;

public class Enemy_1: MonoBehaviour
{
    Enemy enemy = new Enemy();
    GameObject Player;
    Vector3 difference;
    public float speed;
    float time;
    enum Mode
    {
        �ҋ@,�ړ�,�U��,���S
    }
     Mode mode = Mode.�ҋ@;
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    
    void Update()
    {
        Debug.Log(enemy.Judgement(Player.transform,this.transform));
        switch (mode)
        {
            case Mode.�ҋ@:
                time += Time.deltaTime;
                if (time >= 2) { mode = Mode.�ړ�; }
                break;
            case Mode.�ړ�:
                enemy.move(this.transform, speed);
                break;
            case Mode.�U��:

                break;
            case Mode.���S:
                break;
        }

    }
}
