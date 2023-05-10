using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    List<Laser> laserss = new List<Laser>();
    [SerializeField]
    GameObject laserPrefab;
    public void Attack(Transform transform,  float laser_speed)
    {
        StartCoroutine(LaserMaker(transform, laser_speed));
        
    }
    IEnumerator LaserMaker(Transform transform, float laserSpeed)
    {
        //敵のpositionを取得
        Vector3 pos = transform.position;
        ////保存したレザーがあったら

        if (laserss.Count > 0)
        {
            //保存したレザーを取得
            Laser laser = laserss[0];
            //レザーの０番を削除
            laserss.RemoveAt(0);
            //レザーを出す
            laser.Reatart(transform, laserSpeed);
        }
        //保存レザーがなかったら
        else
        {
            //レザーを生成します。
            var gameObject = Instantiate(laserPrefab, pos, Quaternion.identity);
            //レザーの移動
            gameObject.GetComponent<Rigidbody>().velocity = transform.forward * laserSpeed;
        }

        yield return null;

    }
    public void EraseLaser(Laser laser)
    {
        //生成したレザーを保存
        laserss.Add(laser);

    }
}
