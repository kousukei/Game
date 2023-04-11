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

    int skillTimeNumber;
    bool barrierSkillFlag=true;
    bool healSkillFlag=true;

    Vector3 za;
    float healEneCost = 50f;
    float barrierEneCost = 50f;
    float decoyEneCost = 30f;
    float skillTime;

    bool Coby_flag =true;
    SkillName skill;
    enum SkillName
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
            if (skill == SkillName.heal)
            {
                if (energyBar.currentEne > healEneCost)
                {
                    if (HealScript.currentHp < HealScript.maxHp)
                    {
                        if (healSkillFlag)
                        {
                            HealScript.Heal();
                            energyBar.EneBarControll(healEneCost);
                            healSkillFlag = false;
                            skillTimeNumber = 1;
                        }
                    }
                }
            }
            else if (skill == SkillName.barrier)
            {

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
                            skillTimeNumber = 2;
                        }
                    }
                }
            }
            else if(skill == SkillName.decoy)
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
                        skillTimeNumber = 3;
                    }
                    Debug.Log("デコイを出した！");
                    
                }
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
        switch (skillTimeNumber)
        {
            case 0:
                break;
            case 1:
                skillTime += Time.deltaTime;
                if (skillTime >= 10)
                {
                    healSkillFlag = true;
                    skillTimeNumber = 0;
                }
                break;
            case 2:
                //バリアーの冷却時間を10に設定します。
                skillTime += Time.deltaTime;
                if (skillTime >= 10)
                {
                    barrierSkillFlag = true;
                    skillTimeNumber = 0;
                }
                break;
            case 3:
                //分身の冷却時間を5秒を設定します。
                skillTime += Time.deltaTime;
                if (skillTime > 5)
                {
                    Destroy(CobyObject);
                    Coby_flag = true;
                    skillTime = 0;
                    skillTimeNumber = 0;
                }
                break;

        }
        //分身の時間制限のフラグ
        //if (CobyTime_flag)
        //{
        //    coby += Time.deltaTime;
        //    if (coby >= 5)
        //    {
        //        //時間切ったら
        //        //分身の方を消す
        //        Destroy(CobyObject);
        //        CobyTime_flag = false;
        //        Coby_flag = true;
        //        coby = 0;
        //    }
        //}

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
