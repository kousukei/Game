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
    public GameObject panel;
    public bool isGameOver = false;
    CinemachineVirtualCamera vcam;
    CanvasScaler scaler;
    // Start is called before the first frame update
    void Start()
    {
        vcam = cmvcam.GetComponent<CinemachineVirtualCamera>();
        scaler = canvas.GetComponent<CanvasScaler>();
    }

    // Update is called once per frame
    void Update()
    {
        GameOverScene();
    }
    void GameOverScene()
    {
        if (vcam.m_Lens.FieldOfView < 50)
        {
            scaler.referenceResolution -= new Vector2(-0.15f, 0);
            vcam.m_Lens.FieldOfView += Time.deltaTime * 3;
            isGameOver = true;
        }
        else
        {
            panel.SetActive(true);
        }
    }
}
