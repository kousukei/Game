using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReflectCount : MonoBehaviour
{
    public MirrorStock mirrorStock;//�~���[����
    public EnergyBar energyBar;//�G�l���M�[�o�[�X�N���v�g
    public Mirror mirror;//���݃~���[
    public Text countNum;//���ˎc���A�ő唽�ˉ񐔂�TextUI
    public AudioClip clip;//���ʉ�
    public AudioSource source;//


    [System .NonSerialized]public int countPlaneMirror, countConvexMirror, countConcaveMirror;//�~���[���˂�����

    [System.NonSerialized] public int mirrorBreakNum =20, cvMirrorBreakNum = 15, ccMirrorBreakNum = 15;//�e�~���[�̑ϋv��

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
        //�~���[�̎c�蔽�ˉ񐔁A�~���[�̔��ˉ񐔁AUI�ŕ\��
        if (mirror == Mirror.planeMirror)
        {
            CountTextChange(countPlaneMirror, mirrorBreakNum);
            if (countPlaneMirror <= 0)
            {
                gameObject.SetActive(false);
                source.PlayOneShot(clip);//�~���[��ꂽ���̉�
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
                source.PlayOneShot(clip);//�~���[��ꂽ���̉�
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
                source.PlayOneShot(clip);//�~���[��ꂽ���̉�
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
