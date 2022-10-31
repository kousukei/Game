using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Vector3 randomPosition;
    Vector3 u;
    bool y;
    public float a;
    void Start()
    {
        randomPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (randomPosition == transform.position)
        {
            u = random();
        }
        this.transform.position = Vector3.MoveTowards(transform.position, u, a * Time.deltaTime);
    }

    Vector3 random()
    {

            randomPosition = new Vector3(Random.Range(1f, 10f), 1, Random.Range(1f, 10f));
            return randomPosition;
    }

}
