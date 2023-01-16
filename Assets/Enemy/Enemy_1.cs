using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using enemy;

public class Enemy_1: MonoBehaviour
{
    //[Header("")]
    

    Enemy enemy = new Enemy();
    GameObject Player;
    GameObject Player2;
    Vector3 randomPosition;
    public float speed;
    public float muki_speed;
    GameObject firing;
    public GameObject laser;
    public float shootingTime;
    public float laser_speed;
    float time;
    public float withinRange;
    public float OutOfRange;
    enum Mode
    {
        開始,移動,攻撃,死亡
    }
     Mode mode = Mode.開始;
    void Start()
    {
        Player = GameObject.Find("Player");
        Player2 = GameObject.Find("Player (1)");
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
                //移動目標
                enemy.random_move(this.gameObject, speed);
                enemy.Direction(this.gameObject);
                //攻撃範囲
                if (enemy.Attack_range(Player, this.gameObject))
                {
                    switch(enemy.tracking_range(Player, this.gameObject, withinRange, OutOfRange))
                    {
                        case 1:
                                mode = Mode.攻撃;
                            break;
                        case 2:
                            enemy.Player_move(Player, this.gameObject);
                            break;
                    }
                        
                }
                break;
            case Mode.攻撃:
                enemy.Attack(firing.transform, laser, shootingTime, laser_speed);
                //攻撃範囲外なら移動へ戻る
                if (!enemy.Attack_range(Player, this.gameObject))
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
