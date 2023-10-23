using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Image image;//�{�^����UI�}
    Animator rankingAnimetor;//�����L���O�̃A�j���V����
    public GameObject gameClear;//�Q�[���N���A�I�u�W�F�N�g
    public AudioClip audio;//�{�^���I����
    AudioSource source;
    private void Start()
    {
        image = this.gameObject.GetComponent<Image>();
        if (SceneManager.GetActiveScene().name == "GameScene")
        {
            rankingAnimetor = GameObject.Find("Ranking").GetComponent<Animator>();
        }
        source = this.GetComponent<AudioSource>();
    }
    //�Q�[��
    public void RetryButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time. timeScale = 1f;
    }
    
    public void ExitButton()
    {
        SceneManager.LoadScene("StartScene");//�X�^�[�g�V�[���ֈړ�
        Time.timeScale = 1f;
    }
    public void end()
    {
        Application.Quit();//�Q�[�������
    }
    public void start()
    {
        SceneManager.LoadScene("TutorialScene");//�`���[�g���A���ֈړ�
        Time.timeScale = 1f;;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        //�J�[�\�����{�^���̏�̏���
        image.color = new Color(0f, 255f, 255f, 255f);
        source.PlayOneShot(audio, 0.5f);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        //�J�[�\�����{�^���𗣂ꂽ����
        image.color = new Color(255f, 255f, 255f, 255f);
    }
    public void RankingButtonDown()
    {
        //�����N�{�^���̏���
        rankingAnimetor.SetBool("end", true);
        gameClear.SetActive(true);
    }
}
