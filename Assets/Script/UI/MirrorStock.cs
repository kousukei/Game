using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MirrorStock : MonoBehaviour
{
    [System.NonSerialized] public int maxStock = 3;//���ő厝�Đ�
    [System.NonSerialized] public int currentStock;//���݋����Đ�
    [System.NonSerialized] public int planeMirrorStock = 1;//���ʋ����������P
    [System.NonSerialized] public int convexMirrorStock = 1;//�ʖʋ����������P
    [System.NonSerialized] public int concaveMirrorStock = 1;//���ʋ����������P
    public Image[] image;//�e���̃A�C�R��


    void Update()
    {
        currentStock = planeMirrorStock + concaveMirrorStock + convexMirrorStock;//�~���[�̌��ݐ��v�Z

        //<-------------�~���[�A�C�R��UI�̐F�ς��--------------->
        if (planeMirrorStock == 0)
        {
            image[0].color = Color.black;
        }
        else
        {
            image[0].color=Color.white;
        }
        if (convexMirrorStock == 0)
        {
            image[1].color=Color.black;
        }
        else
        {
            image[1].color = Color.white;
        }
        if(concaveMirrorStock == 0)
        {
            image[2].color=Color.black;
        }
        else
        {
            image[2].color = Color.white;
        }

    }

}
