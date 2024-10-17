using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBound : MonoBehaviour
{
    public float limite = 2f;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > limite || transform.position.x < -limite)
        {
            Destroy(gameObject);
        }
    }
}
