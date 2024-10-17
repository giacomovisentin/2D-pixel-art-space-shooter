using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sosia : MonoBehaviour
{
    float verticalMove = 0f;
    public float yRange = 0.5f;
    Vector2 movement;

    public Animator animator;
    public GameObject player;

    void FixedUpdate()
    {
        transform.position = player.transform.position; 
       

        //ANIMAZIONI
        animator.SetFloat("Vertical", verticalMove);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }
}

/*
 //MOVIMENTO
        if (transform.position.y < -yRange)
        {
            transform.position = new Vector2(transform.position.x, -yRange);
        }
        else if (transform.position.y > yRange)
        {
            transform.position = new Vector2(transform.position.x, yRange);
        }

        verticalMove = joystick.Vertical * speed;
        movement.y = verticalMove;
        transform.Translate(Vector3.up * verticalMove * Time.deltaTime);

*/