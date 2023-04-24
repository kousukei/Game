using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReflectCount : MonoBehaviour
{
    public MirrorStock mirrorStock;
    public EnergyBar energyBar;
    public Mirror mirror;
    public Text countNum;
    public AudioControl audioControl;

    //反射した回数
    [System .NonSerialized]public int countPlaneMirror, countConvexMirror, countConcaveMirror;

    //耐久力
    [System.NonSerialized] public int mirrorBreakNum =20, cvMirrorBreakNum = 15, ccMirrorBreakNum = 15;

    public enum Mirror
    {
        planeMirror,
        convexMirror,
        concaveMirror
    }

    void Start()
    {
        countPlaneMirror = mirrorBreakNum; 
        countConvexMirror = cvMirrorBreakNum;
        countConcaveMirror=ccMirrorBreakNum;
        
    }

    void Update()
    {
        if (mirror == Mirror.planeMirror)
        {
            CountTextChange(countPlaneMirror, mirrorBreakNum);
            if (countPlaneMirror <= 0)
            {
                gameObject.SetActive(false);
                //ミラーが壊れた音
                audioControl.PlayerSound();
                mirrorStock.planeMirrorStock--;
                countPlaneMirror = mirrorBreakNum;
            }
        }
        else if (mirror == Mirror.convexMirror)
        {
            CountTextChange(countConvexMirror, cvMirrorBreakNum);
            if (countConvexMirror <= 0)
            {
                gameObject.SetActive(false);
                //ミラーが壊れた音
                audioControl.PlayerSound();
                mirrorStock.convexMirrorStock--;
                countConvexMirror = cvMirrorBreakNum;
            }
        }
        else if (mirror == Mirror.concaveMirror)
        {
            CountTextChange(countConcaveMirror, ccMirrorBreakNum);
            if (countConcaveMirror <= 0)
            {
                gameObject.SetActive(false);
                //ミラーが壊れた音
                audioControl.PlayerSound();
                mirrorStock.concaveMirrorStock--;
                countConcaveMirror = ccMirrorBreakNum;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Laser")
        {
            energyBar.EneHeal();
            if (mirror == Mirror.planeMirror)
            {
                countPlaneMirror--;
            }
            else if (mirror == Mirror.convexMirror)
            {
                countConvexMirror--;
            }
            else if (mirror == Mirror.concaveMirror)
            {
                countConcaveMirror--;
            }
        }
    }

    public void CountTextChange(int countMirror,int mirrorBreakNum)
    {
        countNum.text = countMirror + " / " + mirrorBreakNum;
    }
}
