using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Pause : MonoBehaviour
{
	[SerializeField]GameObject pauseUI;//停止オブジェクト

    void Start()
    {
		pauseUI.SetActive(false);
    }

    void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			//キーを押した時一時停止
			pauseUI.SetActive(!pauseUI.activeSelf);

			if (pauseUI.activeSelf)
			{
				Time.timeScale = 0f;//ゲーム時間停止
			}
			else
			{
				Time.timeScale = 1f;//ゲーム時間開始
			}
		}
	}
	
	/// <summary>
	/// ゲーム時間開始ボタンの処理
	/// </summary>
	public void RestartButton()
    {
		pauseUI.SetActive(!pauseUI.activeSelf);
        Time.timeScale = 1f;
	}
}
