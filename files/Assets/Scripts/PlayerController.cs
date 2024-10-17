using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float speed = 2f;
    public float verticalMove = 0f;
    public float horizontalMove = -1.391f;
    public float yRange = 0.6f;
    public float xRange = 0.8f;
    public float freqSparo;
    public float sensibilità = 1f; 

    public Joystick joystick;
    public GameObject shootPrefab;
    public Animator animator;
    public GameObject Sosiaa;
    public GameObject Scarico; 

    Vector3 movement;
    Vector3 disSparo = new Vector3(0.2f, 0.0f);

    public static bool bloccoMovim = false;
    public static bool flag = true;
    public static bool flag2 = true;

    //CANVAS
    public GameObject canvasJoystick;
    public GameObject canvasPunteggio;
    public GameObject canvasHeart;
    public GameObject canvasGameOver;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spara", 1, freqSparo);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //MOVIMENTO 
        if (transform.position.y < -yRange) //verticale
        {
            transform.position = new Vector2(transform.position.x, -yRange);
        }
        else if (transform.position.y > yRange)
        {
            transform.position = new Vector2(transform.position.x, yRange);
        }
        
        if (transform.position.x < (-1.391f - 0.06)) //orizzontale
        {
            transform.position = new Vector2(-1.391f - 0.06f, transform.position.y);
        }
        else if (transform.position.x > (-1.391f + xRange))
        {
            transform.position = new Vector2(-1.391f + xRange, transform.position.y);
        }
        
        horizontalMove = joystick.Horizontal * speed * 0.6f;
        verticalMove = joystick.Vertical * speed;
        
        if (System.Math.Abs(horizontalMove) <= sensibilità)
            horizontalMove = 0;
        
        if (System.Math.Abs(verticalMove) <= sensibilità)
            verticalMove = 0;
        
        movement.x = horizontalMove;
        movement.y = verticalMove;

        if (bloccoMovim == false)
        {
            transform.Translate(horizontalMove * Time.fixedDeltaTime, verticalMove * Time.fixedDeltaTime, 0);
        }

        //ANIMAZIONI
        animator.SetFloat("Vertical", verticalMove);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        
        //CONTROLLO VITA
        if (gameObject.GetComponent<Health>().health <= 0)
        {
            
            bloccoMovim = true;
            canvasJoystick.SetActive(false);
            canvasPunteggio.SetActive(false);
            canvasHeart.SetActive(false);

            Sosiaa.SetActive(false);
            Scarico.SetActive(false);
            gameObject.GetComponent<Animator>().SetBool("Last Heart", true);

            StartCoroutine(aspetta());
            if (flag2 == false)
            {
                canvasGameOver.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }


    public IEnumerator aspetta()
    {
        if (flag == true)
        {
            flag = false;
            //print("funziona");
            yield return new WaitForSeconds(0.8f);
            flag2 = false;
        }  
    }

    void spara()
    {
        if (bloccoMovim == false) 
            Instantiate(shootPrefab, transform.position + disSparo, shootPrefab.transform.rotation);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Heart")
        {
            gameObject.GetComponent<Health>().addHeart();
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag != "Shoot")
        {
            Sosiaa.SetActive(true);
            Sosiaa.GetComponent<Animator>().SetTrigger("Hit");
            if (gameObject.GetComponent<Health>().health > 0)
                gameObject.GetComponent<Health>().health--;
            StartCoroutine("DisableSosia");
        }
    }

    IEnumerator DisableSosia()
    {
        yield return new WaitForSeconds(2);
        Sosiaa.SetActive(false);
    }
}







//if (joystick.Vertical > 0.1f)
//{
//    verticalMove = speed; 
//}
//else if (joystick.Vertical < -0.1f)
//{
//    verticalMove = -speed; 
//}
//else
//{
//    verticalMove = 0; 
//}


/*

//COLLISIONI
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 0.3f);
        if (hit.collider != null)
        {
            GameObject colpito = hit.collider.gameObject;

            colpito.GetComponent<Animator>().SetBool("Hit", true);
            if (colpito.tag == "Asteroid")
                colpito.GetComponent<AsteroidMove>().speed *= 0.7f;
            if (colpito.tag == "Enemy1")
                colpito.GetComponent<Enemy1>().speedF *= 0.7f;

            //Destroy(colpito, colpito.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);


            gameObject.GetComponent<Health>().health--;

            if (gameObject.GetComponent<Health>().health < 0)
            {
                //Time.timeScale = 0f;
            }

            //Destroy(gameObject, 0.03f);
        }
*/