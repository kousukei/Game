using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialController : MonoBehaviour
{
    [System.NonSerialized]
    public int progress=0;
    GameObject circle, arrow, explanation, letter,keyObject,mouse,space, start, again;//UIオブジェクト
    public GameObject enemy;//チュートリアル用敵
    GameObject tutoriaCamera;
    Text letterText;//Textコンポーネント
    int gameTime=1;//ゲーム時間
    void Start()
    {
        circle = this.transform.Find("Circle").gameObject;//丸オブジェクト
        arrow = this.transform.Find("Arrow").gameObject;//矢印オブジェクト
        explanation = this.transform.Find("Explanation").gameObject;//表示オブジェクト
        letter = this.transform.Find("Letter").gameObject;//Textオブジェクト
        letterText = letter.GetComponent<Text>();//TextオブジェクトのTextのコンポーネント
        keyObject = this.transform.Find("ButtonKey").gameObject;//キーボードオブジェクト
        mouse = this.transform.Find("Mouse").gameObject;//マウスオブジェクト
        space = this.transform.Find("Space").gameObject;//スペースオブジェクト
        tutoriaCamera = this.transform.Find("TutorialCamera").gameObject;//
        start = this.transform.Find("Start").gameObject;
        again = this.transform.Find("Again").gameObject;
        //<----------初期化----------->
        circle.SetActive(false);
        arrow.SetActive(false);
        explanation.SetActive(false);
        letter.SetActive(false);
        keyObject.SetActive(false);
        mouse.SetActive(false);
        space.SetActive(false);
        enemy.SetActive(false);
        start.SetActive(false);
        again.SetActive(false);
        //<--------------------------->
        g(progress);
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (progress < 13)
            {
                progress++;
                g(progress);
            }
            if (progress > 14)
            {
                progress++;
                g(progress);
            }
        }
    }
    public void g(int p)
    {
        switch (p)
        {
            case 0:
                gameTime++;
                TimeStop(gameTime);
                Message(p);
                break;
            case 1:
                Message(p);
                break;
            case 2:
                Message(p);
                break;
            case 3:
                Message(p);
                break;
            case 4:
                Message(p);
                break;
            case 5:
                Message(p);
                break;
            case 6:
                Message(p);
                break;
            case 7:
                Message(p);
                break;
            case 8:
                Message(p);
                break;
            case 9:
                gameTime++;
                TimeStop(gameTime);
                Message(p);
                break;
            case 10:
                Message(p);
                break;
            case 11:
                Message(p);
                break;
            case 12:
                Message(p);
                gameTime++;
                TimeStop(gameTime);
                enemy.SetActive(true);
                enemy.transform.position = GameObject.Find("Player").transform.position + new Vector3(-7f, 0f, 0f);
                break;
            case 13:
                gameTime++;
                TimeStop(gameTime);
                break;
            case 14:
                break;
            case 15:
                Message(p);
                break;
            case 16:
                tutoriaCamera.GetComponent<Camera>().depth=1;

                Message(p);
                break;
            case 17:
                tutoriaCamera.GetComponent<Camera>().depth = 0;
                Message(p);
                break;
        }
    }
    void TimeStop(int time)
    {
        int a = time % 2;
        if (a==0)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
    void Message(int message)
    {
        switch (message)
        {
            case 0:
                circle.SetActive(true);
                arrow.SetActive(true);
                explanation.SetActive(true);
                letter.SetActive(true);

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
                letterText.text = "HPバー:\n0の時ゲームオーバー。";
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
                letterText.text = "エネルギーバー:\n0の時スキルが使えなくなります。";
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
                letterText.text = "スコア:\n現在の点数。";
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
                letterText.text = "平面鏡:\n飛んで来た弾を撃ち返して敵を倒す。";
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
                letterText.text = "凸面鏡:\n飛んで来た弾を倍で撃ち返返して敵を倒す。";
                break;
            case 5:
                circle.transform.localPosition = new Vector3(18f, -190f, 0f);
                arrow.transform.localPosition = new Vector3(-72f, -178f, 0f);

                arrow.transform.localRotation = new Quaternion(0f, 0f, 1f, -2.3f);
                explanation.transform.localPosition = new Vector3(-184f, -111f, 0f);
                explanation.transform.localRotation = new Quaternion(0f, 0f, 1f, 0.93f);
                explanation.transform.localScale = new Vector3(3.5f, 1.8f, 1.2f);
                letter.transform.localPosition = new Vector3(-184f, -111f, 0f);
                letter.transform.localRotation = new Quaternion(0f, 0f, 1f, -1.08f);
                letter.GetComponent<RectTransform>().sizeDelta = new Vector2(308, 152);
                letterText.text = "凹面鏡:\n飛んで来た弾を吸収し、エネルギーを回復すると一定数を吸収したら強力な反撃ができる。";
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
                letterText.text = "スキル・バリア:\n敵の攻撃を防ぐことができる。";
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
                letterText.text = "スキル・回復:\nHPを回復する事ができる。";
                break;
            case 8:
                circle.transform.localPosition = new Vector3(-554.5f, 146.5f, 0f);
                arrow.transform.localPosition = new Vector3(-453f, 117f, 0f);
                arrow.transform.localRotation = new Quaternion(0f, 0f, 1f, 0.45f);

                explanation.transform.localPosition = new Vector3(-375f, 259f, 0f);
                explanation.transform.localRotation = new Quaternion(0f, 0f, 1f, 0.93f);
                explanation.transform.localScale = new Vector3(3.5f, 1.8f, 1.2f);
                letter.transform.localPosition = new Vector3(-372f, 261f, 0f);
                letter.transform.localRotation = new Quaternion(0f, 0f, 1f, -1.08f);
                letter.GetComponent<RectTransform>().sizeDelta = new Vector2(308f, 152f);
                letterText.text = "スキル・分身:\nもう一人の自分を呼び出せる事が出来て、その間に敵が分身を狙って攻撃する。";
                break;
            case 9:
                circle.SetActive(false);
                arrow.SetActive(false);

                keyObject.SetActive(true);
                explanation.transform.localPosition = new Vector3(-448f, 571f, 0f);
                explanation.transform.localRotation = new Quaternion(0f, 0f, 1f, 0.93f);
                explanation.transform.localScale = new Vector3(3.5f, 1.8f, 1.2f);
                letter.transform.localPosition = new Vector3(-445f, 573f, 0f);
                letter.transform.localRotation = new Quaternion(0f, 0f, 1f, -1.08f);
                letter.GetComponent<RectTransform>().sizeDelta = new Vector2(308f, 152f);
                letterText.text = "W,A,S,D(↑←↓→)で移動";
                break;
            case 10:
                keyObject.SetActive(false);

                mouse.SetActive(true);
                explanation.transform.localPosition = new Vector3(-448f, 571f, 0f);
                explanation.transform.localRotation = new Quaternion(0f, 0f, 1f, 0.93f);
                explanation.transform.localScale = new Vector3(3.5f, 3f, 1.2f);
                letter.transform.localPosition = new Vector3(-445f, 573f, 0f);
                letter.transform.localRotation = new Quaternion(0f, 0f, 1f, -1.08f);
                letter.GetComponent<RectTransform>().sizeDelta = new Vector2(308f, 262f);
                letterText.text = "カーソル:\nカーソルの位置はプレイヤーの向きになる。\nマウス右ボタン：\nマウス右ボタンはスキルを切り替える。\nマウス左ボタン：\nマウス左ボタン押すとスキルを発動。";
                break;
            case 11:
                mouse.SetActive(false);

                space.SetActive(true);
                explanation.transform.localPosition = new Vector3(-448f, 571f, 0f);
                explanation.transform.localRotation = new Quaternion(0f, 0f, 1f, 0.93f);
                explanation.transform.localScale = new Vector3(3.5f, 1.8f, 1.2f);
                letter.transform.localPosition = new Vector3(-521f, 567f, 0f);
                letter.transform.localRotation = new Quaternion(0f, 0f, 1f, -1.08f);
                letter.GetComponent<RectTransform>().sizeDelta = new Vector2(308f, 308f);
                letterText.text = "スペース：\nスペースを押せばミラーの種類を変える。";

                break;
            case 12:
                space.SetActive(false);
                explanation.transform.localPosition = new Vector3(-448f, 571f, 0f);
                explanation.transform.localRotation = new Quaternion(0f, 0f, 1f, 0.93f);
                explanation.transform.localScale = new Vector3(3.5f, 1.1f, 1.2f);
                letter.transform.localPosition = new Vector3(-449f, 572f, 0f);
                letter.transform.localRotation = new Quaternion(0f, 0f, 1f, -1.08f);
                letter.GetComponent<RectTransform>().sizeDelta = new Vector2(317f, 100f);
                letterText.text = "では敵を倒そう！！";
                break;
            case 13:
                break;
            case 15:
                explanation.transform.localPosition = new Vector3(-427f, 257f, 0f);
                explanation.transform.localRotation = new Quaternion(0f, 0f, 1f, 0.93f);
                explanation.transform.localScale = new Vector3(3.5f, 1.8f, 1.2f);
                letter.transform.localPosition = new Vector3(-429f, 254f, 0f);
                letter.transform.localRotation = new Quaternion(0f, 0f, 1f, -1.08f);
                letter.GetComponent<RectTransform>().sizeDelta = new Vector2(308f, 157f);
                letterText.text = "敵を倒したらアイテムミラーがランダムで落ちます。\n拾ったら壊れたミラーを回復できます。";
                break;
            case 16:
                explanation.transform.localPosition = new Vector3(-427f, 257f, 0f);
                explanation.transform.localRotation = new Quaternion(0f, 0f, 1f, 0.93f);
                explanation.transform.localScale = new Vector3(3.5f, 1.8f, 1.2f);
                letter.transform.localPosition = new Vector3(-429f, 254f, 0f);
                letter.transform.localRotation = new Quaternion(0f, 0f, 1f, -1.08f);
                letter.GetComponent<RectTransform>().sizeDelta = new Vector2(308f, 157f);
                letterText.text = "これは脱走装置です。\n目標として進めてください。";
                break;
            case 17:
                start.SetActive(true);
                again.SetActive(true);
                explanation.transform.localPosition = new Vector3(-268f, 269f, 0f);
                explanation.transform.localRotation = new Quaternion(0f, 0f, 1f, 0.93f);
                explanation.transform.localScale = new Vector3(3.5f, 2.4f, 1.2f);
                letter.transform.localPosition = new Vector3(-268f, 267f, 0f);
                letter.transform.localRotation = new Quaternion(0f, 0f, 1f, -1.08f);
                letter.GetComponent<RectTransform>().sizeDelta = new Vector2(308f, 212f);
                letterText.text = "チュートリアルは以上です。\nゲームゲームを始めましょうか";
                break;
        }
    }
    public void TutorialStartButton()
    { 
        SceneManager.LoadScene("GameScene");
    }
    public void TutorialAgainButton()
    {
        SceneManager.LoadScene("TutorialScene");
    }
}
    