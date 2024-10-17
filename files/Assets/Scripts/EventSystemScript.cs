using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSystemScript : MonoBehaviour
{
    public static float diff = 1;

    //KILLCOINS
    public static int counter = 0;
    //PUNTI
    public static float punteggio = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Difficolta());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    private void FixedUpdate()
    {
        punteggio += 0.015f * diff; 
    }

    IEnumerator Difficolta()
    {
        yield return new WaitForSeconds(10);
        diff = 1.1f;
        yield return new WaitForSeconds(10); //20
        Spawner.spawnInterval = 1.3f;
        diff = 1.2f;
        yield return new WaitForSeconds(10);
        diff = 1.3f;
        yield return new WaitForSeconds(10); //40
        Spawner.spawnInterval = 1.2f;
        diff = 1.4f;
        yield return new WaitForSeconds(10);
        diff = 1.5f;
        yield return new WaitForSeconds(10);
        diff = 1.6f;
        yield return new WaitForSeconds(10);
        diff = 1.7f;
        yield return new WaitForSeconds(10); //80
        Spawner.spawnInterval = 1.1f;
        diff = 1.8f;
        yield return new WaitForSeconds(10);
        diff = 1.9f;
        yield return new WaitForSeconds(10);
        diff = 2f;
        yield return new WaitForSeconds(20); //120
        Spawner.spawnInterval = 1.1f;
        yield return new WaitForSeconds(30); //150
        Spawner.spawnInterval = 1f;
        yield return new WaitForSeconds(30); //180
        Spawner.spawnInterval = 0.9f;
    }
}
