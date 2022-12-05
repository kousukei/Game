using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public float speed=5.0f;

    void Update()
    {
        float H = Input.GetAxis("Horizontal");
        float V = Input.GetAxis("Vertical");
        this.transform.Translate (new Vector3(H,0.0f,V)*Time.deltaTime*speed);

    }
}
