using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class EffectControl : MonoBehaviour
{

    [SerializeField, Header("ダメージエフェクト")]
    private GameObject damageEffect;
    [SerializeField, Header("破壊エフェクト")]
    private GameObject deathEffect;
    [SerializeField, Header("回復エフェクト")]
    private GameObject healEffect;
    public bool deatEffectFlag;

    int num;
    List<EffectObject> effects = new List<EffectObject>();
    
    EffectObject[] objects;

    private void Start()
    {
        deatEffectFlag = false;
    }

    void Update()
    {
    
    }
    //プレイヤーのスキルのエフェクト
    public void PlayerEffect(Transform subject,string effectName)
    {
        StartCoroutine(EffectStart(subject,effectName));
    }
    //Enemyのエフェクト
    public void effectMaker(GameObject gameObject,string name)
    {
        //Enemyのエフェクトの種類
        //ダメージ
        if (name== "Damage")
        {
            //Enemyののダメージのエフェクトを取得
            GameObject damageObject = gameObject.transform.Find("DamageEffect").gameObject;
            //セットアクティブ(true)
            damageObject.SetActive(true);
            ////時間切ったらセットアクティブ(false)
            StartCoroutine(EffectStop(damageObject, gameObject));
        }
        //死亡
        if(name== "Death")
        {

            GameObject deathObject = gameObject.transform.Find("DeathEffect").gameObject;
            //セットアクティブ(true)
            deathObject.SetActive(true);
            ////時間切ったらセットアクティブ(false)
            StartCoroutine(EffectStop(deathObject,gameObject));

        }
        
    }
    //エフェクトをセットアクティブ(false);
    IEnumerator EffectStop(GameObject effect,GameObject gameObject)
    {
        if(effect.name== "DeathEffect")
        {
            //０．５秒を待つ
            yield return new WaitForSeconds(0.5f);
            effect.SetActive(false);
            gameObject.SetActive(false);
            //一回だけ処理するのBool
            deatEffectFlag = true;
        }
        else
        {
            //1秒を待つ
            yield return new WaitForSeconds(1f);
            effect.SetActive(false);
        }

    }
    //プレイヤーのスキルのエフェクトを管理する
    IEnumerator EffectStart(Transform effectpos,string name)
    {
        //プレイヤーのポジションを保存する
        Vector3 pos = effectpos.position;
        //保存したエフェクトはいるがどうか
        if (effects.Count > 0)
        {
            //初期化
            objects = new EffectObject[effects.Count];
            //名前によっての処理
            switch (name)
            {
                //回復
                case "Heal":
                    //エフェクトを取り出す
                    for (int o = 0; o < effects.Count; o++)
                    {
                        //listの中のエフェクトをObjectに入れる
                        objects[o] = effects[o];
                        //中にHealEffectがあれば
                        if (objects[o].type == "HealEffect")
                        {
                            //最初のHealeffectを取得したら
                            num++;
                            if (num > 0)
                            {
                                //HealEffectを出す
                                objects[o].gameObject.EffectReatart();
                                //ListのHealEffectを削除
                                effects.RemoveAt(o);
                                //ループから抜けます
                                break;
                            }
                        }
                        //Listの中にHealEffectがないなら
                        if (num == 0)
                        {
                            //HealEffectを生成します
                            Production(name, pos);
                        }
                    }
                    num = 0;
                        break;
            }
        }
        else
        {
            //Listの中にはEffectがなっかたら
            //名前によって欲しいEffectを生成します
            Production(name, pos);
        }
        yield return null;
    }
    //Effectを生成する関数
    void Production(string name,Vector3 pos)
    {
        //名前によって生成するEffectが変わります
        switch (name)
        {
            case "Heal":
                Instantiate(healEffect, pos, Quaternion.identity);
                break;

        }
    }
    //EffectをListに保存
    public void EffectKeep(EffectObject effectObject)
    {
        effects.Add(effectObject);
    }

}
//Listに保存するEffectの形
public class EffectObject{

    public string type;
    public effect gameObject;
}