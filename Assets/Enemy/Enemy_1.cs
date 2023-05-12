using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;
using UnityEngine.Serialization;



public class Enemy_1: MonoBehaviour
{
    Enemy enemy;
    GameObject Player;
    [Header("移動速度")]
    public float speed;
    [Header("回転速度")]
    public float muki_speed;
    GameObject firing;
    [Header("発射時間")]
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
    ////死亡フラグ
    //public bool deathFlag;
    //エフェクトコントロール
    EffectControl effectControl;
    //アイテムミラー
    public GameObject[] mirror;
    public GameObject damageEffect;
    GameObject damageEffectPosition;
    SkillScript skillScript;
    Score_Script score;
    Enemy_start _Start;

    public bool deatFlag;



    enum Mode
    {
        開始,移動,攻撃
    }
     Mode mode = Mode.開始;
    public EffectObject effect;
    void Start()
    {
        deatFlag = true;
        _Start = GameObject.Find("field_1").GetComponent<Enemy_start>();
        effectControl= GameObject.Find("EffectObject").GetComponent<EffectControl>();
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
                break;
            case Mode.移動:
                //移動目標
                enemy.random_move(this.gameObject, speed);
                enemy.Direction(this.gameObject);
                //敵の目の前
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
                    //分身を目標します。
                    Player = GameObject.Find("Coby");
                }
                else
                {
                    //じゃなかったらプレイヤーにします。
                    Player = GameObject.Find("Player");
                }
                //敵の角度内
                if (enemy.Attack_range(Player, this.gameObject))
                {
                    //敵の距離内
                    switch (enemy.tracking_range(Player, this.gameObject, withinRange, OutOfRange))
                    {
                        case 1:
                            //距離内と角度内なら攻撃
                            enemy.Attack(firing.transform,  shootingTime, laser_speed);
                            break;
                        case 2:
                            //距離外なら追跡
                            enemy.Player_move(Player, this.gameObject);
                            break;
                    }
                }
                else
                {
                    //範囲外なら移動モードへ帰る
                    mode = Mode.移動;
                }
                break;
        }

        if (this.HP <= 0)
        {
            if (deatFlag)
            {
                //死亡のエフェクト
                effectControl.effectMaker(this.gameObject, "Death");
                //スコア
                score.score(100);
                //アイテムミラーを生成します。
                MirrorProbability();
                //Enemy生成するListにキップします
                _Start.EnemyKeep(this);
                //一回だけ処理するBool
                deatFlag = false;
            }
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
                //攻撃されたエフェクト
                effectControl.effectMaker(this.gameObject, "Damage");
            }
        }
        hit = true;

    }

    //アイテムミラーをランダムで生成
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
            
    }

}
