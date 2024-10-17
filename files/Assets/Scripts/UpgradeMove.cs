using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMove : MonoBehaviour
{
    public float speed = 1f;
    float time = EventSystemScript.diff;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate( new Vector3(-speed * Time.fixedDeltaTime * time, Mathf.Sin(Time.time * 5) * 0.025f, 0) );
    }
}


//Time.time -speed * Time.fixedDeltaTime * time