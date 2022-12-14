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
            //連続で発生しないようにする(0.2秒ごと)
            if (timeleft <= 0.0)
            {
                timeleft = 1f;

                //弾を三発に拡散する
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
