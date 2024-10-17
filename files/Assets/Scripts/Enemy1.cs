using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public float speedI = 1f;
    public float speedF = 2.7f;

    // Update is called once per frame
    void FixedUpdate()
    {
        float time = EventSystemScript.diff;

        float speed;
        if (transform.position.x > 1f)
            speed = speedI * time;
        else
            speed = speedF * time;

        transform.Translate(Vector3.left * speed * Time.fixedDeltaTime);
    }
}
