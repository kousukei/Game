using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectCount : MonoBehaviour
{
    public MirrorStock mirrorStock;
    public Mirror mirror;

    //”½ŽË‚µ‚½‰ñ”
    int countMirror, countConvexMirror, countConcaveMirror;

    //‘Ï‹v—Í
    int mirrorBreakNum = 15;
    int cvMirrorBreakNum = 10;
    int ccMirrorBreakNum = 10;

    public enum Mirror
    {
        planeMirror,
        convexMirror,
        concaveMirror
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision .gameObject .tag == "Laser")
        {
            if (mirror == Mirror.planeMirror)
            {
                countMirror++;
            }
            else if (mirror ==Mirror.convexMirror)
            {
                countConvexMirror++;
            }
            else if (mirror ==Mirror.concaveMirror)
            {
                countConcaveMirror++;
            }
        }
    }

    void Update()
    {
        if (countMirror >= mirrorBreakNum)
        {
            gameObject.SetActive(false);
            mirrorStock.planeMirrorStock--;
            countMirror = 0;
        }
        if (countConvexMirror >= cvMirrorBreakNum)
        {
            gameObject.SetActive(false);
            mirrorStock.convexMirrorStock--;
            countConvexMirror = 0;
        }
        if (countConcaveMirror >= ccMirrorBreakNum)
        {
            gameObject.SetActive(false);
            mirrorStock.concaveMirrorStock--;
            countConcaveMirror = 0;
        }
    }
}
