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
    public Text planeMirrorText;
    public Text convexMirrorText;
    public Text concaveMirrorText;

    void Update()
    {
        currentStock = planeMirrorStock + concaveMirrorStock + convexMirrorStock;
        planeMirrorText.text = "Å~" + planeMirrorStock;
        convexMirrorText.text = "Å~" + convexMirrorStock;
        concaveMirrorText.text = "Å~" + concaveMirrorStock;
    }
}
