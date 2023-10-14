using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MirrorStock : MonoBehaviour
{
    [System.NonSerialized] public int maxStock = 3;//鏡最大持て数
    [System.NonSerialized] public int currentStock;//現在鏡持て数
    [System.NonSerialized] public int planeMirrorStock = 1;//平面鏡初期化＝１
    [System.NonSerialized] public int convexMirrorStock = 1;//凸面鏡初期化＝１
    [System.NonSerialized] public int concaveMirrorStock = 1;//凹面鏡初期化＝１
    public Image[] image;//各鏡のアイコン


    void Update()
    {
        currentStock = planeMirrorStock + concaveMirrorStock + convexMirrorStock;//ミラーの現在数計算

        //<-------------ミラーアイコンUIの色変わり--------------->
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
