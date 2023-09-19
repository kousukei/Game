using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcaveMirror : MonoBehaviour
{
    public ReflectCount reflectCount;

    private void OnCollisionEnter(Collision collision)
    {
        if (reflectCount.countConcaveMirror % 3 == 0 && collision.gameObject.tag == "Laser")
        {
            collision.gameObject.GetComponent<Rigidbody>().velocity=collision.gameObject.GetComponent<Laser>().refrectVec * 2f;
            collision.gameObject.GetComponent<Laser>().onConcaveMirror = true;
        }
        else if (reflectCount.countConcaveMirror % 3 != 0 && collision.gameObject.tag == "Laser")
        {
            Destroy(collision.gameObject);
        }
    }
}
