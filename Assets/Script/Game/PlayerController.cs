using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public MirrorStock mirrorStock;
    public HpBar hpBar;//HPバー
    public GameOver gameOver;//ゲームオーバーオブジェクト
    public GameObject planeMirror;//平面鏡オブジェクト
    public GameObject convexMirror;//凹面鏡オブジェクト
    public GameObject concaveMirror;//凸面鏡オブジェクト
    public float speed;//移動スピード
    public Animator playerAnimator;//プレイヤーのアニメション

    Plane plane = new Plane();
    Vector3 vec3;
    Rigidbody rb;

    float distance; //rayからの距離
    float horizontalKey, verticalKey;
    bool isTrue = true;
    bool isFalse = false;

    bool isGround = false ;
    Mirror mirror;
    enum Mirror
    {
        planeMirror,
        convexMirror,
        concaveMirror
    }
    void Start()
    {
        mirror = Mirror.planeMirror;
        rb = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Time.timeScale == 0 || gameOver.isDead)//ゲームオーバー判定
        {
            return;
        }

        horizontalKey = Input.GetAxis("Horizontal");
        verticalKey = Input.GetAxis("Vertical");
        //<-----------------------カメラ---------------------------->
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        plane.SetNormalAndPosition(Vector3.up, transform.localPosition);
        if (plane.Raycast(ray, out distance))
        {
            var lookPoint = ray.GetPoint(distance);
            transform.LookAt(lookPoint);
        }
        //<-------------------------------------------------------->
        //<-----------------ミラーの切り替え----------------------->
        if (mirror == Mirror.planeMirror)
        {
            MirrorChange(mirrorStock.planeMirrorStock,isTrue, isFalse, isFalse, Mirror.convexMirror);
        }
        else if (mirror == Mirror.convexMirror)
        {
            MirrorChange(mirrorStock.convexMirrorStock, isFalse, isTrue, isFalse, Mirror.concaveMirror);
        }
        else if (mirror == Mirror.concaveMirror)
        {
            MirrorChange(mirrorStock.concaveMirrorStock, isFalse, isFalse, isTrue, Mirror.planeMirror);
        }
        //<--------------------------------------------------------->
        //<--------------------アニメション------------------------->
        if (vec3 != new Vector3(0,0,0))
        {
            playerAnimator.SetBool("IsRun", true);
        }
        else
        {
            playerAnimator.SetBool("IsRun", false);
        }
        //<--------------------------------------------------------->
        
    }

    private void FixedUpdate()
    {
        vec3 = new Vector3(horizontalKey, 0, verticalKey);

        if (isGround)//地面判定
        {
            //プレイヤー移動
            if (rb.velocity.magnitude > 1)
            {
                rb.velocity = vec3.normalized * speed;
            }
            else
            {
                rb.velocity = vec3 * speed;
            }
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Laser")
        {
            //衝突したらHPを減る
            hpBar.Damage();
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            //地面判定
            isGround = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            //地面判定
            isGround = false;
        }
    }
    /// <summary>
    /// ミラーの切り替え機能
    /// </summary>
    /// <param name="mirrorNum">ミラーの残数</param>
    /// <param name="plaMirrorAct">平面鏡</param>
    /// <param name="conveMirrorAct">凹面鏡</param>
    /// <param name="concaMirrorAct">凸面鏡</param>
    /// <param name="nextMirror">現在鏡の種類</param>
    void MirrorChange(int mirrorNum, bool plaMirrorAct, bool conveMirrorAct, bool concaMirrorAct, Mirror nextMirror)
    {
        if (mirrorNum != 0)
        {
            planeMirror.SetActive(plaMirrorAct);
            convexMirror.SetActive(conveMirrorAct);
            concaveMirror.SetActive(concaMirrorAct);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            mirror = nextMirror;
        }
    }
}
