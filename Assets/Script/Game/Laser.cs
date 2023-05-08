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
    Vector3 voctor;
    Rigidbody rb;
    

    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
        laserController=GameObject.Find("LaserController").GetComponent<LaserController>();
    }
    public void Position(Vector3 ed)
    {
        voctor = ed;
    }
    IEnumerator LaserStop()
    {//É{Å[ÉãèoÇ»Ç¢
        yield return new WaitForSeconds(1f);
        laserController.EraseLaser(this);
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
        //SetActive(true)ÇÃObjectÇÃRigidbodyÇéÊìæ
        this.gameObject.GetComponent<Rigidbody>().AddForce(pos.forward * laserSpeed, ForceMode.Impulse); ;

        
    }
    //Ç‘Ç¬ÇØÇΩÇÁÇÃîΩéÀä÷êî
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
