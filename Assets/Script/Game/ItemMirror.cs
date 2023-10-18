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
    /// <summary>
    /// アイテムミラーを取得
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")//プレイヤーに当てた
        {
            if (mirrorstock.currentStock < mirrorstock.maxStock)//現在ミラー数＜ミラー総数
            {
                //ミラーの種類が一致し、ミラーの残数は0の時
                if (mirror == Mirror.planeMirror&& mirrorstock.planeMirrorStock==0)
                {
                    mirrorstock.planeMirrorStock++;
                }
                else if (mirror == Mirror.convexMirror&& mirrorstock.convexMirrorStock==0)
                {
                    mirrorstock.convexMirrorStock++;
                }
                else if (mirror == Mirror.concaveMirror&& mirrorstock.concaveMirrorStock==0)
                {
                    mirrorstock.concaveMirrorStock++;
                }
            }
            else
            {
                //ミラーの現在残る反射回数を戻す
                if (mirror == Mirror.planeMirror)//ミラーの種類が一致
                {
                    GameObject gameObject = GameObject.Find("Mirror");
                    if (gameObject.transform.Find("PlaneMirror").gameObject.activeSelf)//アクティブの確認
                    {
                        reflectCount = gameObject.transform.Find("PlaneMirror").GetComponent<ReflectCount>();

                        reflectCount.countPlaneMirror = reflectCount.mirrorBreakNum;
                        reflectCount.CountTextChange(reflectCount.mirrorBreakNum, reflectCount.mirrorBreakNum);
                    }
                }
                else if (mirror == Mirror.convexMirror)
                {
                    GameObject gameObject = GameObject.Find("Mirror");
                    if (gameObject.transform.Find("ConvexMirror").gameObject.activeSelf)
                    {
                        reflectCount = gameObject.transform.Find("ConvexMirror").GetComponent<ReflectCount>();
                        reflectCount.countConvexMirror = reflectCount.cvMirrorBreakNum;
                        reflectCount.CountTextChange(reflectCount.cvMirrorBreakNum, reflectCount.cvMirrorBreakNum);
                    }
                }
                else if (mirror == Mirror.concaveMirror)
                {
                    GameObject gameObject = GameObject.Find("Mirror");
                    if (gameObject.transform.Find("ConcaveMirror").gameObject.activeSelf)
                    {
                        reflectCount = gameObject.transform.Find("ConcaveMirror").GetComponent<ReflectCount>();
                        reflectCount.countConcaveMirror = reflectCount.ccMirrorBreakNum;
                        reflectCount.CountTextChange(reflectCount.ccMirrorBreakNum, reflectCount.ccMirrorBreakNum);
                    }
                }
            }
            Destroy(gameObject);
        }
    }
}
