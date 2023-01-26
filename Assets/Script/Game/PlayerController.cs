using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public MirrorStock mirrorStock;
    public HpBar hpBar;
    public GameOver gameOver;
    public GameObject planeMirror;
    public GameObject convexMirror;
    public GameObject concaveMirror;
    public float speed;
    public Animator playerAnimator;

    Plane plane = new Plane();
    Vector3 vec3;
    Rigidbody rb;
    Animator animator;

    float distance; //ray‚©‚ç‚Ì‹——£
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
        if (Time.timeScale == 0 || gameOver.isDead)
        {
            return;
        }

        horizontalKey = Input.GetAxis("Horizontal");
        verticalKey = Input.GetAxis("Vertical");

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        plane.SetNormalAndPosition(Vector3.up, transform.localPosition);
        if (plane.Raycast(ray, out distance))
        {
            var lookPoint = ray.GetPoint(distance);
            transform.LookAt(lookPoint);
        }

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

        if (vec3 != new Vector3(0,0,0))
        {
            playerAnimator.SetBool("IsRun", true);
        }
        else
        {
            playerAnimator.SetBool("IsRun", false);
        }
    }

    private void FixedUpdate()
    {
        vec3 = new Vector3(horizontalKey, 0, verticalKey);

        //if (isGround )
        //{
            if (rb.velocity.magnitude > 1)
            {
                rb.velocity = vec3.normalized * speed;
            }
            else
            {
                rb.velocity = vec3 * speed;
            }
        //}
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Laser")
        {
            hpBar.Damage();
        }
    }

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
    //private void OnCollisionStay(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Ground")
    //    {
    //        isGround = true;
    //    }
    //}
    //private void OnCollisionExit(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Ground")
    //    {
    //        isGround = false;
    //    }
    //}
}
