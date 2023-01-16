using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConvexMirror : MonoBehaviour
{
    public GameObject laserPrefab;

    float  fowerdSpeed = 5.0f;
    float destroyTime = 1.5f;
    float timeleft;

    void Update()
    {
        timeleft -= Time.deltaTime;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Laser")
        {
            //�A���Ŕ������Ȃ��悤�ɂ���(0.2�b����)
            if (timeleft <= 0.0)
            {
                timeleft = 1f;

                //�e���O���Ɋg�U����
                LaserInstatiate(collision.transform.position, collision.transform.rotation, collision.gameObject.GetComponent<Laser>().refrectVec) ;
                LaserInstatiate(collision.transform.position, collision.transform.rotation, -collision.gameObject.GetComponent<Laser>().lastVelocity);
                LaserInstatiate(collision.transform.position, collision.transform.rotation, transform.forward * fowerdSpeed) ;

                Destroy(collision.gameObject);
            }
        }
    }

    void LaserInstatiate(Vector3 pos, Quaternion rot , Vector3 RefrectRot)
    {
        GameObject newLaser = Instantiate(laserPrefab, pos, rot);
        newLaser.GetComponent<SphereCollider>().isTrigger = true;
        newLaser.GetComponent<Rigidbody>().velocity = RefrectRot;
        Destroy(newLaser, destroyTime);
    }
}
