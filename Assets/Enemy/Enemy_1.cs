using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;



public class Enemy_1: MonoBehaviour
{
    [Header("鏡")]
    //public GameObject[] mirror;
    Enemy enemy;
    GameObject Player;
    //Vector3 randomPosition;
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
    public float HP;
    public bool hit=false;
    //死亡フラグ
    public bool deathFlag;
    //エフェクト
    public GameObject effect;
    //アイテムミラー
    public GameObject[] mirror;
    SkillScript skillScript;
    Score_Script score;


    enum Mode
    {
        開始,移動,攻撃
    }
     Mode mode = Mode.開始;
    void Start()
    {
        Player = GameObject.Find("Player");
        firing = gameObject.transform.Find("object").gameObject;
        enemy = this.gameObject.GetComponent<Enemy>();
        skillScript = GameObject.Find("ScriptObject").GetComponent<SkillScript>();
        score = GameObject.Find("ScriptObject").GetComponent<Score_Script>();
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
                //分身している時間内分身を攻撃
                if (skillScript.CobyTime_flag)
                {
                    Player = GameObject.Find("Coby");
                }
                else
                {
                    Player = GameObject.Find("Player");
                }
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

        }
        if (HP <= 0)
        {
            Instantiate(effect, this.transform.position, this.transform.rotation);
            score.score(100);
            MirrorProbability();
            Destroy(this.gameObject);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Laser")
        {
            HP--;
        }
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Ground")
        {
            hit = true;
        }
    }

    void MirrorProbability()
    {
        int i = Random.Range(0, 20);

        switch (i)
        {
            case 1:
                Instantiate(mirror[0], this.transform.position, this.transform.rotation);
                break;
            case 2:
                Instantiate(mirror[1], this.transform.position, this.transform.rotation);
                break;
            case 3:
                Instantiate(mirror[2], this.transform.position, this.transform.rotation);
                break;
        }
            
    }

}
