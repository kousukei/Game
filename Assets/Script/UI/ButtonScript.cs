using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Image image;
    private void Start()
    {
        image = this.gameObject.GetComponent<Image>();
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
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        image.color = new Color(0f, 255f, 255f, 255f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.color = new Color(255f, 255f, 255f, 255f);
    }
}
