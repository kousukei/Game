using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    Plane plane = new Plane();
    Vector3 vec3;
    Rigidbody rb;

    float distance; //ray‚©‚ç‚Ì‹——£
    float horizontalKey, verticalKey;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalKey = Input.GetAxis("Horizontal");
        verticalKey = Input.GetAxis("Vertical");

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        plane.SetNormalAndPosition(Vector3.up, transform.localPosition);
        if (plane.Raycast(ray, out distance))
        {
            var lookPoint = ray.GetPoint(distance);
            transform.LookAt(lookPoint);
        }
    }

    private void FixedUpdate()
    {
        vec3 = new Vector3(horizontalKey, 0, verticalKey);

        if (rb.velocity.magnitude > 1)
        {
            rb.velocity = vec3.normalized * speed;
        }
        else
        {
            rb.velocity = vec3 * speed ;
        }
    }
}
