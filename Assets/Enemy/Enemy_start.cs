using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_start : MonoBehaviour
{
    public GameObject Enemy;
    Vector3 vector3;
    void Start()
    {
        vector3 = this.gameObject.transform.position;
        for(int i = 0; i < 10; i++)
        {
            vector3.x = Random.Range(this.gameObject.transform.position.x - 24, this.gameObject.transform.position.x + 24);
            vector3.y = Random.Range(this.gameObject.transform.position.y, this.gameObject.transform.position.y + 10);
            vector3.z = Random.Range(this.gameObject.transform.position.z - 10, this.gameObject.transform.position.z + 10);
            Instantiate(Enemy, vector3, this.gameObject.transform.rotation);
        }
    }

    
    void Update()
    {
        
    }
}
