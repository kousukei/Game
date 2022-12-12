using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using enemy;

public class Enemy_1: MonoBehaviour
{
    Enemy enemy = new Enemy();
    GameObject Player;
    //Vector3 difference;
    public float speed;
    public float muki;
    float time;
    enum Mode
    {
        ‘Ò‹@,ˆÚ“®,UŒ‚,€–S
    }
     Mode mode = Mode.‘Ò‹@;
    void Start()
    {
        Player = GameObject.Find("Player");
        Debug.Log(this.gameObject.name);
    }

    
    void Update()
    {
        //Debug.Log(enemy.Judgement(Player.transform,this.transform));
        switch (mode)
        {
            case Mode.‘Ò‹@:
                time += Time.deltaTime;
                if (time >= 2) { mode = Mode.ˆÚ“®; }
                break;
            case Mode.ˆÚ“®:
                enemy.move(this.transform, speed);
                enemy.Direction(Player, this.gameObject, muki);
                break;
            case Mode.UŒ‚:

                break;
            case Mode.€–S:
                break;
        }

    }
}
