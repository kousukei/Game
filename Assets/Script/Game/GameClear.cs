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
    Animator rankingAnimetor;
    Score_Script score;
    void Start()
    {
        ranking = GameObject.Find("Ranking").GetComponent<Ranking>();
        rankingAnimetor = GameObject.Find("Ranking").GetComponent<Animator>();
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

        
        isGameClear = true;
    }

    void Clear ()
    {
        
        if (isGameClear )
        {
            Time.timeScale = 0;
            if (vcam.m_Lens.FieldOfView < maxFOVSpread)
            {
                scaler.referenceResolution += new Vector2(scaleChangeSpeed, 0);
                vcam.m_Lens.FieldOfView += Time.unscaledDeltaTime * zoomOutSpeed;
            }
            else
            {
                Time.timeScale = 0;
                rankingAnimetor.SetBool("start", true);
                //gameClearPanel.SetActive(true);
            }
        }

    }
}
