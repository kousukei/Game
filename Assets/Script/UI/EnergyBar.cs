using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    [Header("エネルギーのSlider")] public Slider eneSlider;//エネルギー最大量
    [System.NonSerialized] public float currentEne;//現在エネルギー量

    int maxEne = 100;//最大エネルギー
    int eneHeal= 5;//エネルギー回復量

    void Start()
    {
        eneSlider.value = 1;//エネルギー初期化
        currentEne = maxEne;//エネルギーを最大化
    }
    public void EneBarControll(float cost)
    {
        //エネルギー消費
        currentEne = currentEne - cost;
        eneSlider.value = (float)currentEne / (float)maxEne;
    }
    public void EneHeal()
    {
        //エネルギー回復
        currentEne = currentEne + eneHeal;

        if (currentEne > maxEne)
        {
            currentEne = maxEne;
        }
        eneSlider.value = (float)currentEne / (float)maxEne;
    }
}