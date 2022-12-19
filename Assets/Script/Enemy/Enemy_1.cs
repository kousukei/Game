using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using enemy;

public class Enemy_1: MonoBehaviour
{
    Enemy enemy = new Enemy();
    GameObject Player;
    Vector3 randomPosition;
    public float speed;
    public float muki;
    float time;
    enum Mode
    {
        待機,移動,攻撃,死亡
    }
     Mode mode = Mode.待機;
    void Start()
    {
        Player = GameObject.Find("Player");
        
    }

    
    void Update()
    {
        //Debug.Log(enemy.Judgement(Player.transform,this.transform));
        switch (mode)
        {
            case Mode.待機:
                time += Time.deltaTime;
                if (time >= 2) { mode = Mode.移動; }
                break;
            case Mode.移動:
                //指定した範囲でランダム移動
                enemy.move(this.gameObject, speed);
                //キャラクターの向き
                enemy.Direction(Player, this.gameObject, muki);
                //攻撃範囲
                if (enemy.Attack_range(Player, this.gameObject))
                {
                    //攻撃モードへ移す
                    mode = Mode.攻撃;
                }
                break;
            case Mode.攻撃:
                //Vector3 player = Player.transform.position;
                ////プレイヤーの方へ移動
                //enemy.move(this.gameObject, player, speed);
                //enemy.Direction(Player, this.gameObject,muki);
                //Debug.Log("1");
                break;
            case Mode.死亡:
                break;
        }

    }

}
