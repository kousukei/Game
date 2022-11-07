using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class title : MonoBehaviour
{
    Text text;
    float a = 0;
    void Start()
    {
        text = GameObject.Find("Text (Legacy)").GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        a += 0.01f;
        if (a >= 1)
        {
            a = 0;
        }
        text.color = new Color(1.0f, 1.0f, 1.0f, a);
    }
}
