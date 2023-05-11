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
    //Enemyを生成する関数
    public void EnemyMaker(string name,Transform transform)
    {
        num = pieces;
        //どの場所に敵を生成するがの判断
        stageName = name;
        switch (stageName)
        {
            case "field_1":
                if (stage1Flag)
                {
                    //敵を生成する
                    for(int i = 0; i < pieces; i++)
                    {
                        Instantiate(enemy_1, RandomPosition(transform), transform.rotation).name = "enemy";
                    }
                    //音を出す
                    audio.StageSound(stage);
                    stage1Flag = false;
                }
                break;
            case "field_2":
                if (stage2Flag)
                {
                    //決めた生成数でループ
                    for(int i = 0; i < pieces; i++)
                    {
                        //Listの敵は生成数より少ないなら
                        //そのまま生成します
                        if (enemy.Count < num)
                        {
                            Instantiate(enemy_1, RandomPosition(transform), transform.rotation).name = "enemy";
                            //生成数を一減らす
                            num--;
                        }
                        //Listの敵は生成数より多いなら
                        else
                        {
                            //Listの中から取り出して
                            GameObject enemy_1 = enemy[0].gameObject;
                            //Listを取り出したEnemtをListから消す
                            enemy.RemoveAt(0);
                            //取り出したEnemyをセットアクティブTrueにします
                            enemy_1.SetActive(true);
                            //ポジションはランダムです
                            enemy_1.gameObject.transform.position = RandomPosition(transform);
                            enemy_1.gameObject.transform.rotation = transform.rotation;
                        }
                    }
                    //敵が生成した時の音
                        audio.StageSound(stage);
                        stage2Flag = false;
                }
                break;
            case "field_3":
                if (stage3Flag)
                {
                    //決めた生成数でループ
                    for (int i = 0; i < pieces; i++)
                    {
                        //Listの敵は生成数より少ないなら
                        //そのまま生成します
                        if (enemy.Count < num)
                        {
                            Instantiate(enemy_1, RandomPosition(transform), transform.rotation).name = "enemy";
                            //生成数を一減らす
                            num--;
                        }
                        //Listの敵は生成数より多いなら
                        else
                        {
                            //Listの中から取り出して
                            GameObject enemy_1 = enemy[0].gameObject;
                            //Listを取り出したEnemtをListから消す
                            enemy.RemoveAt(0);
                            //取り出したEnemyをセットアクティブTrueにします
                            enemy_1.SetActive(true);
                            //ポジションはランダムです
                            enemy_1.gameObject.transform.position = RandomPosition(transform);
                            enemy_1.gameObject.transform.rotation = transform.rotation;
                        }
                    }
                    //敵が生成した時の音
                    audio.StageSound(stage);
                    stage3Flag = false;
                }
                break;
        }
    }


}
