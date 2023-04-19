using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class title : MonoBehaviour
{
    float i;
    public GameObject k;
    GameObject ll;
    bool oo;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ll = k;
        if (Input.GetMouseButtonDown(0))
        {
            
            Instantiate(ll, k.transform.position, k.transform.rotation);
        }
        if (Input.GetMouseButtonUp(0))
        {
            Destroy(ll);
        }
    }
    public void start()
    {

    }
}
