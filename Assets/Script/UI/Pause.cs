using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Pause : MonoBehaviour
{
	[SerializeField]GameObject pauseUI;

    void Start()
    {
		pauseUI.SetActive(false);
    }

    void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			pauseUI.SetActive(!pauseUI.activeSelf);

			if (pauseUI.activeSelf)
			{
				Time.timeScale = 0f;
			}
			else
			{
				Time.timeScale = 1f;
			}
		}
	}
	
	/// <summary>
	/// Restart‚ð‰Ÿ‚·
	/// </summary>
	public void RestartButton()
    {
        pauseUI.SetActive(!pauseUI.activeSelf);
        Time.timeScale = 1f;
	}
}
