using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Image image;//ボタンのUI図
    Animator rankingAnimetor;//ランキングのアニメション
    public GameObject gameClear;//ゲームクリアオブジェクト
    public AudioClip audio;//ボタン選択音
    AudioSource source;
    private void Start()
    {
        image = this.gameObject.GetComponent<Image>();
        if (SceneManager.GetActiveScene().name == "GameScene")
        {
            rankingAnimetor = GameObject.Find("Ranking").GetComponent<Animator>();
        }
        source = this.GetComponent<AudioSource>();
    }
    //ゲーム
    public void RetryButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time. timeScale = 1f;
    }
    
    public void ExitButton()
    {
        SceneManager.LoadScene("StartScene");//スタートシーンへ移動
        Time.timeScale = 1f;
    }
    public void end()
    {
        Application.Quit();//ゲームを閉じる
    }
    public void start()
    {
        SceneManager.LoadScene("TutorialScene");//チュートリアルへ移動
        Time.timeScale = 1f;;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        //カーソルがボタンの上の処理
        image.color = new Color(0f, 255f, 255f, 255f);
        source.PlayOneShot(audio, 0.5f);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        //カーソルがボタンを離れた処理
        image.color = new Color(255f, 255f, 255f, 255f);
    }
    public void RankingButtonDown()
    {
        //ランクボタンの処理
        rankingAnimetor.SetBool("end", true);
        gameClear.SetActive(true);
    }
}
