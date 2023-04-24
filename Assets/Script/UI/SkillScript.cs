using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SkillScript : MonoBehaviour
{
    [SerializeField, Header("表示させるImage")]
    private Image[] image;
    [SerializeField, Header("効果音")]
    private AudioControl audioControl;

    public Barrier barrierScript;
    public HpBar HealScript;
    public EnergyBar energyBar;
    public GameOver gameOver;
    public GameObject player;
    //エフェクト
    public GameObject healEffect;
    //エフェクトのポジション
    GameObject healEffectPosioion;
    public bool CobyTime_flag;
    GameObject CobyObject;
    //スキルのアニメーション
    public Animator animator;

    bool barrierSkillFlag=true;
    bool healSkillFlag=true;
    bool Coby_flag =true;
    float healSkillTime, barrierSkillTime, Coby_time;

    Vector3 za;
    float healEneCost = 50f;
    float barrierEneCost = 50f;
    float decoyEneCost = 30f;

    SkillName skill;
    public enum SkillName
    {
        heal,
        barrier,
        decoy
    }

    void Start()
    {
        skill = SkillName.heal;
    }

    void Update()
    {
        if (Time.timeScale == 0 || gameOver.isDead)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            
            switch (skill)
            {
                case SkillName.heal:
                    if (energyBar.currentEne > healEneCost)
                    {
                        if (HealScript.currentHp < HealScript.maxHp)
                        {
                            if (healSkillFlag)
                            {
                                //効果音
                                audioControl.SkillSound(skill);
                                //エフェクト
                                healEffectPosioion =Instantiate(healEffect, player.transform.position, player.transform.rotation);

                                HealScript.Heal();
                                energyBar.EneBarControll(healEneCost);
                                //スキル冷却時間フラグ
                                healSkillFlag = false;
                                //スキル冷却時間のUI
                                image[0].fillAmount = 0;
                            }
                        }
                    }
                    break;
                case SkillName.barrier:
                    if (energyBar.currentEne >= barrierEneCost)
                    {
                        if (!barrierScript.isBarrierSkill)
                        {
                            //バリアーの時間制限のフラグ
                            if (barrierSkillFlag)
                            {
                                //効果音
                                audioControl.SkillSound(skill);
                                barrierScript.BarrierSkill();
                                energyBar.EneBarControll(barrierEneCost);
                                //バリアーの冷却時間の処理
                                barrierSkillFlag = false;
                                //スキル冷却時間のUI
                                image[1].fillAmount = 0;

                            }
                        }
                    }
                    break;
                case SkillName.decoy:
                    if (energyBar.currentEne >= decoyEneCost)
                    {
                        //分身の時間制限のフラグ
                        if (Coby_flag)
                        {
                            //効果音
                            audioControl.SkillSound(skill);
                            //分身作る
                            Coby();
                            //時間切る前に二回不能
                            Coby_flag = false;
                            energyBar.EneBarControll(decoyEneCost);
                            //スキル冷却時間のUI
                            image[2].fillAmount = 0;
                        }
                    }
                    break;

            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            animator.SetBool("SkillStart", true);
            switch (skill)
            {
                case SkillName.heal:
                    animator.SetBool("Second", true);
                    animator.SetBool("Third", false);
                    animator.SetBool("First", false);
                    skill = SkillName.barrier;
                    break;
                case SkillName.barrier:
                    animator.SetBool("Third", true);
                    animator.SetBool("Second", false);
                    animator.SetBool("First", false);
                    skill = SkillName.decoy;
                    break;
                case SkillName.decoy:
                    animator.SetBool("First", true);
                    animator.SetBool("Scond", false);
                    animator.SetBool("Third", false);
                    skill = SkillName.heal;
                    break;
            }
        }
        if (healEffectPosioion != null)
        {
            //エフェクトをプレイヤーの位置で出る
            healEffectPosioion.transform.position = player.transform.position;

        }
        //スキルの時間計算
        SkillTime();
    }
    void SkillTime()
    {
        //ヒールのスキル冷却計算
        if (!healSkillFlag)
        {
            healSkillTime += Time.deltaTime;
            image[0].fillAmount= healSkillTime / 10;
            if (healSkillTime >= 10)
            {
                image[0].fillAmount = 1;
                healSkillFlag = true;
                healSkillTime = 0;
            }
        }
        //バリアのスキル冷却計算
        if (!barrierSkillFlag)
        {
            barrierSkillTime += Time.deltaTime;
            image[1].fillAmount= barrierSkillTime / 10;
            if (barrierSkillTime >= 10)
            {
                image[1].fillAmount = 1;
                barrierSkillFlag = true;
                barrierSkillTime = 0;
            }
        }
        ////コビーのスキル冷却計算
        if (!Coby_flag)
        {
            Coby_time += Time.deltaTime;
            image[2].fillAmount = Coby_time / 5;
            if (Coby_time > 5)
            {
                image[2].fillAmount = 1;
                Destroy(CobyObject);
                Coby_flag = true;
                Coby_time = 0;
            }
        }
    }
    //分身
    void Coby()
    {
        za = player.transform.position;
        za.x = za.x + 1.5f;
        CobyObject=Instantiate(player, za, player.transform.rotation);
        CobyObject.name = "Coby";
    }

}
