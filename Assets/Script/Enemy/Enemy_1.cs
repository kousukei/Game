using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using enemy;

public class Enemy_1: MonoBehaviour
{
    Enemy enemy = new Enemy();
    GameObject Player;
    Vector3 randomPosition;
    public float speed;
    public float muki;
    float time;
    enum Mode
    {
        �ҋ@,�ړ�,�U��,���S
    }
     Mode mode = Mode.�ҋ@;
    void Start()
    {
        Player = GameObject.Find("Player");
        
    }

    
    void Update()
    {
        //Debug.Log(enemy.Judgement(Player.transform,this.transform));
        switch (mode)
        {
            case Mode.�ҋ@:
                time += Time.deltaTime;
                if (time >= 2) { mode = Mode.�ړ�; }
                break;
            case Mode.�ړ�:
                //�w�肵���͈͂Ń����_���ړ�
                enemy.move(this.gameObject, speed);
                //�L�����N�^�[�̌���
                enemy.Direction(Player, this.gameObject, muki);
                //�U���͈�
                if (enemy.Attack_range(Player, this.gameObject))
                {
                    //�U�����[�h�ֈڂ�
                    mode = Mode.�U��;
                }
                break;
            case Mode.�U��:
                //Vector3 player = Player.transform.position;
                ////�v���C���[�̕��ֈړ�
                //enemy.move(this.gameObject, player, speed);
                //enemy.Direction(Player, this.gameObject,muki);
                //Debug.Log("1");
                break;
            case Mode.���S:
                break;
        }

    }

}
