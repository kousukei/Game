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

    Rigidbody rb;
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }
    IEnumerator LaserStop()
    {//É{Å[ÉãèoÇ»Ç¢
        yield return new WaitForSeconds(5f);
        this.gameObject.SetActive(false);
        enemy.EraseLaser(this);
        yield return null;
    }

    void FixedUpdate()
    {
        lastVelocity = rb.velocity;
    }
    public void Reatart(Transform pos,float laserSpeed)
    {
        transform.position = pos.position;
        this.gameObject.SetActive(true);
        rb.AddForce(pos.transform.forward * laserSpeed, ForceMode.Impulse);
    }
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
            enemy.EraseLaser(this);
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Barrier" || other.tag == "Enemy")
        {
            this.gameObject.SetActive(false);
            enemy.EraseLaser(this);
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
