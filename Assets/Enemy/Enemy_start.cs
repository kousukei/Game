using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_start : MonoBehaviour
{
    public Enemy_1 enemy_1;

    Vector3 vector3;
    public Stage stage;
    bool stage1Flag = true;
    bool stage2Flag = true;
    bool stage3Flag = true;
    public GameObject[] stageObject;
    List<Enemy_1> enemy=new List<Enemy_1>();
    public int pieces;
    public AudioControl audio;

    string stageName;

    public enum Stage
    {
        stage_1, stage_2, stage_3
    }
    void Start()
    {

    }
    public void EnemyMaker(int quantity)
    {
        for(int i = 0; i < quantity; i++)
        {
            Instantiate(enemy_1.gameObject,RandomPosition(), this.gameObject.transform.rotation).name = "enemy";
        }
    }
    public void EnemyLeep(Enemy_1 enemy_1)
    {
        enemy.Add(enemy_1);
    }
    Vector3 RandomPosition()
    {
        vector3 = this.gameObject.transform.position;
        vector3.x = Random.Range(this.gameObject.transform.position.x - this.gameObject.transform.localScale.x / 2, this.gameObject.transform.position.x + this.gameObject.transform.localScale.x / 2);
        vector3.y = Random.Range(this.gameObject.transform.position.y, this.gameObject.transform.position.y + this.gameObject.transform.localScale.y / 2);
        vector3.z = Random.Range(this.gameObject.transform.position.z - this.gameObject.transform.localScale.z / 2, this.gameObject.transform.position.z + this.gameObject.transform.localScale.z / 2);
        return vector3;
    }
    public void StageName(string name)
    {
        stageName = name;
    }
    private void OnTriggerEnter(Collider other)
    {




        if (other.gameObject.tag == "Player")
        {
            vector3 = this.gameObject.transform.position;
            
            switch (stageName)
            {
                case "field_1":
                    if (stage1Flag)
                    {
                        EnemyMaker(pieces);
                        audio.StageSound(stage);
                        stage1Flag = false;
                    }
                    break;
                case "field_2":
                    audio.StageSound(stage);
                    int ju = pieces;
                    if (stage2Flag)
                    {
                        for (int o = 0; o < pieces; o++)
                        {
                            if (enemy.Count > ju)
                            {
                                Enemy_1 stage2Enemy = enemy[o];
                                stage2Enemy.gameObject.SetActive(true);
                                enemy.RemoveAt(o);
                                ju--;
                            }
                            else
                            {
                                EnemyMaker(ju);
                                ju--;
                            }
                        }
                        stage2Flag = false;
                    }
                    break;
                case "field_3":
                    audio.StageSound(stage);
                    int io= pieces;
                    if (stage3Flag)
                    {
                        for (int o = 0; o < pieces; o++)
                        {
                            if (enemy.Count > io)
                            {
                                Enemy_1 stage2Enemy = enemy[o];
                                stage2Enemy.gameObject.SetActive(true);
                                enemy.RemoveAt(o);
                                io--;
                            }
                            else
                            {
                                EnemyMaker(io);
                                io--;
                            }
                        }
                        stage3Flag = false;
                    }
                    break;
            }

        }
    }

}
