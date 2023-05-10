using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class EffectControl : MonoBehaviour
{

    [SerializeField, Header("�_���[�W�G�t�F�N�g")]
    private GameObject damageEffect;
    [SerializeField, Header("�j��G�t�F�N�g")]
    private GameObject deathEffect;
    [SerializeField, Header("�񕜃G�t�F�N�g")]
    private GameObject healEffect;
    public bool deatEffectFlag;

    int num;
    List<EffectObject> effects = new List<EffectObject>();
    
    EffectObject[] objects;

    private void Start()
    {
        deatEffectFlag = false;
    }

    void Update()
    {
    
    }
    //�v���C���[�̃X�L���̃G�t�F�N�g
    public void PlayerEffect(Transform subject,string effectName)
    {
        StartCoroutine(EffectStart(subject,effectName));
    }
    //Enemy�̃G�t�F�N�g
    public void effectMaker(GameObject gameObject,string name)
    {
        //Enemy�̃G�t�F�N�g�̎��
        //�_���[�W
        if (name== "Damage")
        {
            //Enemy�̂̃_���[�W�̃G�t�F�N�g���擾
            GameObject damageObject = gameObject.transform.Find("DamageEffect").gameObject;
            //�Z�b�g�A�N�e�B�u(true)
            damageObject.SetActive(true);
            ////���Ԑ؂�����Z�b�g�A�N�e�B�u(false)
            StartCoroutine(EffectStop(damageObject, gameObject));
        }
        //���S
        if(name== "Death")
        {

            GameObject deathObject = gameObject.transform.Find("DeathEffect").gameObject;
            //�Z�b�g�A�N�e�B�u(true)
            deathObject.SetActive(true);
            ////���Ԑ؂�����Z�b�g�A�N�e�B�u(false)
            StartCoroutine(EffectStop(deathObject,gameObject));

        }
        
    }
    //�G�t�F�N�g���Z�b�g�A�N�e�B�u(false);
    IEnumerator EffectStop(GameObject effect,GameObject gameObject)
    {
        if(effect.name== "DeathEffect")
        {
            //�O�D�T�b��҂�
            yield return new WaitForSeconds(0.5f);
            effect.SetActive(false);
            gameObject.SetActive(false);
            //��񂾂����������Bool
            deatEffectFlag = true;
        }
        else
        {
            //1�b��҂�
            yield return new WaitForSeconds(1f);
            effect.SetActive(false);
        }

    }
    //�v���C���[�̃X�L���̃G�t�F�N�g���Ǘ�����
    IEnumerator EffectStart(Transform effectpos,string name)
    {
        //�v���C���[�̃|�W�V������ۑ�����
        Vector3 pos = effectpos.position;
        //�ۑ������G�t�F�N�g�͂��邪�ǂ���
        if (effects.Count > 0)
        {
            //������
            objects = new EffectObject[effects.Count];
            //���O�ɂ���Ă̏���
            switch (name)
            {
                //��
                case "Heal":
                    //�G�t�F�N�g�����o��
                    for (int o = 0; o < effects.Count; o++)
                    {
                        //list�̒��̃G�t�F�N�g��Object�ɓ����
                        objects[o] = effects[o];
                        //����HealEffect�������
                        if (objects[o].type == "HealEffect")
                        {
                            //�ŏ���Healeffect���擾������
                            num++;
                            if (num > 0)
                            {
                                //HealEffect���o��
                                objects[o].gameObject.EffectReatart();
                                //List��HealEffect���폜
                                effects.RemoveAt(o);
                                //���[�v���甲���܂�
                                break;
                            }
                        }
                        //List�̒���HealEffect���Ȃ��Ȃ�
                        if (num == 0)
                        {
                            //HealEffect�𐶐����܂�
                            Production(name, pos);
                        }
                    }
                    num = 0;
                        break;
            }
        }
        else
        {
            //List�̒��ɂ�Effect���Ȃ�������
            //���O�ɂ���ė~����Effect�𐶐����܂�
            Production(name, pos);
        }
        yield return null;
    }
    //Effect�𐶐�����֐�
    void Production(string name,Vector3 pos)
    {
        //���O�ɂ���Đ�������Effect���ς��܂�
        switch (name)
        {
            case "Heal":
                Instantiate(healEffect, pos, Quaternion.identity);
                break;

        }
    }
    //Effect��List�ɕۑ�
    public void EffectKeep(EffectObject effectObject)
    {
        effects.Add(effectObject);
    }

}
//List�ɕۑ�����Effect�̌`
public class EffectObject{

    public string type;
    public effect gameObject;
}