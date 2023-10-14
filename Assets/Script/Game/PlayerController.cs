using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public MirrorStock mirrorStock;
    public HpBar hpBar;//HP�o�[
    public GameOver gameOver;//�Q�[���I�[�o�[�I�u�W�F�N�g
    public GameObject planeMirror;//���ʋ��I�u�W�F�N�g
    public GameObject convexMirror;//���ʋ��I�u�W�F�N�g
    public GameObject concaveMirror;//�ʖʋ��I�u�W�F�N�g
    public float speed;//�ړ��X�s�[�h
    public Animator playerAnimator;//�v���C���[�̃A�j���V����

    Plane plane = new Plane();
    Vector3 vec3;
    Rigidbody rb;

    float distance; //ray����̋���
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
        if (Time.timeScale == 0 || gameOver.isDead)//�Q�[���I�[�o�[����
        {
            return;
        }

        horizontalKey = Input.GetAxis("Horizontal");
        verticalKey = Input.GetAxis("Vertical");
        //<-----------------------�J����---------------------------->
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        plane.SetNormalAndPosition(Vector3.up, transform.localPosition);
        if (plane.Raycast(ray, out distance))
        {
            var lookPoint = ray.GetPoint(distance);
            transform.LookAt(lookPoint);
        }
        //<-------------------------------------------------------->
        //<-----------------�~���[�̐؂�ւ�----------------------->
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
        //<--------------------�A�j���V����------------------------->
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

        if (isGround)//�n�ʔ���
        {
            //�v���C���[�ړ�
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
            //�Փ˂�����HP������
            hpBar.Damage();
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            //�n�ʔ���
            isGround = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            //�n�ʔ���
            isGround = false;
        }
    }
    /// <summary>
    /// �~���[�̐؂�ւ��@�\
    /// </summary>
    /// <param name="mirrorNum">�~���[�̎c��</param>
    /// <param name="plaMirrorAct">���ʋ�</param>
    /// <param name="conveMirrorAct">���ʋ�</param>
    /// <param name="concaMirrorAct">�ʖʋ�</param>
    /// <param name="nextMirror">���݋��̎��</param>
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
