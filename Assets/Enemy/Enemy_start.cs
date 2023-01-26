using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_start : MonoBehaviour
{
    public GameObject Enemy;
    Vector3 vector3;
    void Start()
    {
        Debug.Log(this.gameObject.transform.localScale);
        vector3 = this.gameObject.transform.position;
        for(int i = 0; i < 10; i++)
        {
            vector3.x = Random.Range(this.gameObject.transform.position.x - this.gameObject.transform.localScale.x/2, this.gameObject.transform.position.x + this.gameObject.transform.localScale.x / 2);
            vector3.y = Random.Range(this.gameObject.transform.position.y, this.gameObject.transform.position.y + this.gameObject.transform.localScale.y / 2);
            vector3.z = Random.Range(this.gameObject.transform.position.z - this.gameObject.transform.localScale.z / 2, this.gameObject.transform.position.z + this.gameObject.transform.localScale.z / 2);
            Instantiate(Enemy, vector3, this.gameObject.transform.rotation);
        }
    }

}
