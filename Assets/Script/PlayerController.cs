using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public HpBar hpBar;
    public GameObject planeMirror;
    public GameObject convexMirror;
    public GameObject concaveMirror;
    public float speed;

    Plane plane = new Plane();
    Vector3 vec3;
    Rigidbody rb;

    float distance; //ray‚©‚ç‚Ì‹——£
    float horizontalKey, verticalKey;
    bool isTrue = true;
    bool isFalse = false;

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
    }

    void Update()
    {
        if (Time.timeScale == 0)
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
            MirrorChange(isTrue, isFalse, isFalse, Mirror.convexMirror);
        }
        else if (mirror == Mirror.convexMirror)
        {
            MirrorChange(isFalse, isTrue, isFalse, Mirror.concaveMirror);
        }
        else if (mirror == Mirror.concaveMirror)
        {
            MirrorChange(isFalse, isFalse, isTrue, Mirror.planeMirror);
        }
    }

    private void FixedUpdate()
    {
        vec3 = new Vector3(horizontalKey, 0, verticalKey);

        if (rb.velocity.magnitude > 1)
        {
            rb.velocity = vec3.normalized * speed;
        }
        else
        {
            rb.velocity = vec3 * speed ;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Laser")
        {
            hpBar.Damage();
        }
    }

    void MirrorChange(bool plaMirrorAct, bool conveMirrorAct, bool concaMirrorAct, Mirror nextMirror)
    {
        planeMirror.SetActive(plaMirrorAct);
        convexMirror.SetActive(conveMirrorAct);
        concaveMirror.SetActive(concaMirrorAct);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            mirror = nextMirror;
        }
    }
}
