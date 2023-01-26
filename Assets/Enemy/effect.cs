using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effect : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject Effect;
    Enemy_1 enemy;
    float time;
    bool flag=false;

    void Start()
    {
        enemy = Enemy.GetComponent<Enemy_1>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(enemy.death_falg);
        if (enemy.death_falg)
        {
            Instantiate(Effect, Enemy.transform.position, transform.rotation);
            flag = true;
            Destroy(Enemy);
            enemy.death_falg = false;
        }
        if (flag)
        {
            time += Time.deltaTime;
            if (time >= 2)
            {
                Destroy(Effect);
                flag = false;
                time = 0;
            }
        }
    }
}
