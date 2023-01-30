using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    public GameOver gameOver;   
    public Slider hpSlider;

    [System .NonSerialized]public int maxHp = 100;
    [System.NonSerialized]public int currentHp;
    int damage = 5;
    int heal;

    void Start()
    {
        hpSlider.value = 1;
        currentHp = maxHp;
        heal = maxHp;
    }
    void Update()
    {
        if (hpSlider.value <= 0)
        {
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