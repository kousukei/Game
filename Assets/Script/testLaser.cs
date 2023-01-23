using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testLaser : MonoBehaviour
{
    public float shootingTime;
    float shootingTimeCount;
    public float speed;
    public GameObject laser;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        shootingTimeCount += Time.deltaTime;
        if (2f < shootingTimeCount)
        {
            var gameObject = Instantiate(laser, transform.position, transform.rotation) ;
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward*speed , ForceMode.VelocityChange);
            shootingTimeCount = 0;
        }
    }
}
