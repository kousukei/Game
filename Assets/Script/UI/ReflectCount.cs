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
    [System.NonSerialized] public int mirrorBreakNum =200, cvMirrorBreakNum = 15, ccMirrorBreakNum = 15;

    public enum Mirror
    {
        planeMirror,
        convexMirror,
        concaveMirror
    }

    void Start()
    {
        //ミラーの反射回数を入れる
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
                //反射回数を切ったらSetActiveをfalse
                gameObject.SetActive(false);
                //ミラーが壊れた音
                audioControl.PlayerSound();
                //ミラーの個数を引く
                mirrorStock.planeMirrorStock--;
                countPlaneMirror = mirrorBreakNum;
            }
        }
        else if (mirror == Mirror.convexMirror)
        {
            CountTextChange(countConvexMirror, cvMirrorBreakNum);
            if (countConvexMirror <= 0)
            {
                //反射回数を切ったらSetActiveをfalse
                gameObject.SetActive(false);
                //ミラーが壊れた音
                audioControl.PlayerSound();
                //ミラーの個数を引く
                mirrorStock.convexMirrorStock--;
                countConvexMirror = cvMirrorBreakNum;
            }
        }
        else if (mirror == Mirror.concaveMirror)
        {
            CountTextChange(countConcaveMirror, ccMirrorBreakNum);
            if (countConcaveMirror <= 0)
            {
                //反射回数を切ったらSetActiveをfalse
                gameObject.SetActive(false);
                //ミラーが壊れた音
                audioControl.PlayerSound();
                //ミラーの個数を引く
                mirrorStock.concaveMirrorStock--;
                countConcaveMirror = ccMirrorBreakNum;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Laser")
        {
            //エネルギーを回復
            energyBar.EneHeal();
            if (mirror == Mirror.planeMirror)
            {
                //ミラーの反射回数を減らす
                countPlaneMirror--;
            }
            else if (mirror == Mirror.convexMirror)
            {
                //ミラーの反射回数を減らす
                countConvexMirror--;
            }
            else if (mirror == Mirror.concaveMirror)
            {
                //ミラーの反射回数を減らす
                countConcaveMirror--;
            }
        }
    }

    public void CountTextChange(int countMirror,int mirrorBreakNum)
    {
        countNum.text = countMirror + " / " + mirrorBreakNum;
    }
}
