using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    public GameOver gameOver;//ゲームオブジェクト
    public Slider hpSlider;//HPバー
    bool once = false;

    [SerializeField, Header("エフェクト")]
    private GameObject effect;
    [SerializeField, Header("プレイヤー")]
    private GameObject player;

    [System .NonSerialized]public int maxHp = 100;//最大HP
    [System.NonSerialized]public int currentHp;//現在HP

    int damage = 5;//ダメージ
    int heal= 20;//回復

    void Start()
    {
        hpSlider.value = 1;//Sliderのvalueを初期化
        currentHp = maxHp;//現在HPの初期化
    }
    void Update()
    {
        if (hpSlider.value <= 0)//HPが0の時
        {
            if (!once)//プレイヤーとエフェクトの一回処理
            {
                player.SetActive(false);//プレイヤーを消す
                Instantiate(effect, player.transform.position, Quaternion.identity);//エフェクトの生成
                once = true;
            }
            gameOver.GameOverScene();//ゲームオーバー処理
        }
    }

    public void Damage()
    {
        //ダメージ処理
        currentHp = currentHp - damage;
        hpSlider.value = (float)currentHp / (float)maxHp;
    }

    public void Heal()
    {
        //回復処理
        currentHp = currentHp + heal;

        if (currentHp > maxHp)
        {
            currentHp = maxHp;
        }
        hpSlider.value = (float)currentHp / (float)maxHp; ;
    }
}