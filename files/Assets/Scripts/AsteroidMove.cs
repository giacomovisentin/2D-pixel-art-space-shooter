using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMove : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        Angolazione();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float time = EventSystemScript.diff;

        transform.Translate(Vector3.left * speed * Time.fixedDeltaTime * time);
        transform.eulerAngles = Vector3.forward * rotationSpeed;
    }

    void Angolazione()
    {

        rotationSpeed = Random.Range(0, 15);
    }
}

//per fare delle rotazioni casuali
//transform.eulerAngles = Vector3.forward * 50;

//float time = GameObject.Find("EventSystem").GetComponent<EventSystemScript>().time;