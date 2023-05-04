using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class effect : MonoBehaviour
{
    GameObject enemy;
    GameObject player;

    private EffectControl effectControl;
    
    public EffectObject effectObject;

    public Effect eff;
    public enum Effect
    {
        DamageEffect,
        DeathEffect,
        HealEffect
    }
    void Start()
    {
        //enemy = GameObject.Find("enemy");
        player = GameObject.Find("Player");
        effectObject = new EffectObject();
        effectControl = GameObject.Find("EffectObject").GetComponent<EffectControl>();
        effectObject.type = eff.ToString();
        effectObject.gameObject = this;
        effectControl.EffectKeep(effectObject);
        StartCoroutine(Stop());
    }
    void Update()
    {
        switch (eff)
        {
            case Effect.HealEffect:
                this.transform.position = player.transform.position;
                break;
        }

    }
    public void EffectReatart()
    { 
        this.gameObject.SetActive(true);
        StartCoroutine(Stop());
    }
    IEnumerator Stop()
    {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
}
