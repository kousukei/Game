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
    public float muki_speed;
    GameObject firing;
    public GameObject laser;
    public float shootingTime;
    public float laser_speed;
    float time;
    enum Mode
    {
        開始,移動,攻撃,死亡
    }
     Mode mode = Mode.開始;
    void Start()
    {
        Player = GameObject.Find("Player");
        firing = gameObject.transform.Find("object").gameObject;

    }

    
    void Update()
    {
        switch (mode)
        {
            case Mode.開始:
                time += Time.deltaTime;
                if (time >= 2) { mode = Mode.移動; }
                break;
            case Mode.移動:
                //
                enemy.move(this.gameObject, speed);
                //
                enemy.Direction(Player, this.gameObject, muki_speed);
                //
                if (enemy.Attack_range(Player, this.gameObject))
                {
                    //
                    mode = Mode.攻撃;
                }
                break;
            case Mode.攻撃:
                if (enemy.Attack_range(Player, this.gameObject))
                {
                    enemy.Attack(firing.transform, laser, shootingTime, laser_speed);
                }
                else
                {
                    mode = Mode.移動;
                }
                break;
            case Mode.死亡:
                Destroy(this.gameObject);
                break;
        }

    }

}
