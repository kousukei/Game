using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [System.NonSerialized]public Vector3 lastVelocity;
    [System.NonSerialized]public Vector3 refrectVec;
    [System.NonSerialized]public bool onConcaveMirror = false;



    Rigidbody rb;
    float destroyTime = 3f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    void FixedUpdate()
    {
        lastVelocity = rb.velocity;
    }

    void Reflect(Collision collision)
    {
        refrectVec = Vector3.Reflect(this.lastVelocity, collision.contacts[0].normal);
        rb.velocity = refrectVec;
        Destroy(gameObject, destroyTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Mirror" || collision.gameObject.tag == "Laser")
        {
            Reflect(collision);
        }
        ///fumei
        //else if (collision.gameObject.tag == "Enemy" && onConcaveMirror)
        //{
        //    onConcaveMirror = false;
        //}
        else
        {
            Destroy(gameObject);
        }
    }


    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Barrier" || other.tag == "Enemy")
        {
            Destroy(gameObject);
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
