using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    [Header("�G�l���M�[��Slider")] public Slider eneSlider;//�G�l���M�[�ő��
    [System.NonSerialized] public float currentEne;//���݃G�l���M�[��

    int maxEne = 100;//�ő�G�l���M�[
    int eneHeal= 5;//�G�l���M�[�񕜗�

    void Start()
    {
        eneSlider.value = 1;//�G�l���M�[������
        currentEne = maxEne;//�G�l���M�[���ő剻
    }
    public void EneBarControll(float cost)
    {
        //�G�l���M�[����
        currentEne = currentEne - cost;
        eneSlider.value = (float)currentEne / (float)maxEne;
    }
    public void EneHeal()
    {
        //�G�l���M�[��
        currentEne = currentEne + eneHeal;

        if (currentEne > maxEne)
        {
            currentEne = maxEne;
        }
        eneSlider.value = (float)currentEne / (float)maxEne;
    }
}