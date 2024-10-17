using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TestoPunti : MonoBehaviour
{
    public TextMeshProUGUI punti;
    public TextMeshProUGUI kill;


    // Start is called before the first frame update
    void Start()
    {
        //punti = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        kill.text = "KILLCOINS: " + EventSystemScript.counter;
        punti.text = "PUNTI: " + EventSystemScript.punteggio.ToString("0.##");
    }
    
    //punti.text = "PUNTI: " + EventSystemScript.counter;
}
