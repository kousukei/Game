using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effect : MonoBehaviour
{

    float time;
    public Effect eff;
    public enum Effect
    {
        DamageEffect,
        DeathEffect,
        HealEffect
    }
    void Start()
    {

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

}
