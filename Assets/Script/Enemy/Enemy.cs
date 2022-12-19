using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace enemy
{
    public class Enemy : MonoBehaviour
    {
        Vector3 randomPosition;
        Vector3 u;
        Vector3 difference;
        bool y;
        public float a=20;
        Material ma;
        GameObject player;
        void Start()
        {
            randomPosition = transform.position;
            player = GameObject.Find("Player");
        }

        // Update is called once per frame
        void Update()
        {

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
            Debug.Log(distance);
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

    }
}

