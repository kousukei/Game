using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMirror : MonoBehaviour
{
    public MirrorStock mirrorstock;
    public ReflectCount reflectCount;
    public Mirror mirror;

    float rotateValue;
    float spinVelocity = 180f;
    public enum Mirror
    {
        planeMirror,
        convexMirror,
        concaveMirror
    }

    void Update()
    {
        rotateValue = Time.deltaTime * spinVelocity ;
        transform.Rotate(new Vector3(0f, rotateValue, 0f)) ;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            if (mirrorstock.currentStock < mirrorstock.maxStock)
            {
                if (mirror == Mirror.planeMirror)
                {
                    mirrorstock.planeMirrorStock++;
                }
                else if (mirror == Mirror.convexMirror)
                {
                    mirrorstock.convexMirrorStock++;
                }
                else if (mirror == Mirror.concaveMirror)
                {
                    mirrorstock.concaveMirrorStock++;
                }
            }
            else
            {
                if (mirror == Mirror.planeMirror)
                {
                    reflectCount.countPlaneMirror = reflectCount.mirrorBreakNum;
                    reflectCount.CountTextChange(reflectCount.mirrorBreakNum, reflectCount.mirrorBreakNum);
                }
                else if (mirror == Mirror.convexMirror)
                {
                    reflectCount.countConvexMirror = reflectCount.cvMirrorBreakNum;
                    reflectCount.CountTextChange(reflectCount.cvMirrorBreakNum, reflectCount.cvMirrorBreakNum);
                }
                else if (mirror == Mirror.concaveMirror)
                {
                    reflectCount.countConcaveMirror = reflectCount.ccMirrorBreakNum;
                    reflectCount.CountTextChange(reflectCount.ccMirrorBreakNum, reflectCount.ccMirrorBreakNum);
                }
            }
            Destroy(gameObject);
        }
    }
}
