using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour
{
    int progress=0;
    GameObject circle, arrow, explanation, letter;
    Text letterText;
    void Start()
    {
        circle = this.transform.Find("Circle").gameObject;
        arrow = this.transform.Find("Arrow").gameObject;
        explanation = this.transform.Find("Explanation").gameObject;
        letter = this.transform.Find("Letter").gameObject;
        letterText = letter.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            progress++;
        }
    }
    void g(int p)
    {
        switch (p)
        {
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
        }
    }
    Vector3 position(int progress)
    {
        Vector3 vector=new Vector3();
        switch (progress)
        {
            case 1:

                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
        }
        return vector;
    }
}
