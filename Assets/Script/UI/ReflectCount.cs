using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReflectCount : MonoBehaviour
{
    public MirrorStock mirrorStock;//ミラー総数
    public EnergyBar energyBar;//エネルギーバースクリプト
    public Mirror mirror;//現在ミラー
    public Text countNum;//反射残数、最大反射回数のTextUI
    public AudioClip clip;//効果音
    public AudioSource source;//


    [System .NonSerialized]public int countPlaneMirror, countConvexMirror, countConcaveMirror;//ミラー反射した回数

    [System.NonSerialized] public int mirrorBreakNum =20, cvMirrorBreakNum = 15, ccMirrorBreakNum = 15;//各ミラーの耐久力

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
        //ミラーの残り反射回数、ミラーの反射回数、UIで表示
        if (mirror == Mirror.planeMirror)
        {
            CountTextChange(countPlaneMirror, mirrorBreakNum);
            if (countPlaneMirror <= 0)
            {
                gameObject.SetActive(false);
                source.PlayOneShot(clip);//ミラー壊れた時の音
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
                source.PlayOneShot(clip);//ミラー壊れた時の音
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
                source.PlayOneShot(clip);//ミラー壊れた時の音
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
