using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Image image;
    Animator rankingAnimetor;
    public GameObject gameClear;
    private void Start()
    {
        image = this.gameObject.GetComponent<Image>();
        rankingAnimetor = GameObject.Find("Ranking").GetComponent<Animator>();
    }

    public void RetryButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time. timeScale = 1f;
    }

    public void ExitButton()
    {
        SceneManager.LoadScene("StartScene");
        Time.timeScale = 1f;
    }
    public void end()
    {
        Application.Quit();
    }
    public void start()
    {
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1f;
        Debug.Log(Time.timeScale);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        image.color = new Color(0f, 255f, 255f, 255f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.color = new Color(255f, 255f, 255f, 255f);
    }
    public void RankingButtonDown()
    {
        rankingAnimetor.SetBool("end", true);
        gameClear.SetActive(true);
    }
}
