using Microsoft.Win32.SafeHandles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControl : MonoBehaviour
{
    [SerializeField, Header("�񕜉�")]
    private AudioClip healSound;
    [SerializeField, Header("�o���A��")]
    private AudioClip baeeierSound;
    [SerializeField, Header("���g��")]
    private AudioClip decoySound;
    [SerializeField, Header("�X�L�����R���g���[��")]
    private AudioSource skillSoundControl;
    [SerializeField, Header("�~���[���ꂽ��")]
    private AudioClip mirrorSound;
    [SerializeField, Header("�v���C���[�̉��̃R���g���[��")]
    private AudioSource playerAudioControl;
    [SerializeField, Header("�X�e�[�W��")]
    private AudioClip stageSuond;
    [SerializeField, Header("�X�e�[�W���̃R���g���[��")]
    private AudioSource[] stageSoundControl;

    string skill;
    string stage;
    //�X�L���̃T�E���h�̊֐�
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
    //�v���C���[�̃T�E���h�̊֐�
    public void PlayerSound()
    {
        playerAudioControl.PlayOneShot(mirrorSound);
    }
    //�X�e�[�W�̃T�E���h�̊֐�
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
