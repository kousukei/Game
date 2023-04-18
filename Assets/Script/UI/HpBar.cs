using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    public GameOver gameOver;   
    public Slider hpSlider;
    bool once = false;

    [SerializeField, Header("エフェクト")]
    private GameObject effect;
    [SerializeField, Header("プレイヤー")]
    private GameObject player;

    [System .NonSerialized]public int maxHp = 100;
    [System.NonSerialized]public int currentHp;
    int damage = 5;
    int heal;

    void Start()
    {
        hpSlider.value = 1;
        currentHp = maxHp;
        heal = 20;
    }
    void Update()
    {
        if (hpSlider.value <= 0)
        {
            if (!once)
            {
                player.SetActive(false);
                Instantiate(effect, player.transform.position, Quaternion.identity);
                once = true;
            }
            gameOver.GameOverScene();
        }
    }

    public void Damage()
    {
        currentHp = currentHp - damage;
        hpSlider.value = (float)currentHp / (float)maxHp;
    }

    public void Heal()
    {
        currentHp = currentHp + heal;

        if (currentHp > maxHp)
        {
            currentHp = maxHp;
        }
        hpSlider.value = (float)currentHp / (float)maxHp; ;
    }
}