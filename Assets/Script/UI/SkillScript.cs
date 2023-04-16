using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillScript : MonoBehaviour
{
    [SerializeField, Header("�\��������Image")]
    private Image[] image;
    [SerializeField, Header("�\��������摜")]
    private Sprite[] sprite;
    [SerializeField, Header("���ʉ�")]
    private AudioClip[] audio;
    [SerializeField, Header("���ʉ�Component")]
    private AudioSource[] source; 
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
    Image healImage;

    Vector3 za;
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
        //for(int i = 0; i < image.Length; i++)
        //{
        //    image[i] = GetComponent<Image>();
        //}
        //healImage = Im.GetComponent<Image>();
        //healImage.fillAmount = 0;
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
                            source[0].PlayOneShot(audio[0]);
                            HealScript.Heal();
                            energyBar.EneBarControll(healEneCost);
                            healSkillFlag = false;
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
                        //�o���A�[�̎��Ԑ����̃t���O
                        if (barrierSkillFlag)
                        {
                            source[1].PlayOneShot(audio[1]);
                            barrierScript.BarrierSkill();
                            energyBar.EneBarControll(barrierEneCost);
                            //�o���A�[�̗�p���Ԃ̏���
                            barrierSkillFlag = false;
                        }
                    }
                }
            }
            else if(skill == SkillName.decoy)
            {
                if (energyBar.currentEne >= decoyEneCost)
                {
                    //���g�̎��Ԑ����̃t���O
                    if (Coby_flag)
                    {
                        source[2].PlayOneShot(audio[2]);
                        //���g���
                        Coby();
                        //���Ԑ؂�O�ɓ��s�\
                        Coby_flag = false;
                        energyBar.EneBarControll(decoyEneCost);
                    }
                    Debug.Log("�f�R�C���o�����I");
                    
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
        //�X�L���̎��Ԍv�Z
        SkillTime();
    }
    void SkillTime()
    {
        //�q�[���̃X�L����p�v�Z
        if (!healSkillFlag)
        {
            healSkillTime += Time.deltaTime;
             //= healSkillTime / 10;
            if (healSkillTime >= 10)
            {
                //healImage.fillAmount = 0;
                healSkillFlag = true;
                healSkillTime = 0;
            }
        }
        //�o���A�̃X�L����p�v�Z
        if (!barrierSkillFlag)
        {
            barrierSkillTime += Time.deltaTime;
            if (barrierSkillTime >= 10)
            {
                barrierSkillFlag = true;
                barrierSkillTime = 0;
            }
        }
        ////�R�r�[�̃X�L����p�v�Z
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
    void Skill(SkillName skill)
    {
        switch (skill)
        {
            case SkillName.heal:
                image[0].fillAmount= healSkillTime / 10;
                image[1].fillAmount=barrierSkillTime / 10;
                image[2].fillAmount=Coby_time / 5;
                break;
                case SkillName.barrier:

                break;

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
