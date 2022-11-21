using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    [Header("ƒoƒŠƒA")] public GameObject barrier;

    MeshRenderer mr = null;
    float barrierTime = 10.0f;
    float barrierTimeCount;
    float blinkStartTime = 8.0f;
    float colorA;
    bool isTransparency = false;
    [System.NonSerialized] public bool isBarrierSkill = false;

    void Start()
    {
        mr = barrier.GetComponent<MeshRenderer>();
        colorA = mr.material.color.a;
    }

    void Update()
    {
        if (isBarrierSkill)
        {
            BarrierBlink();
        }
    }

    public void BarrierSkill()
    {
        isBarrierSkill = true;
        barrier.SetActive(true);
        Invoke(nameof(BarrierEnd), barrierTime);
    }
    
    void BarrierEnd()
    {
        if (mr.material.color.a < colorA)
        {
            for (int i = 0; i < (colorA - mr.material.color.a) * 255f; i++)
            {
                mr.material.color = mr.material.color + new Color32(0, 0, 0, 1);
            }
            barrierTimeCount = 0.0f;
            isBarrierSkill = false;
            barrier.SetActive(false);
        }
    }

    void BarrierBlink()
    {
        barrierTimeCount += Time.deltaTime;
        if (barrierTimeCount > blinkStartTime)
        {
            if (mr.material.color.a > colorA)
            {
                isTransparency = true;
            }
            else if (mr.material.color.a < 10f / 255f)
            {
                isTransparency = false;
            }

            if (isTransparency)
            {
                mr.material.color = mr.material.color - new Color32(0, 0, 0, 1);
            }
            else
            {
                mr.material.color = mr.material.color + new Color32(0, 0, 0, 1);
            }
        }
    }
}
