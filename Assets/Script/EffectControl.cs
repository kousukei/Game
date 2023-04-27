using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectControl : MonoBehaviour
{
    public GameObject enemy;
    [SerializeField, Header("ダメージエフェクト")]
    private GameObject damageEffect;
    [SerializeField, Header("ダメージエフェクト")]
    private GameObject deathEffect;

    List<effect> effects = new List<effect>();
    List<GameObject> testObject = new List<GameObject>();


    void Start()
    {
        
    }
    void Update()
    {
        
    }
    //public void EffectMaker(Transform subject)
    //{
    //    StartCoroutine(EffectStart(subject));
    //}
    //IEnumerator EffectStart(Transform effectpos)
    //{
    //    Vector3 pos=effectpos.position;
    //    if (effects.Count > 0)
    //    {
    //        effect effect = effects[0];
    //        effects.RemoveAt(0);
    //        //エフェクトをセットアクティブ
    //        effect.DamageEffect();
    //    }
    //    else
    //    {
    //        GameObject gameObject = Instantiate(damageEffect, pos,Quaternion.identity);
    //        gameObject.transform.position = pos;
    //    }
    //    yield return null;
    //}
    public void EffectKeep(effect effect)
    {
        effects.Add(effect);
    }

    public void DamageStart()
    {
        damageEffect.SetActive(true);
        StartCoroutine(Stop(damageEffect));
        EraseEffect(damageEffect);
    }
    IEnumerator Stop(GameObject gameObject)
    {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
    void EraseEffect(GameObject gameObject)
    {
        testObject.Add(gameObject);
    }

    public void DamageEffect()
    {
        
    }
}
