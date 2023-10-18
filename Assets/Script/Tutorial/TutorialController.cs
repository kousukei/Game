using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour
{
    int progress=0;
    GameObject circle, arrow, explanation, letter;
    Text letterText;
    bool gameTime;
    public float a;
    public float b;
    public float c;
    public float d;
    void Start()
    {
        circle = this.transform.Find("Circle").gameObject;
        arrow = this.transform.Find("Arrow").gameObject;
        explanation = this.transform.Find("Explanation").gameObject;
        letter = this.transform.Find("Letter").gameObject;
        letterText = letter.GetComponent<Text>();
    }


    void Update()
    {
        position(progress);
        if (Input.GetMouseButtonDown(0))
        {
            progress++;
        }
        g(progress);
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
    void TimeStop(bool time)
    {
        if (time)
        {
            Time.timeScale = 0;
            gameTime = false;
        }
    }
    void TimeStart(bool time)
    {
        if (!time)
        {
            Time.timeScale = 1;
            gameTime = true;
        }
    }
    void position(int Progress)
    {
        switch (Progress)
        {
            case 0:
                circle.transform.localPosition = new Vector3(-34.5f, 684.6f, 0);
                circle.transform.localScale = new Vector3(1f, 4.7f, 1f);
                arrow.transform.localPosition = new Vector3(-132f, 706f, 0);

                arrow.transform.localRotation = new Quaternion(0f, 0f, 1f, -2.3f);
                explanation.transform.localPosition = new Vector3(-244f, 656f, 0f);
                explanation.transform.localRotation = new Quaternion(0f, 0f, 1f, 0.93f);
                explanation.transform.localScale = new Vector3(3.5f, 1.2f, 1.2f);
                letter.transform.localPosition = new Vector3(-244f, 656f, 0f);
                letter.transform.localRotation = new Quaternion(0f, 0f, 1f, -1.08f);
                letter.GetComponent<RectTransform>().sizeDelta = new Vector2(308, 100);
                letterText.text = "HPバー:\n0の時ゲームオーバー";
                break;
            case 1:
                circle.transform.localPosition = new Vector3(-76f, 682f, 0);
                circle.transform.localScale = new Vector3(1f, 4.7f, 1f);
                arrow.transform.localPosition = new Vector3(-132f, 706f, 0);

                arrow.transform.localRotation = new Quaternion(0f, 0f, 1f, -2.3f);
                explanation.transform.localPosition = new Vector3(-244f, 656f, 0f);
                explanation.transform.localRotation = new Quaternion(0f, 0f, 1f, 0.93f);
                explanation.transform.localScale = new Vector3(3.5f, 1.2f, 1.2f);
                letter.transform.localPosition = new Vector3(-244f, 656f, 0f);
                letter.transform.localRotation = new Quaternion(0f, 0f, 1f, -1.08f);
                letter.GetComponent<RectTransform>().sizeDelta = new Vector2(308, 100);
                letterText.text = "エネルギーバー:\n0の時スキルが使えなくなります";
                break;
            case 2:
                circle.transform.localPosition = new Vector3(-40f, 286f, 0);
                circle.transform.localScale = new Vector3(1f, 1f, 1f);
                arrow.transform.localPosition = new Vector3(-134f, 325f, 0);

                arrow.transform.localRotation = new Quaternion(0f, 0f, 1f, -2.3f);
                explanation.transform.localPosition = new Vector3(-247f, 278f, 0f);
                explanation.transform.localScale = new Vector3(3.5f, 1.2f, 1.2f);
                letter.transform.localPosition = new Vector3(-244f, 280f, 0f);
                letter.transform.localRotation = new Quaternion(0f, 0f, 1f, -1.08f);
                letter.GetComponent<RectTransform>().sizeDelta = new Vector2(308, 100);
                letterText.text = "スコア:\n今の点数";
                break;
            case 3:
                circle.transform.localPosition = new Vector3(2,10,0);
                arrow.transform.localPosition = new Vector3(-86, 0, 0);
                arrow.transform.localRotation = new Quaternion(0f,0f,1f,-2.3f);
                explanation.transform.localPosition = new Vector3(-184,-111,0);
                explanation.transform.localRotation = new Quaternion(0f,0f,1f, 0.93f); 
                explanation.transform.localScale = new Vector3(3.5f, 1.2f, 1.2f);
                letter.transform.localPosition = new Vector3(-184, -111, 0);
                letter.transform.localRotation = new Quaternion(0f, 0f, 1f, -1.08f);
                letter.GetComponent<RectTransform>().sizeDelta = new Vector2(308, 100);
                letterText.text = "平面鏡:";
                break;
            case 4:
                circle.transform.localPosition = new Vector3(9.2f, -87f, 0);
                arrow.transform.localPosition = new Vector3(-86f, -80f, 0);

                arrow.transform.localRotation = new Quaternion(0f, 0f, 1f, -2.3f);
                explanation.transform.localPosition = new Vector3(-184, -111, 0);
                explanation.transform.localRotation = new Quaternion(0f, 0f, 1f, 0.93f);
                explanation.transform.localScale = new Vector3(3.5f, 1.2f, 1.2f);
                letter.transform.localPosition = new Vector3(-184, -111, 0);
                letter.transform.localRotation = new Quaternion(0f, 0f, 1f, -1.08f);
                letter.GetComponent<RectTransform>().sizeDelta = new Vector2(308, 100);
                letterText.text = "説明0000000";
                break;
            case 5:
                circle.transform.localPosition = new Vector3(18f, -190f, 0f);
                arrow.transform.localPosition = new Vector3(-72f, -178f, 0f);

                arrow.transform.localRotation = new Quaternion(0f, 0f, 1f, -2.3f);
                explanation.transform.localPosition = new Vector3(-184f, -111f, 0f);
                explanation.transform.localRotation = new Quaternion(0f, 0f, 1f, 0.93f);
                explanation.transform.localScale = new Vector3(3.5f, 1.2f, 1.2f);
                letter.transform.localPosition = new Vector3(-184f, -111f, 0f);
                letter.transform.localRotation = new Quaternion(0f, 0f, 1f, -1.08f);
                letter.GetComponent<RectTransform>().sizeDelta = new Vector2(308, 100);
                letterText.text = "説明0000000";
                break;
            case 6:
                circle.transform.localPosition = new Vector3(-568.8f, 346.4f, 0f);
                arrow.transform.localPosition = new Vector3(-469f, 332f, 0f);
                arrow.transform.localRotation = new Quaternion(0f, 0f, 1f, 0.45f);

                explanation.transform.localPosition = new Vector3(-375f, 259f, 0f);
                explanation.transform.localRotation = new Quaternion(0f, 0f, 1f, 0.93f);
                explanation.transform.localScale = new Vector3(3.5f, 1.2f, 1.2f);
                letter.transform.localPosition = new Vector3(-372f, 261f, 0f);
                letter.transform.localRotation = new Quaternion(0f, 0f, 1f, -1.08f);
                letter.GetComponent<RectTransform>().sizeDelta = new Vector2(308f, 100f);
                letterText.text = "説明0000000";
                break;
            case 7:
                circle.transform.localPosition = new Vector3(-550.9f, 246.3f, 0f);
                arrow.transform.localPosition = new Vector3(-454.7f, 244.6f, 0f);
                arrow.transform.localRotation = new Quaternion(0f, 0f, 1f, 0.45f);

                explanation.transform.localPosition = new Vector3(-375f, 259f, 0f);
                explanation.transform.localRotation = new Quaternion(0f, 0f, 1f, 0.93f);
                explanation.transform.localScale = new Vector3(3.5f, 1.2f, 1.2f);
                letter.transform.localPosition = new Vector3(-372f, 261f, 0f);
                letter.transform.localRotation = new Quaternion(0f, 0f, 1f, -1.08f);
                letter.GetComponent<RectTransform>().sizeDelta = new Vector2(308f, 100f);
                letterText.text = "説明0000000";
                break;
            case 8:
                circle.transform.localPosition = new Vector3(-554.5f, 146.5f, 0f);
                arrow.transform.localPosition = new Vector3(-453f, 117f, 0f);
                arrow.transform.localRotation = new Quaternion(0f, 0f, 1f, 0.45f);

                explanation.transform.localPosition = new Vector3(-375f, 259f, 0f);
                explanation.transform.localRotation = new Quaternion(0f, 0f, 1f, 0.93f);
                explanation.transform.localScale = new Vector3(3.5f, 1.2f, 1.2f);
                letter.transform.localPosition = new Vector3(-372f, 261f, 0f);
                letter.transform.localRotation = new Quaternion(0f, 0f, 1f, -1.08f);
                letter.GetComponent<RectTransform>().sizeDelta = new Vector2(308f, 100f);
                letterText.text = "説明0000000";
                break;
            case 9:
                progress = 0;
                break;

        }
    }
}
