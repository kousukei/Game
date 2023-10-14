using Cinemachine;
//using Cinemachine.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Canvas canvas;//カメラ
    public GameObject cmvcam;//バーチャルカメラ
    public GameObject gameOverPanel;//ゲームオーバーオブジェクト

    [System.NonSerialized] public bool isGameOver = false;
    [System.NonSerialized] public bool isDead = false;
    float maxFOVSpread = 50f;//視野の最大値
    float zoomOutSpeed = 3f;//カメラ視野移動スピード
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
            //時間を止める
            Time.timeScale = 0;
        }
    }

   public  void GameOverScene()
    {
        if (vcam.m_Lens.FieldOfView < maxFOVSpread)
        {
            //カメラ視野が時間によって広め
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
