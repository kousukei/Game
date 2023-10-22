using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;
using UnityEngine.Serialization;
using UnityEngine.SceneManagement;



public class Enemy_1: MonoBehaviour
{
    Enemy enemy;
    GameObject Player;
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
    public bool deathFlag;//死亡フラグ
    public GameObject deathEffect;//エフェクト
    public GameObject[] mirror;//アイテムミラー
    public GameObject damageEffect;
    GameObject damageEffectPosition;
    SkillScript skillScript;
    Score_Script score;


    enum Mode
    {
        開始,移動,攻撃, チュートリアル
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
        //プレイヤーがいるがどうか
        if (!Player.activeSelf)
        {
            mode = Mode.移動;
        }
        switch (mode)
        {
            case Mode.開始:
                time += Time.deltaTime;
                if (time >= 2) { mode = Mode.移動; }
                if (SceneManager.GetActiveScene().name== "TutorialScene")
                {
                    mode = Mode.チュートリアル;
                }
                break;
            case Mode.移動:
                enemy.random_move(this.gameObject, speed);//移動
                enemy.Direction(this.gameObject);//向き
                if (enemy.Attack_range(Player, this.gameObject))//プレイヤーの判定
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
                    Player = GameObject.Find("Coby");//分身を目標します。
                }
                else
                {
                    Player = GameObject.Find("Player");//じゃなかったらプレイヤーにします。
                }
                //敵の角度内
                if (enemy.Attack_range(Player, this.gameObject))
                {
                    //敵の距離内
                    switch (enemy.tracking_range(Player, this.gameObject, withinRange, OutOfRange))
                    {
                        case 1:
                            //距離内と角度内なら攻撃
                            enemy.Attack(firing.transform, laser, shootingTime, laser_speed);
                            break;
                        case 2:
                            //距離外なら追跡
                            enemy.Player_move(Player, this.gameObject);
                            break;
                    }
                }
                break;
            case Mode.チュートリアル:
                enemy.Direction(this.gameObject);//向き
                if (enemy.Attack_range(Player, this.gameObject))//プレイヤーの判定
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
        }

        if (HP <= 0)
        {
            Instantiate(deathEffect, this.transform.position, this.transform.rotation);//エフェクト
            score.score(100);//スコア
            MirrorProbability();//アイテムミラーを生成します。
            Destroy(this.gameObject);
        }
        //ダメージを受けたエフェクトのposition
        if (damageEffectPosition != null)
        {
            damageEffectPosition.transform.position = this.transform.position;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Laser")
        {
            HP--;
            if (HP >= 1)
            {
                damageEffectPosition=Instantiate(damageEffect, this.transform.position, this.transform.rotation);
            }
        }
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Ground")
        {
            hit = true;
        }
    }

    void MirrorProbability()
    {
        int i = Random.Range(0, 3);

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
        if (SceneManager.GetActiveScene().name == "TutorialScene")
        {
            GameObject.Find("TutorialUI").GetComponent<TutorialController>().g(15);
            GameObject.Find("TutorialUI").GetComponent<TutorialController>().progress = 15;
            Instantiate(mirror[0], this.transform.position, this.transform.rotation);
        }


    }

}
