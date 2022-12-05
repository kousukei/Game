using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    [Header("ƒGƒlƒ‹ƒM[‚ÌSlider")] public Slider eneSlider;
    [System.NonSerialized] public float currentEne;

    int maxEne = 100;
    int eneHeal= 3;

    void Start()
    {
        eneSlider.value = 1;
        currentEne = maxEne;
    }

    void Update()
    {

    }

    public void EneBarControll(float cost)
    {
        currentEne = currentEne - cost;
        eneSlider.value = (float)currentEne / (float)maxEne;
    }

    public void EneHeal()
    {
        currentEne = currentEne + eneHeal;

        if (currentEne > maxEne)
        {
            currentEne = maxEne;
        }
        eneSlider.value = (float)currentEne / (float)maxEne;
    }
}