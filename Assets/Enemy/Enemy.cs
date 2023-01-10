using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace enemy
{
    public class Enemy : MonoBehaviour
    {
        Vector3 randomPosition;
        Vector3 u;
        Vector3 sss;
        bool y;
        public float a=20;
        float shootingTimeCount;
        Material ma;
        GameObject player;
        GameObject enemy;
        void Start()
        {
            randomPosition = transform.position;
            player = GameObject.Find("Player");
        }

        public void move(GameObject Enemy, float speed)
        {
            if (randomPosition == Enemy.transform.position)
            {
                u = random();
            }
            Enemy.transform.position = Vector3.MoveTowards(Enemy.transform.position, u, speed * Time.deltaTime);
        }
        Vector3 random()
        {

            randomPosition = new Vector3(Random.Range(1f, 10f), 0.5f, Random.Range(1f, 10f));
            return randomPosition;
        }
        public void Direction(GameObject Player,GameObject Enemy,float speed)
        {
            if (Attack_range(Player,Enemy))
            {
                Vector3 vector3 = Player.transform.position - Enemy.transform.position;
                Quaternion quaternion = Quaternion.LookRotation(vector3);
                Enemy.transform.rotation = Quaternion.Slerp(Enemy.transform.rotation, quaternion, speed);
            }
            else
            {
                Vector3 vector3 = u - Enemy.transform.position;
                Quaternion quaternion = Quaternion.LookRotation(vector3);
                Enemy.transform.rotation = Quaternion.Slerp(Enemy.transform.rotation, quaternion, speed);
            }
        }
        public bool Attack_range(GameObject Player,GameObject Enemy)
        {
            var v0 = Player.transform.position - Enemy.transform.position;
            var v1 = Enemy.transform.forward;
            var dot = Vector3.Dot(v0.normalized, v1.normalized);
            var th = Mathf.Acos(dot) * Mathf.Rad2Deg;
            Material ma;
            ma = Player.GetComponent<Renderer>().material;
            float dist_z = Player.transform.position.z - Enemy.transform.position.z;
            float dist_x = Player.transform.position.x - Enemy.transform.position.x;
            float distance = Mathf.Sqrt(dist_z * dist_z + dist_x * dist_x);
            if (distance < 10)
            {
                if (th < 20)
                {
                    ma.color = Color.red;
                    return true;
                }
                else
                {
                    ma.color = Color.white;
                }
            }

            return false;
        }
        public void Attack(Transform transform,GameObject laser,float shootingTime,float laser_speed)
        {
            shootingTimeCount += Time.deltaTime;
            if (shootingTime < shootingTimeCount)
            {
                var gameObject = Instantiate(laser, transform.position, transform.rotation);
                gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward* laser_speed, ForceMode.Impulse);
                shootingTimeCount = 0;
            }
        }

    }
}

