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
}
