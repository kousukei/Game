using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_start : MonoBehaviour
{
    //public Enemy_1 enemy_1;
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

    string stageName;

    public enum Stage
    {
        stage_1, stage_2, stage_3
    }
    void Start()
    {

    }
    public void EnemyLeep(Enemy_1 enemy_1)
    {
        enemy.Add(enemy_1);
    }
    Vector3 RandomPosition(Transform transform)
    {
        vector3 = transform.position;
        vector3.x = Random.Range(transform.position.x - transform.localScale.x / 2, transform.position.x + transform.localScale.x / 2);
        vector3.y = Random.Range(transform.position.y, transform.position.y + transform.localScale.y / 2);
        vector3.z = Random.Range(transform.position.z - transform.localScale.z / 2, transform.position.z + transform.localScale.z / 2);
        return vector3;
    }
    public void StageName(string name)
    {
        stageName = name;
    }
    public void EnemyMaker(string name,Transform transform)
    {
        int ju = pieces;
        stageName = name;
        switch (stageName)
        {
            case "field_1":
                if (stage1Flag)
                {
                    for(int i = 0; i < pieces; i++)
                    {

                        Instantiate(enemy_1, RandomPosition(transform), transform.rotation).name = "enemy"+i;
                    }
                    audio.StageSound(stage);
                    stage1Flag = false;
                }
                break;
            //case "field_2":
            //    audio.StageSound(stage);
                
            //    if (stage2Flag)
            //    {
            //        audio.StageSound(stage);
            //        for (int o = 0; o < pieces; o++)
            //        {
            //            if (enemy.Count > ju)
            //            {
            //                Enemy_1 stage2Enemy = enemy[o];
            //                stage2Enemy.gameObject.SetActive(true);
            //                enemy.RemoveAt(o);
            //                ju--;
            //            }
            //            else
            //            {
            //                Instantiate(enemy_1,RandomPosition(transform), transform.rotation).name = "enemy";
            //                ju--;
            //            }
            //        }
            //        stage2Flag = false;
            //    }
            //    break;
            //case "field_3":
            //    audio.StageSound(stage);
            //    if (stage3Flag)
            //    {
            //        for (int o = 0; o < pieces; o++)
            //        {
            //            if (enemy.Count > ju)
            //            {
            //                Enemy_1 stage2Enemy = enemy[o];
            //                stage2Enemy.gameObject.SetActive(true);
            //                enemy.RemoveAt(o);
            //                ju--;
            //            }
            //            else
            //            {
            //                Instantiate(enemy_1, RandomPosition(transform), transform.rotation).name = "enemy";
            //                ju--;
            //            }
            //        }
            //        stage3Flag = false;
            //    }
            //    break;
        }
    }


}
