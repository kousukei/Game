using Microsoft.Win32.SafeHandles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControl : MonoBehaviour
{
    [SerializeField, Header("回復音")]
    private AudioClip healSound;
    [SerializeField, Header("バリア音")]
    private AudioClip baeeierSound;
    [SerializeField, Header("分身音")]
    private AudioClip decoySound;
    [SerializeField, Header("スキル音コントロール")]
    private AudioSource skillSoundControl;
    [SerializeField, Header("ミラー割れた音")]
    private AudioClip mirrorSound;
    [SerializeField, Header("プレイヤーの音のコントロール")]
    private AudioSource playerAudioControl;
    [SerializeField, Header("ステージ音")]
    private AudioClip stageSuond;
    [SerializeField, Header("ステージ音のコントロール")]
    private AudioSource[] stageSoundControl;

    string skill;
    string stage;
    //スキルのサウンドの関数
    public void SkillSound(SkillScript.SkillName skillName)
    {
        skill = skillName.ToString();
        switch (skill)
        {
            case"heal":
                skillSoundControl.PlayOneShot(healSound);
                break;
            case "barrier":
                skillSoundControl.PlayOneShot(baeeierSound);
                break;
            case "decoy":
                skillSoundControl.PlayOneShot(decoySound);
                break;
        }
    }
    //プレイヤーのサウンドの関数
    public void PlayerSound()
    {
        playerAudioControl.PlayOneShot(mirrorSound);
    }
    //ステージのサウンドの関数
    public void StageSound(Enemy_start.Stage stage)
    {
        this.stage = stage.ToString();
        switch (this.stage)
        {
            case "stage_1":
                stageSoundControl[0].PlayOneShot(stageSuond);
                break;
            case "stage_2":
                stageSoundControl[1].PlayOneShot(stageSuond);
                break;
            case "stage_3":
                stageSoundControl[2].PlayOneShot(stageSuond);
                break;
        }
    }


}
