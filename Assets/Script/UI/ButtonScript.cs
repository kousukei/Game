using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public void RetryButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time. timeScale = 1f;
    }

    public void ExitButton()
    {
        //SceneManager.LoadScene("タイトルシーン");
        //Time.timeScale = 1f;
    }
    public void end()
    {
        SceneManager.LoadScene("StartScene");
    }
}
