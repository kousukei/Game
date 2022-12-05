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
            randomPosition = transform.position;
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

            randomPosition = new Vector3(Random.Range(1f, 10f), 1, Random.Range(1f, 10f));
            return randomPosition;
        }
        public Vector3 Judgement(Transform player,Transform enemy)
        {
            difference = player.position - enemy.position;
            return difference;
        }

    }
}

