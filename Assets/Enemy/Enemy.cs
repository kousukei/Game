using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Enemy : MonoBehaviour
{
    Vector3 Position;
    GameObject range;
    float shootingTimeCount;
    Material ma;
    float speed;
    Enemy_1 enemy_1;
    IEnumerator st()
    {
        Position = random();
        enemy_1 = this.gameObject.GetComponent<Enemy_1>();
        yield return null;
    }

    private void OnTriggerEnter(Collider other)
    {
        range = other.gameObject;
        StartCoroutine(st());
    }
    /// <summary>
    /// �v���C���[�Ɍ������Ĉړ�
    /// </summary>
    /// <param name="Player"></param>
    /// <param name="Enemy"></param>
    public void Player_move(GameObject Player, GameObject Enemy)
    {
        Enemy.transform.position = Vector3.MoveTowards(Enemy.transform.position, Player.transform.position, speed * Time.deltaTime);
    }
    ///
    /// <summary>
    /// �����_���ړ�
    /// </summary>
    /// <param name="Enemy"></param>
    /// <param name="speed"></param>
    public void random_move(GameObject Enemy, float speed)
    {
        if ((Enemy.transform.position.x-Position.x)<=1&&(Enemy.transform.position.z-Position.z)<=1)
        {
            Position = random();
        }
        else if (enemy_1.hit)
        {
            Position = random();
            enemy_1.hit = false;
        }
        this.speed = speed;
        Enemy.transform.position = Vector3.MoveTowards(Enemy.transform.position, Position, speed * Time.deltaTime);
    }
    /// <summary>
    /// �����_���Ɉړ��_�̐���
    /// </summary>
    /// <returns></returns>
    Vector3 random()
    {

        Vector3 randomPosition = new Vector3(Random.Range(range.transform.position.x + (range.transform.localScale.x/2), range.transform.position.x - (range.transform.localScale.x / 2)), range.transform.position.y - (range.transform.localScale.y/2), Random.Range(range.transform.position.z + (range.transform.localScale.z/2), range.transform.position.z - (range.transform.localScale.z / 2)));
        return randomPosition;
    }
    /// <summary>
    /// //����
    /// </summary>
    /// <param name="Enemy"></param>
    public void Direction(GameObject Enemy)
    {
        Vector3 vector3 = Position - Enemy.transform.position;
        Quaternion quaternion = Quaternion.LookRotation(vector3);
        Enemy.transform.rotation = Quaternion.Slerp(Enemy.transform.rotation, quaternion, 0.1f);

    }
    /// <summary>
    /// �p�x�̔���
    /// </summary>
    /// <param name="Player"></param>
    /// <param name="Enemy"></param>
    /// <returns></returns>
    public bool Attack_range(GameObject Player, GameObject Enemy)
    {
        var v0 = Player.transform.position - Enemy.transform.position;
        var v1 = Enemy.transform.forward;
        var dot = Vector3.Dot(v0.normalized, v1.normalized);
        var th = Mathf.Acos(dot) * Mathf.Rad2Deg;
        if (th < 45)//45�x�ȏ�Ȃ�΍U���J�n
        {
            //����(�ڕW)
            Vector3 vector3 = Player.transform.position - Enemy.transform.position;
            Quaternion quaternion = Quaternion.LookRotation(vector3);
            Enemy.transform.rotation = Quaternion.Slerp(Enemy.transform.rotation, quaternion, 0.01f);
            return true;
        }
        return false;
    }
    /// <summary>
    /// �����̔���
    /// </summary>
    /// <param name="Player"></param>
    /// <param name="Enemy"></param>
    /// <param name="withinRange"></param>
    /// <param name="OutOfRange"></param>
    /// <returns></returns>
    public int tracking_range(GameObject Player, GameObject Enemy, float withinRange, float OutOfRange)
    {
        float dist_z = Player.transform.position.z - Enemy.transform.position.z;
        float dist_x = Player.transform.position.x - Enemy.transform.position.x;
        float distance = Mathf.Sqrt(dist_z * dist_z + dist_x * dist_x);//�v���C���[�ƓG�̋���
        if (distance < withinRange)//���̋����ȉ��Ȃ�1��\��
        {
            return 1;
        }
        //���̋����Ȃ�Q��\��
        if (distance < OutOfRange && distance > withinRange)
        {
            //����(�ڕW)
            Vector3 vector3 = Player.transform.position - Enemy.transform.position;
            Quaternion quaternion = Quaternion.LookRotation(vector3);
            Enemy.transform.rotation = Quaternion.Slerp(Enemy.transform.rotation, quaternion, 0.01f);
            return 2;
        }
        return 0;//���̋����ȏ�Ȃ�0��\��

    }

    public void Attack(Transform transform, GameObject laser, float shootingTime, float laser_speed)
    {
        shootingTimeCount += Time.deltaTime;
        if (shootingTime < shootingTimeCount)
        {
            var gameObject = Instantiate(laser, transform.position, transform.rotation);
            gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * laser_speed, ForceMode.Impulse);
            shootingTimeCount = 0;
        }
    }
}



