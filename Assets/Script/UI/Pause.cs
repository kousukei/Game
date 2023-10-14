using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Pause : MonoBehaviour
{
	[SerializeField]GameObject pauseUI;//��~�I�u�W�F�N�g

    void Start()
    {
		pauseUI.SetActive(false);
    }

    void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			//�L�[�����������ꎞ��~
			pauseUI.SetActive(!pauseUI.activeSelf);

			if (pauseUI.activeSelf)
			{
				Time.timeScale = 0f;//�Q�[�����Ԓ�~
			}
			else
			{
				Time.timeScale = 1f;//�Q�[�����ԊJ�n
			}
		}
	}
	
	/// <summary>
	/// �Q�[�����ԊJ�n�{�^���̏���
	/// </summary>
	public void RestartButton()
    {
		pauseUI.SetActive(!pauseUI.activeSelf);
        Time.timeScale = 1f;
	}
}
