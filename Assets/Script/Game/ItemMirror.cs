using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMirror : MonoBehaviour
{
    GameObject ScriptObject;
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
    private void Start()
    {
        ScriptObject = GameObject.Find("ScriptObject");
        mirrorstock = ScriptObject.GetComponent<MirrorStock>();
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
            //壊なれたアイテムを触れたら使えるようにる
            //
            if (mirrorstock.currentStock < mirrorstock.maxStock)
            {
                if (mirror == Mirror.planeMirror && mirrorstock.planeMirrorStock == 0)
                {
                    mirrorstock.planeMirrorStock++;
                }
                else if (mirror == Mirror.convexMirror && mirrorstock.convexMirrorStock == 0)
                {
                    mirrorstock.convexMirrorStock++;
                }
                else if (mirror == Mirror.concaveMirror && mirrorstock.concaveMirrorStock == 0)
                {
                    mirrorstock.concaveMirrorStock++;
                }
            }
            else
            {
                if (mirror == Mirror.planeMirror)
                {
                    reflectCount = other.gameObject.transform.Find("PlaneMirror").GetComponent<ReflectCount>();
                    reflectCount.countPlaneMirror = reflectCount.mirrorBreakNum;
                    
                }
                else if (mirror == Mirror.convexMirror)
                {
                    reflectCount = other.gameObject.transform.Find("convexMirror").GetComponent<ReflectCount>();
                    reflectCount.countConvexMirror = reflectCount.cvMirrorBreakNum;
                    
                }
                else if (mirror == Mirror.concaveMirror)
                {
                    reflectCount = other.gameObject.transform.Find("concaveMirror").GetComponent<ReflectCount>();
                    reflectCount.countConcaveMirror = reflectCount.ccMirrorBreakNum;
                    
                }
            }
            Destroy(gameObject);
        }
    }
}
