using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProvaCoroutine : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Prova());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Prova()
    {
        yield return new WaitForSeconds(2); //Attendi due secondi
        //print("PROVAA!!!!"); //funziona
        yield return new WaitForSeconds(2); //Attendi due secondi
        
    }
}
