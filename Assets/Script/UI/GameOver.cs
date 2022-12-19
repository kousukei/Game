using Cinemachine;
using Cinemachine.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Canvas canvas;
    public GameObject cmvcam;
    public GameObject gameOverPanel;

    [System.NonSerialized] public bool isGameOver = false;
    [System.NonSerialized] public bool isDead = false;
    float maxFOVSpread = 50f;
    float zoomOutSpeed = 3f;
    float scaleChangeSpeed = 0.15f;
    CinemachineVirtualCamera vcam;
    CanvasScaler scaler;

    void Start()
    {
        vcam = cmvcam.GetComponent<CinemachineVirtualCamera>();
        scaler = canvas.GetComponent<CanvasScaler>();
    }

    void FixedUpdate()
    {
        if (isGameOver)
        {
            Time.timeScale = 0;
        }
    }

   public  void GameOverScene()
    {
        if (vcam.m_Lens.FieldOfView < maxFOVSpread)
        {
            scaler.referenceResolution += new Vector2(scaleChangeSpeed, 0);
            vcam.m_Lens.FieldOfView += Time.deltaTime * zoomOutSpeed ;
            isDead = true;
        }
        else
        {
            gameOverPanel.SetActive(true);
            isGameOver = true;
        }
    }
}
