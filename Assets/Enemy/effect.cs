using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effect : MonoBehaviour
{
     GameObject player;
     GameObject enemy;
    float time;
    GameObject damageEffect;
    public Effect eff;
    public enum Effect
    {
        DamageEffect,
        DeathEffect,
        HealEffect
    }
    void Start()
    {
        player = GameObject.Find("Player");
        enemy = GameObject.Find("enemy01");
    }


    void Update()
    {
        time += Time.deltaTime;
        switch (eff)
        {
            case Effect.DamageEffect:

                if (time >= 0.5)
                {
                    Destroy(this.gameObject);
                    time = 0;
                }
                break;
            case Effect.DeathEffect:
                if (time >= 1)
                {
                    Destroy(this.gameObject);
                    time = 0;
                }
                break;
            case Effect.HealEffect:
                if (time >= 1)
                {
                    Destroy(this.gameObject);
                    time = 0;
                }
                break;
        }
    }
    void DamageEffect()
    {

    }
}
