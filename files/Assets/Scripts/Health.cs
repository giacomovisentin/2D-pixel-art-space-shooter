using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float health;
    public int numOfHeart;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite halfHeart;
    public Sprite emptyHeart;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart; 
            }

            if (health % 2 == 0.5 || health % 2 == 1.5)
            {
                if (UltimoCuore(i))
                {
                    hearts[i].sprite = halfHeart;
                }
            }

            //per abilitare il numero di cuori da visualizzare
            if (i < numOfHeart)
            {
                hearts[i].enabled = true; 
            }
            else
            {
                hearts[i].enabled = false;
            }
        }

        if (numOfHeart <= 0)
            numOfHeart = 0; 
    }

    bool UltimoCuore(int heartIndex)
    {
        float num = heartIndex + 1 - health;
        if (num == 0.5)
        {
            return true;
        }
        else
            return false; 
    }

    public void addHeart()
    {
        if (health == numOfHeart)
            return;
        if (health >= numOfHeart - 1)
            health = numOfHeart;
        else
            health++;
    }

    public bool isMaxHealth()
    {
        if (health == numOfHeart)
            return true;
        else
            return false; 
    }
}
