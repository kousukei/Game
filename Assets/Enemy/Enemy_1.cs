using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using enemy;


//[RequireComponent(typeof(MyButton))]
public class Enemy_1: MonoBehaviour
{
    [Header("鏡")]
    public GameObject mirror;
    Enemy enemy;
    GameObject Player;
    Vector3 randomPosition;
    [Header("移動速度")]
    public float speed;
    [Header("回転速度")]
    public float muki_speed;
    GameObject firing;
    public GameObject laser;
    [Header("発射速度")]
    public float shootingTime;
    [Header("レーザーの移動速度")]
    public float laser_speed;
    float time;
    [Header("攻撃範囲")]
    public float withinRange;
    [Header("追跡範囲")]
    public float OutOfRange;
    [Header("死亡フラグ")]
    public bool death_falg;
    public float HP;
    public GameObject effect;
    enum Mode
    {
        開始,移動,攻撃,死亡
    }
     Mode mode = Mode.開始;
    void Start()
    {
        Player = GameObject.Find("Player");
        firing = gameObject.transform.Find("object").gameObject;
        Debug.Log(firing.transform.position);
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
                    switch (enemy.tracking_range(Player, this.gameObject, withinRange, OutOfRange))
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
                if (enemy.Attack_range(Player, this.gameObject))
                {
                    switch (enemy.tracking_range(Player, this.gameObject, withinRange, OutOfRange))
                    {
                        case 1:
                            enemy.Attack(firing.transform, laser, shootingTime, laser_speed);
                            break;
                        case 2:
                            enemy.Player_move(Player, this.gameObject);
                            break;
                    }
                }
                //攻撃範囲外なら移動へ戻る
                if (!enemy.Attack_range(Player, this.gameObject))
                {
                    mode = Mode.移動;
                }
                break;
            case Mode.死亡:
                if (death_falg)
                {
                    
                }
                break;
        }
        if (HP <= 0)
        {
            Instantiate(effect, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Laser")
        {
            HP--;
        }
        if (collision.gameObject.tag == "Enemy")
        {
            //移動方向変わる
        }
    }

}
