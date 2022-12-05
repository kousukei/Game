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
        ‘Ò‹@,ˆÚ“®,UŒ‚,€–S
    }
     Mode mode = Mode.‘Ò‹@;
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    
    void Update()
    {
        Debug.Log(enemy.Judgement(Player.transform,this.transform));
        switch (mode)
        {
            case Mode.‘Ò‹@:
                time += Time.deltaTime;
                if (time >= 2) { mode = Mode.ˆÚ“®; }
                break;
            case Mode.ˆÚ“®:
                enemy.move(this.transform, speed);
                break;
            case Mode.UŒ‚:

                break;
            case Mode.€–S:
                break;
        }

    }
}
