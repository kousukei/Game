using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Laser : MonoBehaviour
{
    [System.NonSerialized]public Vector3 lastVelocity;
    [System.NonSerialized]public Vector3 refrectVec;
    [System.NonSerialized]public bool onConcaveMirror = false;
    public Enemy enemy;
    
    LaserController laserController;
    Rigidbody rb;
    

    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
        laserController=GameObject.Find("LaserController").GetComponent<LaserController>();
    }
    IEnumerator LaserStop()
    {//ボール出ない
        yield return new WaitForSeconds(1f);
        //レーザーをListに保存します
        laserController.EraseLaser(this);
        //レーザーをセットアクティブfalseにします。
        this.gameObject.SetActive(false);
        
    }

    void FixedUpdate()
    {
        lastVelocity = rb.velocity;
    }
    public void Reatart(Transform pos,float laserSpeed)
    {
        this.gameObject.SetActive(true);
        this.gameObject.transform.rotation = Quaternion.identity;
        this.gameObject.transform.position = pos.position;     
        this.gameObject.GetComponent<Rigidbody>().velocity = pos.forward * laserSpeed;
    }
    //ぶつけたらの反射関数
    void Reflect(Collision collision)
    {
        refrectVec = Vector3.Reflect(this.lastVelocity, collision.contacts[0].normal);
        rb.velocity = refrectVec;
        StartCoroutine(LaserStop());
    }
    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Mirror" || collision.gameObject.tag == "Laser")
        {
            //ミラーとレーザーを衝突した時反射します。
            Reflect(collision);
        }
        else if (collision.gameObject.tag == "Enemy" && onConcaveMirror)
        {
            onConcaveMirror = false;
        }
        else
        {
            this.gameObject.SetActive(false);
            laserController.EraseLaser(this);
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Barrier" || other.tag == "Enemy")
        {
            this.gameObject.SetActive(false);
            laserController.EraseLaser(this);
        }
        if (other.tag == "Laser")
        {
            GetComponent<SphereCollider>().isTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Laser")
        {
            GetComponent<SphereCollider>().isTrigger = false;
        }
    }
}
