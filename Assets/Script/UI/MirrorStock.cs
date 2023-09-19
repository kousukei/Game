using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MirrorStock : MonoBehaviour
{
    [System.NonSerialized] public int maxStock = 3;
    [System.NonSerialized] public int currentStock;
    [System.NonSerialized] public int planeMirrorStock = 1;
    [System.NonSerialized] public int convexMirrorStock = 1;
    [System.NonSerialized] public int concaveMirrorStock = 1;
    public Image[] image;
    //public GameObject mirrer;
    //public Text planeMirrorText;
    //public Text convexMirrorText;
    //public Text concaveMirrorText;

    void Update()
    {
        currentStock = planeMirrorStock + concaveMirrorStock + convexMirrorStock;
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
