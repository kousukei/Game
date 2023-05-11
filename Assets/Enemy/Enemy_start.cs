using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_start : MonoBehaviour
{
    public GameObject enemy_1;
    Vector3 vector3;
    public Stage stage;
    bool stage1Flag = true;
    bool stage2Flag = true;
    bool stage3Flag = true;
    public GameObject[] stageObject;
    List<Enemy_1> enemy=new List<Enemy_1>();
    public int pieces;
    public AudioControl audio;
    int num;

    string stageName;

    public enum Stage
    {
        stage_1, stage_2, stage_3
    }
    //Enemy���S�������ɃL�b�v����֐�
    public void EnemyKeep(Enemy_1 enemy_1)
    {
        enemy.Add(enemy_1);
    }
    //�����_���Ɍ��߂��ꏊ�ɍ��W���o��
    Vector3 RandomPosition(Transform transform)
    {
        vector3 = transform.position;
        vector3.x = Random.Range(transform.position.x - transform.localScale.x / 2, transform.position.x + transform.localScale.x / 2);
        vector3.y = Random.Range(transform.position.y, transform.position.y + transform.localScale.y / 2);
        vector3.z = Random.Range(transform.position.z - transform.localScale.z / 2, transform.position.z + transform.localScale.z / 2);
        return vector3;
    }
    //Enemy�𐶐�����֐�
    public void EnemyMaker(string name,Transform transform)
    {
        num = pieces;
        //�ǂ̏ꏊ�ɓG�𐶐����邪�̔��f
        stageName = name;
        switch (stageName)
        {
            case "field_1":
                if (stage1Flag)
                {
                    //�G�𐶐�����
                    for(int i = 0; i < pieces; i++)
                    {
                        Instantiate(enemy_1, RandomPosition(transform), transform.rotation).name = "enemy";
                    }
                    //�����o��
                    audio.StageSound(stage);
                    stage1Flag = false;
                }
                break;
            case "field_2":
                if (stage2Flag)
                {
                    //���߂��������Ń��[�v
                    for(int i = 0; i < pieces; i++)
                    {
                        //List�̓G�͐�������菭�Ȃ��Ȃ�
                        //���̂܂ܐ������܂�
                        if (enemy.Count < num)
                        {
                            Instantiate(enemy_1, RandomPosition(transform), transform.rotation).name = "enemy";
                            //���������ꌸ�炷
                            num--;
                        }
                        //List�̓G�͐�������葽���Ȃ�
                        else
                        {
                            //List�̒�������o����
                            GameObject enemy_1 = enemy[0].gameObject;
                            //List�����o����Enemt��List�������
                            enemy.RemoveAt(0);
                            //���o����Enemy���Z�b�g�A�N�e�B�uTrue�ɂ��܂�
                            enemy_1.SetActive(true);
                            //�|�W�V�����̓����_���ł�
                            enemy_1.gameObject.transform.position = RandomPosition(transform);
                            enemy_1.gameObject.transform.rotation = transform.rotation;
                        }
                    }
                    //�G�������������̉�
                        audio.StageSound(stage);
                        stage2Flag = false;
                }
                break;
            case "field_3":
                if (stage3Flag)
                {
                    //���߂��������Ń��[�v
                    for (int i = 0; i < pieces; i++)
                    {
                        //List�̓G�͐�������菭�Ȃ��Ȃ�
                        //���̂܂ܐ������܂�
                        if (enemy.Count < num)
                        {
                            Instantiate(enemy_1, RandomPosition(transform), transform.rotation).name = "enemy";
                            //���������ꌸ�炷
                            num--;
                        }
                        //List�̓G�͐�������葽���Ȃ�
                        else
                        {
                            //List�̒�������o����
                            GameObject enemy_1 = enemy[0].gameObject;
                            //List�����o����Enemt��List�������
                            enemy.RemoveAt(0);
                            //���o����Enemy���Z�b�g�A�N�e�B�uTrue�ɂ��܂�
                            enemy_1.SetActive(true);
                            //�|�W�V�����̓����_���ł�
                            enemy_1.gameObject.transform.position = RandomPosition(transform);
                            enemy_1.gameObject.transform.rotation = transform.rotation;
                        }
                    }
                    //�G�������������̉�
                    audio.StageSound(stage);
                    stage3Flag = false;
                }
                break;
        }
    }


}
