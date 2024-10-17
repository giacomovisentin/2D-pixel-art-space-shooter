using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robottone : MonoBehaviour
{
    public GameObject shootPrefab;
    public float downShotOffPos;
    public float leftShotOffPos;
    public float speed = 1; 
    public int helth; 

    // Start is called before the first frame update
    void Start()
    {
        helth = 10; 
        InvokeRepeating("spara", 1, 0.7f);
    }

    // Update is called once per frame
    void Update()
    {
        float time = EventSystemScript.diff;
        
        if (transform.position.x > 1.355f)
            transform.Translate(Vector3.left * speed * Time.fixedDeltaTime * time);

        if (helth < 0)
            Destroy(gameObject);
    }

    void spara()
    {
        Instantiate(shootPrefab, transform.position - new Vector3(-leftShotOffPos, -downShotOffPos, 0), shootPrefab.transform.rotation);
    }
}
