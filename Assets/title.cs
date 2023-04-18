using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class title : MonoBehaviour
{
    Text text;
    float a = 0;
     GameObject test;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void start()
    {
        SceneManager.LoadScene("GameScene");
        Debug.Log("asd");
    }
}
