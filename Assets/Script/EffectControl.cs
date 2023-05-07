using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class EffectControl : MonoBehaviour
{

    [SerializeField, Header("ダメージエフェクト")]
    private GameObject damageEffect;
    [SerializeField, Header("破壊エフェクト")]
    private GameObject deathEffect;
    [SerializeField, Header("回復エフェクト")]
    private GameObject healEffect;
    public bool deatEffectFlag;
    Vector3 playerPos;
    Vector3 enemyPos;
    int num;
    List<EffectObject> effects = new List<EffectObject>();
    
    EffectObject[] objects;

    private void Start()
    {
        deatEffectFlag = false;
    }

    void Update()
    {
    
    }
    public void PlayerEffect(Transform subject,string effectName)
    {
        StartCoroutine(EffectStart(subject,effectName));
    }
    public void effectMaker(GameObject gameObject,string name)
    {
        if(name== "Damage")
        {
            GameObject damageObject = gameObject.transform.Find("DamageEffect").gameObject;
            damageObject.SetActive(true);
            StartCoroutine(EffectStop(damageObject));
        }
        if(name== "Death")
        {
            GameObject deathObject = gameObject.transform.Find("DeathEffect").gameObject;
            deathObject.SetActive(true);
            StartCoroutine(EffectStop(deathObject));
        }
        
    }
    IEnumerator EffectStop(GameObject effect)
    {
        if(effect.gameObject.name== "DeathEffect")
        {
            yield return new WaitForSeconds(0.5f);
            effect.SetActive(false);
            deatEffectFlag = true;
        }
        else
        {
            yield return new WaitForSeconds(1f);
            effect.SetActive(false);
        }

    }
    IEnumerator EffectStart(Transform effectpos,string name)
    {
        Vector3 pos = effectpos.position;


        if (effects.Count > 0)
        {
            objects = new EffectObject[effects.Count];
            switch (name)
            {
                case "Heal":
                    for (int o = 0; o < effects.Count; o++)
                    {
                        objects[o] = effects[o];

                        if (objects[o].type == "HealEffect")
                        {
                            num++;
                            if (num > 0)
                            {
                                EffectObject eff = objects[o];
                                effects.RemoveAt(o);
                                eff.gameObject.EffectReatart();
                                break;
                            }
                        }
                        if (num == 0)
                        {
                            {
                                Production(name, pos);
                            }
                        }
                    }
                    num = 0;
                        break;
            }
        }
        else
        {
            Production(name, pos);
        }
        yield return null;
    }
    void Production(string name,Vector3 pos)
    {
        switch (name)
        {
            case "Heal":
                Instantiate(healEffect, pos, Quaternion.identity);
                break;

        }
    }
    public void EffectKeep(EffectObject effectObject)
    {
        effects.Add(effectObject);
    }

}
public class EffectObject{

    public string type;
    public effect gameObject;
}