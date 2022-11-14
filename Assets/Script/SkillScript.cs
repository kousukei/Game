using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillScript : MonoBehaviour
{
    [SerializeField, Header("表示させるImage")]
    private Image[] image;
    [SerializeField, Header("表示させる画像")]
    private Sprite[] sprite;
    public Barrier barrierScript;

    SkillName skill;
    enum SkillName
    {
        heal,
        barrier,
        decoy
    }

    void Start()
    {
        skill = SkillName.heal;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (skill == SkillName.heal)
            {
                Debug.Log("回復した！");
            }
            else if (skill == SkillName.barrier)
            {
                Debug.Log("バリアを張った！");
                barrierScript.BarrierSkill();
            }
            else if(skill == SkillName.decoy)
            {
                Debug.Log("デコイを出した！");
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (skill == SkillName.heal)
            {
                skill = SkillName.barrier;
                image[0].sprite = sprite[1];
                image[1].sprite = sprite[2];
                image[2].sprite = sprite[0];
            }
            else if (skill == SkillName.barrier)
            {
                skill = SkillName.decoy;
                image[0].sprite = sprite[2];
                image[1].sprite = sprite[0];
                image[2].sprite = sprite[1];
            }
            else if (skill == SkillName.decoy)
            {
                skill = SkillName.heal;
                image[0].sprite = sprite[0];
                image[1].sprite = sprite[1];
                image[2].sprite = sprite[2];
            }
        }
    }
}
