using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SkillScript : MonoBehaviour
{
    [SerializeField, Header("�\��������Image")]
    private Image[] image;
    [SerializeField, Header("���ʉ�")]
    private AudioControl audioControl;

    public Barrier barrierScript;
    public HpBar HealScript;
    public EnergyBar energyBar;
    public GameOver gameOver;
    public GameObject player;
    //�G�t�F�N�g
    public GameObject healEffect;
    //�G�t�F�N�g�̃|�W�V����
    GameObject healEffectPosioion;
    public bool CobyTime_flag;
    GameObject CobyObject;
    //�X�L���̃A�j���[�V����
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
                                //���ʉ�
                                audioControl.SkillSound(skill);
                                //�G�t�F�N�g
                                healEffectPosioion =Instantiate(healEffect, player.transform.position, player.transform.rotation);

                                HealScript.Heal();
                                energyBar.EneBarControll(healEneCost);
                                //�X�L����p���ԃt���O
                                healSkillFlag = false;
                                //�X�L����p���Ԃ�UI
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
                            //�o���A�[�̎��Ԑ����̃t���O
                            if (barrierSkillFlag)
                            {
                                //���ʉ�
                                audioControl.SkillSound(skill);
                                barrierScript.BarrierSkill();
                                energyBar.EneBarControll(barrierEneCost);
                                //�o���A�[�̗�p���Ԃ̏���
                                barrierSkillFlag = false;
                                //�X�L����p���Ԃ�UI
                                image[1].fillAmount = 0;

                            }
                        }
                    }
                    break;
                case SkillName.decoy:
                    if (energyBar.currentEne >= decoyEneCost)
                    {
                        //���g�̎��Ԑ����̃t���O
                        if (Coby_flag)
                        {
                            //���ʉ�
                            audioControl.SkillSound(skill);
                            //���g���
                            Coby();
                            //���Ԑ؂�O�ɓ��s�\
                            Coby_flag = false;
                            energyBar.EneBarControll(decoyEneCost);
                            //�X�L����p���Ԃ�UI
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
            //�G�t�F�N�g���v���C���[�̈ʒu�ŏo��
            healEffectPosioion.transform.position = player.transform.position;

        }
        //�X�L���̎��Ԍv�Z
        SkillTime();
    }
    void SkillTime()
    {
        //�q�[���̃X�L����p�v�Z
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
        //�o���A�̃X�L����p�v�Z
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
        ////�R�r�[�̃X�L����p�v�Z
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
    //���g
    void Coby()
    {
        za = player.transform.position;
        za.x = za.x + 1.5f;
        CobyObject=Instantiate(player, za, player.transform.rotation);
        CobyObject.name = "Coby";
    }

}
