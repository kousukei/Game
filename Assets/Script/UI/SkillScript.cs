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

    float healEneCost = 50f;
    float barrierEneCost = 50f;
    float decoyEneCost = 30f;

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
                        HealScript.Heal();
                        energyBar.EneBarControll(healEneCost);
                    }
                }
            }
            else if (skill == SkillName.barrier)
            {

                if (energyBar.currentEne >= barrierEneCost)
                {
                    if (!barrierScript.isBarrierSkill)
                    {
                        barrierScript.BarrierSkill();
                        energyBar.EneBarControll(barrierEneCost);
                    }
                }
            }
            else if(skill == SkillName.decoy)
            {
                if (energyBar.currentEne >= decoyEneCost)
                {
                    Debug.Log("デコイを出した！");
                    energyBar.EneBarControll(decoyEneCost);
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

}
