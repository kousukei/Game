using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillScript : MonoBehaviour
{
    [SerializeField, Header("表示させるImage")]
    private Image[] image;
    [SerializeField, Header("表示させる画像")]
    private Sprite[] sprite;
    public Barrier barrierScript;
    public HpBar HealScript;
    public EnergyBar energyBar;
    public GameOver gameOver;
    public GameObject Player;
    public bool CobyTime_flag;
    GameObject CobyObject;


    bool barrierSkillFlag=true;
    bool healSkillFlag=true;
    bool Coby_flag =true;
    float healSkillTime, barrierSkillTime, Coby_time;
    public GameObject Im;
    Image II;

    Vector3 za;
    float healEneCost = 50f;
    float barrierEneCost = 50f;
    float decoyEneCost = 30f;
    float skillTime;

    SkillName skill;
    enum SkillName
    {
        heal,
        barrier,
        decoy
    }

    void Start()
    {
        //II = Im.GetComponent<Image>();
        //II.fillAmount = 0;
        skill = SkillName.heal;
    }

    void Update()
    {
        if (Time.timeScale == 0 || gameOver.isDead)
        {
            return;
        }
        //if (Input.GetMouseButtonDown(0))
        //{
        //    if (skill == SkillName.heal)
        //    {
        //        if (energyBar.currentEne > healEneCost)
        //        {
        //            if (HealScript.currentHp < HealScript.maxHp)
        //            {
        //                if (healSkillFlag)
        //                {
        //                    HealScript.Heal();
        //                    energyBar.EneBarControll(healEneCost);
        //                    healSkillFlag = false;
        //                }
        //            }
        //        }
        //    }
        //    else if (skill == SkillName.barrier)
        //    {

        //        if (energyBar.currentEne >= barrierEneCost)
        //        {
        //            if (!barrierScript.isBarrierSkill)
        //            {
        //                //バリアーの時間制限のフラグ
        //                if (barrierSkillFlag)
        //                {
        //                    barrierScript.BarrierSkill();
        //                    energyBar.EneBarControll(barrierEneCost);
        //                    //バリアーの冷却時間の処理
        //                    barrierSkillFlag = false;
        //                }
        //            }
        //        }
        //    }
        //    else if(skill == SkillName.decoy)
        //    {
        //        if (energyBar.currentEne >= decoyEneCost)
        //        {
        //            //分身の時間制限のフラグ
        //            if (Coby_flag)
        //            {
        //                //分身作る
        //                Coby();
        //                //時間切る前に二回不能
        //                Coby_flag = false;
        //                energyBar.EneBarControll(decoyEneCost);
        //            }
        //            Debug.Log("デコイを出した！");
                    
        //        }
        //    }
        //}
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
                                HealScript.Heal();
                                energyBar.EneBarControll(healEneCost);
                                healSkillFlag = false;
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
                                barrierScript.BarrierSkill();
                                energyBar.EneBarControll(barrierEneCost);
                                //バリアーの冷却時間の処理
                                barrierSkillFlag = false;
                            }
                        }
                    }
                    break;
                case SkillName.decoy:
                    if (!barrierScript.isBarrierSkill)
                    {
                        if (energyBar.currentEne >= decoyEneCost)
                        {
                            //分身の時間制限のフラグ
                            if (Coby_flag)
                            {
                                //分身作る
                                Coby();
                                //時間切る前に二回不能
                                Coby_flag = false;
                                energyBar.EneBarControll(decoyEneCost);
                            }
                            Debug.Log("デコイを出した！");

                        }
                    }
                    break;

            }

        }

        if (Input.GetMouseButtonDown(1))
        {
            if (skill == SkillName.heal)
            {
                SkillChange(SkillName.barrier, sprite[1], sprite[2], sprite[0]);
            }
            else if (skill == SkillName.barrier)
            {
                SkillChange(SkillName.decoy, sprite[2], sprite[0], sprite[1]);
            }
            else if (skill == SkillName.decoy)
            {
                SkillChange(SkillName.heal, sprite[0], sprite[1], sprite[2]);
            }
        }


        SkillTime();
    }
    void SkillTime()
    {
        if (!healSkillFlag)
        {
            healSkillTime += Time.deltaTime;
            //II.fillAmount = healSkillTime / 10;
            if (healSkillTime >= 10)
            {
                //II.fillAmount = 0;
                healSkillFlag = true;
                healSkillTime = 0;
            }
        }
        if (!barrierSkillFlag)
        {
            barrierSkillTime += Time.deltaTime;
            if (barrierSkillTime >= 10)
            {
                barrierSkillFlag = true;
                barrierSkillTime = 0;
            }
        }
        if (!Coby_flag)
        {
            Coby_time += Time.deltaTime;
            if (Coby_time > 5)
            {
                Destroy(CobyObject);
                Coby_flag = true;
                Coby_time = 0;
            }
        }
    }
    void SkillChange(SkillName skillname, Sprite first, Sprite second, Sprite third)
    {
        skill = skillname;
        image[0].sprite = first ;
        image[1].sprite = second ;
        image[2].sprite = third ;
    }

    void SkillStatus()
    {

    }
    void Coby()
    {
        za = Player.transform.position;
        za.x = za.x + 1.5f;
        CobyObject=Instantiate(Player, za, Player.transform.rotation);
        CobyObject.name = "Coby";
    }

}
