using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    //public GameObject Spawner;
    public GameObject Joystick;
    public GameObject Player;

    //CANVAS
    public GameObject canvasPauseMenu;
    public GameObject canvasJoystick;
    public GameObject canvasPunteggio;
    public GameObject canvasHeart;
    public GameObject canvasGameOver;

    // Update is called once per frame
    void Start()
    {
        canvasPauseMenu.SetActive(false);
        canvasGameOver.SetActive(false);

        Time.timeScale = 1f;

        PlayerController.bloccoMovim = false;
        PlayerController.flag = true;
        PlayerController.flag2 = true;
    }

    public void Resume()
    {
        //FALSE
        canvasPauseMenu.SetActive(false);
        canvasGameOver.SetActive(false);
        //TRUE
        canvasJoystick.SetActive(true);
        canvasPunteggio.SetActive(true);
        canvasHeart.SetActive(true);

        //Destroy(canvasPauseMenu);

        Time.timeScale = 1f;
    }

    public void Pause()
    {
        //TRUE
        canvasPauseMenu.SetActive(true);
        //FALSE
        canvasJoystick.SetActive(false);
        canvasPunteggio.SetActive(false);
        canvasHeart.SetActive(false);
        canvasGameOver.SetActive(false);

        Time.timeScale = 0f;
    }

    public void Menu()
    {
        canvasGameOver.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        EventSystemScript.counter = 0;
        EventSystemScript.punteggio = 0;
    }

    public void Restart()
    {
        //FALSE
        canvasPauseMenu.SetActive(false);
        canvasGameOver.SetActive(false);
        //TRUE
        canvasJoystick.SetActive(true);
        canvasPunteggio.SetActive(true);
        canvasHeart.SetActive(true);

        Player.GetComponent<PlayerController>().Scarico.SetActive(true);
        Player.GetComponent<Animator>().SetBool("Last Heart", false);

        PlayerController.bloccoMovim = false;
        PlayerController.flag = true;
        PlayerController.flag2 = true;

        //Spawner.SetActive(false);
        //DestroyWithTag("Asteroid");
        //DestroyWithTag("Enemy");
        //Spawner.SetActive(true);

        Player.GetComponent<PlayerController>().horizontalMove = 0;
        Player.GetComponent<PlayerController>().verticalMove = 0;
        Joystick.GetComponent<FloatingJoystick>().Ripristino();

        Player.transform.position = new Vector3(-1.391f, 0.008f, 0);

        Time.timeScale = 1f;
        StartCoroutine(Collider());
    }

    IEnumerator Collider()
    {
        print("arriva");
        Player.GetComponent<CapsuleCollider2D>().enabled = false;
        yield return new WaitForSeconds(2);
        Player.GetComponent<CapsuleCollider2D>().enabled = true;
        Time.timeScale = 1f;
    }

    //----------INUTILIZZATI------------------------
    void DestroyWithTag(string destroyTag)
    {
        GameObject[] destroyObject;
        destroyObject = GameObject.FindGameObjectsWithTag(destroyTag);
        foreach (GameObject oneObject in destroyObject)
            Destroy(oneObject);
    }

}
