using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Cinemachine;


public class GameClear : MonoBehaviour
{
    public Canvas canvas;
    public GameObject cmvcam;

    public GameObject gameClearPanel;

   [System.NonSerialized] public bool isGameClear = false;


    float maxFOVSpread = 50f;
    float zoomOutSpeed = 3f;
    float scaleChangeSpeed = 0.15f;
    CinemachineVirtualCamera vcam;
    CanvasScaler scaler;

    Ranking ranking;
    Animator animator;
    Score_Script score;
    void Start()
    {
        //ranking = GameObject.Find("Ranking").GetComponent<Ranking>();
        //animator = GameObject.Find("Ranking").GetComponent<Animator>();
        score = GameObject.Find("ScriptObject").GetComponent<Score_Script>();
        vcam = cmvcam.GetComponent<CinemachineVirtualCamera>();
        scaler = canvas.GetComponent<CanvasScaler>();

    }

    // Update is called once per frame
    void Update()
    {
        Clear();
    }
    private void OnTriggerStay(Collider other)
    {
        //SceneManager.LoadScene("StartScene");
        //ranking.Get();
        //ranking.Set(score.Score);
        //animator.SetBool("start", true);
        isGameClear = true;
    }

    void Clear ()
    {
        if (isGameClear )
        {
            if (vcam.m_Lens.FieldOfView < maxFOVSpread)
            {
                scaler.referenceResolution += new Vector2(scaleChangeSpeed, 0);
                vcam.m_Lens.FieldOfView += Time.deltaTime * zoomOutSpeed;
            }
            else
            {
                Time.timeScale = 0;
                gameClearPanel.SetActive(true);
            }
        }

    }
}