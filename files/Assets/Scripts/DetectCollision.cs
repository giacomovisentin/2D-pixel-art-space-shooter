using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    public float delay = 1f;
   
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 0.3f);


        if (hit.collider != null && (hit.collider.gameObject.tag == "Asteroid"
            || hit.collider.gameObject.tag == "Enemy" || hit.collider.gameObject.tag == "Robottone"))
        {
            GameObject colpito = hit.collider.gameObject;

            //ASTEROIDE
            if (colpito.tag == "Asteroid")
            {
                colpito.GetComponent<Animator>().SetBool("Hit", true);
                colpito.GetComponent<AsteroidMove>().speed *= 0.7f;
                colpito.GetComponent<CircleCollider2D>().enabled = false; 
            }
            //ENEMY
            if (colpito.tag == "Enemy")
            {
                colpito.GetComponent<Animator>().SetBool("Hit", true);
                colpito.GetComponent<Enemy1>().speedF *= 0.7f;
                colpito.GetComponent<CapsuleCollider2D>().enabled = false;
            }
            //ROBOTTONE
            if (colpito.tag == "Robottone")
            {
                colpito.GetComponent<Robottone>().helth--;
                print(colpito.GetComponent<Robottone>().helth--);
                StartCoroutine(Robottone(colpito));
            }

            //--per accorciare le animazioni
            if (colpito.tag == "Asteroid")
                Destroy(colpito, colpito.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length - 0.1f);
            else
                Destroy(colpito, colpito.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length - 0.05f);

            //StartCoroutine(Aspetta(colpito));
            EventSystemScript.counter++;
            EventSystemScript.punteggio++;

            //Hit something, print the tag of the object
            //Debug.Log("Hitting: " + hit.collider.tag);
            //Get the sprite renderer component of the object
            //SpriteRenderer sprite = hit.collider.gameObject.GetComponent<SpriteRenderer>();
            //Change the sprite color
            //sprite.color = Color.green;

            Destroy(gameObject, 0.03f);
        }
    }

    IEnumerator Robottone(GameObject colpito)
    {
        colpito.GetComponent<CapsuleCollider2D>().enabled = false;
        yield return new WaitForSeconds(1);
        colpito.GetComponent<CapsuleCollider2D>().enabled = false;
    }

}







/*
    IEnumerator Aspetta(GameObject coplpitoo)
    {
        yield return new WaitForSeconds(1);
        print("Funziona");
        Destroy(coplpitoo);
    }
            if (colpito.tag == "Asteroid")
            {
                colpito.GetComponent<Animator>().SetBool("Hit", true);
                colpito.GetComponent<AsteroidMove>().speed *= 0.7f;
                Destroy(colpito, colpito.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
            }
*/

// GameObject go; 
//void OnTriggerEnter2D(Collider2D other)
//{
//    Destroy(gameObject);
//    go = other.gameObject;
//    go.GetComponent<Animator>().SetBool("Hit", true);
//    //go.GetComponent<AsteroidMove>().speed = 0.03f;
//
//    go.GetComponent<Animator>().SetTrigger("explosion");
//
//    Destroy(go, delay);
//    //Destroy(go, go.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length - 0.3f);
//
//    //StartCoroutine(Coroutine());
//    //Invoke("SpaccaTutto", 2);
//    //Destroy(go);
//
//    counter++;
//}

//void SpaccaTutto()
//{
//    Destroy(go);
//}
//
//
//IEnumerator Coroutine()
//{
//    yield return new WaitForSeconds(2f);
//    Destroy(go);
//}
