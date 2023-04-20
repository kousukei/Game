using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effect : MonoBehaviour
{

    public GameObject enemyDamageEffect;
    float time;
    void Start()
    {
        
    }


    void Update()
    {
        time += Time.deltaTime;
    }
    public void EnemyDamageEffect(Collision collision,Transform enemy)
    {
        if (collision.gameObject.tag == "Laser")
        {
            Instantiate(enemyDamageEffect, enemy.position, enemy.rotation);
            time = 0;
        }
        else if (time >= 1)
        {
            //Destroy(enemyDamageEffect);
        }
    }
}
