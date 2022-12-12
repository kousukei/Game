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
        GameObject player;
        void Start()
        {
            //randomPosition = transform.position;
            player = GameObject.Find("Player");
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void move(Transform en,float speed)
        {
            if (randomPosition == en.position)
            {
                u = random();
            }
            en.position = Vector3.MoveTowards(en.position, u, speed * Time.deltaTime);
        }
        Vector3 random()
        {

            randomPosition = new Vector3(Random.Range(1f, 10f), 0.5f, Random.Range(1f, 10f));
            return randomPosition;
        }
        public Vector3 Judgement(Transform player,Transform enemy)
        {
            difference = player.position - enemy.position;
            return difference;
        }
        public void Direction(GameObject player,GameObject enemy,float speed)
        {

            Vector3 vector3 = u - enemy.transform.position;
            Quaternion quaternion = Quaternion.LookRotation(vector3);
            enemy.transform.rotation = Quaternion.Slerp(enemy.transform.rotation, quaternion, speed);
            //if (/*ÉvÉåÉCÉÑÅ[Ç∆âÔÇ¡ÇΩÇÁ*/)
            //{
            //Vector3 vector3 = player.transform.position - enemy.transform.position;
            //Quaternion quaternion = Quaternion.LookRotation(vector3);
            //enemy.transform.rotation = Quaternion.Slerp(enemy.transform.rotation, quaternion, speed);
            //}
        }

    }
}

