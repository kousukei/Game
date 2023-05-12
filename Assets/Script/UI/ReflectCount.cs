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

    //���˂�����
    [System .NonSerialized]public int countPlaneMirror, countConvexMirror, countConcaveMirror;

    //�ϋv��
    [System.NonSerialized] public int mirrorBreakNum =200, cvMirrorBreakNum = 15, ccMirrorBreakNum = 15;

    public enum Mirror
    {
        planeMirror,
        convexMirror,
        concaveMirror
    }

    void Start()
    {
        //�~���[�̔��ˉ񐔂�����
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
                //���ˉ񐔂�؂�����SetActive��false
                gameObject.SetActive(false);
                //�~���[����ꂽ��
                audioControl.PlayerSound();
                //�~���[�̌�������
                mirrorStock.planeMirrorStock--;
                countPlaneMirror = mirrorBreakNum;
            }
        }
        else if (mirror == Mirror.convexMirror)
        {
            CountTextChange(countConvexMirror, cvMirrorBreakNum);
            if (countConvexMirror <= 0)
            {
                //���ˉ񐔂�؂�����SetActive��false
                gameObject.SetActive(false);
                //�~���[����ꂽ��
                audioControl.PlayerSound();
                //�~���[�̌�������
                mirrorStock.convexMirrorStock--;
                countConvexMirror = cvMirrorBreakNum;
            }
        }
        else if (mirror == Mirror.concaveMirror)
        {
            CountTextChange(countConcaveMirror, ccMirrorBreakNum);
            if (countConcaveMirror <= 0)
            {
                //���ˉ񐔂�؂�����SetActive��false
                gameObject.SetActive(false);
                //�~���[����ꂽ��
                audioControl.PlayerSound();
                //�~���[�̌�������
                mirrorStock.concaveMirrorStock--;
                countConcaveMirror = ccMirrorBreakNum;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Laser")
        {
            //�G�l���M�[����
            energyBar.EneHeal();
            if (mirror == Mirror.planeMirror)
            {
                //�~���[�̔��ˉ񐔂����炷
                countPlaneMirror--;
            }
            else if (mirror == Mirror.convexMirror)
            {
                //�~���[�̔��ˉ񐔂����炷
                countConvexMirror--;
            }
            else if (mirror == Mirror.concaveMirror)
            {
                //�~���[�̔��ˉ񐔂����炷
                countConcaveMirror--;
            }
        }
    }

    public void CountTextChange(int countMirror,int mirrorBreakNum)
    {
        countNum.text = countMirror + " / " + mirrorBreakNum;
    }
}
