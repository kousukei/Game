using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectControl : MonoBehaviour
{
    public GameObject enemy;
    [SerializeField, Header("�_���[�W�G�t�F�N�g")]
    private GameObject damageEffect;
    GameObject damageObject;
    void Start()
    {
        DamageEffect();
    }

    
    void Update()
    {
        
    }
    public void DamageEffect()
    {
        damageObject= Instantiate(damageEffect,enemy.transform.position,enemy.transform.rotation);
    }
}
