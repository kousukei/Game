using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    List<Laser> laserss = new List<Laser>();
    [SerializeField]
    GameObject laserPrefab;
    int lllll = 0;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    public void Attack(Transform transform,  float laser_speed)
    {
        StartCoroutine(LaserMaker(transform, laser_speed));
        
    }
    IEnumerator LaserMaker(Transform transform, float laserSpeed)
    {
        //�G��position���擾
        Vector3 pos = transform.position;
        ////�ۑ��������U�[����������

        ////���U�[�𐶐����܂��B
        //var gameObject = Instantiate(laserPrefab, pos, Quaternion.identity);
        ////���U�[�̈ړ�
        //gameObject.GetComponent<Rigidbody>().AddForce(test, ForceMode.Impulse);


        if (laserss.Count > 0)
        {
            //�ۑ��������U�[���擾
            Laser laser = laserss[0];
            //���U�[�̂O�Ԃ��폜
            laserss.RemoveAt(0);
            //���U�[���o��
            laser.Reatart(transform, laserSpeed);
            
            
           
        }
        //�ۑ����U�[���Ȃ�������
        else
        {
            //���U�[�𐶐����܂��B
            var gameObject = Instantiate(laserPrefab, pos, Quaternion.identity);
            //���U�[�̈ړ�
            gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * laserSpeed, ForceMode.Impulse);

        }

        yield return null;

    }
    public void EraseLaser(Laser laser)
    {
        //�����������U�[��ۑ�
        laserss.Add(laser);

    }
}
