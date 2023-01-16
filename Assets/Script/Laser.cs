using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public Vector3 lastVelocity;
    public Vector3 refrectVec;
    Rigidbody rb;
    Enemy_1 enemy;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        enemy = GameObject.Find("enemy1_2").GetComponent<Enemy_1>();
    }

    void FixedUpdate()
    {
        lastVelocity = rb.velocity;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Mirror")
        {
            Reflect(collision);
        }
        //else
        //{
        //    Destroy(gameObject);
        //}
    }

    void Reflect(Collision collision)
    {
        refrectVec = Vector3.Reflect(this.lastVelocity, collision.contacts[0].normal);
        this.rb.velocity = refrectVec;
        Destroy(gameObject, 3.0f);
    }

    void OnTriggerStay(Collider collision)
    {
        if (collision.tag == "Player" || collision.tag == "Barrier")
        {
            Destroy(gameObject);
        }
        if (collision.tag == "Enemy")
        {
            enemy.death_falg = true;
        }
    }
}
