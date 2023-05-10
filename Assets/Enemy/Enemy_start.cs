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

    string stageName;

    public enum Stage
    {
        stage_1, stage_2, stage_3
    }
    //Enemy死亡した時にキップする関数
    public void EnemyKeep(Enemy_1 enemy_1)
    {
        enemy.Add(enemy_1);
    }
    //ランダムに決めた場所に座標を出す
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
    //Enemyを生成する関数
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
                        Instantiate(enemy_1, RandomPosition(transform), transform.rotation).name = "enemy";
                    }
                    audio.StageSound(stage);
                    stage1Flag = false;
                }
                break;
            case "field_2":
                if (stage2Flag)
                {
                    if (enemy.Count > 0)
                    {
                        for(int i = 0; i < pieces; i++)
                        {
                            GameObject enemy_1 = enemy[i].gameObject;
                            enemy.RemoveAt(0);
                            enemy_1.SetActive(true);
                            
                        }
                    }
                    else
                    {
                        Instantiate(enemy_1, RandomPosition(transform), transform.rotation).name = "enemy";
                    }
                    stage2Flag = false;
                }
                break;
            case "field_3":
                if (stage3Flag)
                {

                }
                break;
        }
    }


}
