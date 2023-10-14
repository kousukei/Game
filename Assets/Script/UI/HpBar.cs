using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    public GameOver gameOver;//�Q�[���I�u�W�F�N�g
    public Slider hpSlider;//HP�o�[
    bool once = false;

    [SerializeField, Header("�G�t�F�N�g")]
    private GameObject effect;
    [SerializeField, Header("�v���C���[")]
    private GameObject player;

    [System .NonSerialized]public int maxHp = 100;//�ő�HP
    [System.NonSerialized]public int currentHp;//����HP

    int damage = 5;//�_���[�W
    int heal= 20;//��

    void Start()
    {
        hpSlider.value = 1;//Slider��value��������
        currentHp = maxHp;//����HP�̏�����
    }
    void Update()
    {
        if (hpSlider.value <= 0)//HP��0�̎�
        {
            if (!once)//�v���C���[�ƃG�t�F�N�g�̈�񏈗�
            {
                player.SetActive(false);//�v���C���[������
                Instantiate(effect, player.transform.position, Quaternion.identity);//�G�t�F�N�g�̐���
                once = true;
            }
            gameOver.GameOverScene();//�Q�[���I�[�o�[����
        }
    }

    public void Damage()
    {
        //�_���[�W����
        currentHp = currentHp - damage;
        hpSlider.value = (float)currentHp / (float)maxHp;
    }

    public void Heal()
    {
        //�񕜏���
        currentHp = currentHp + heal;

        if (currentHp > maxHp)
        {
            currentHp = maxHp;
        }
        hpSlider.value = (float)currentHp / (float)maxHp; ;
    }
}