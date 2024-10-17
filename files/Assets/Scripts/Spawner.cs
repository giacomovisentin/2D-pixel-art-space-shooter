using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float spawnRangeX;
    public float spawnRangeY;

    private float startDelay = 2;
    public static float spawnInterval = 1.5f;

    public GameObject[] nemici;
    public GameObject Heart;
    public GameObject Player;

    // BOOLEANS
    private bool aspetta;
    private bool aumentaDiff = false; 

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(ChangeSpawnInterval());
        InvokeRepeating("SpawnCuori", 0, 30);
        aspetta = false; 
    }

    private float GetSpawnInterval()
    {
        return spawnInterval;
    }

    IEnumerator ChangeSpawnInterval()
    {
        InvokeRepeating("SpawnRandom", startDelay, GetSpawnInterval());
        yield return new WaitForSeconds(21); 
        InvokeRepeating("SpawnRandom", startDelay, GetSpawnInterval());
        yield return new WaitForSeconds(41); 
        InvokeRepeating("SpawnRandom", startDelay, GetSpawnInterval());
        yield return new WaitForSeconds(81); 
        InvokeRepeating("SpawnRandom", startDelay, GetSpawnInterval());
        aumentaDiff = true; 
        yield return new WaitForSeconds(121); 
        InvokeRepeating("SpawnRandom", startDelay, GetSpawnInterval());
        yield return new WaitForSeconds(151);
        InvokeRepeating("SpawnRandom", startDelay, GetSpawnInterval());
        yield return new WaitForSeconds(181);
        InvokeRepeating("SpawnRandom", startDelay, GetSpawnInterval());
        yield return new WaitForSeconds(10);
        InvokeRepeating("SpawnRandom", startDelay, GetSpawnInterval());
    }

    //------- NORMALE SPAWN (asteroidi, enemy)
    void SpawnRandom()
    {
        if (aspetta == false)
        {
            int casuale = PercentualeGamePlay();

            if (casuale == 0)
            {
                print("normale GP");
                int index = PercentualeSpawn();
                Vector2 spawnPosition;

                if (index == 0 || index == 1)
                {
                    spawnPosition = new Vector2(spawnRangeX, Random.Range(-spawnRangeY, spawnRangeY + 0.5f));
                }
                else
                {
                    spawnPosition = new Vector2(spawnRangeX, Random.Range(-spawnRangeY, spawnRangeY));
                }


                Instantiate(nemici[index], spawnPosition, nemici[index].transform.rotation);
            }
            else if (casuale == 1)
            {
                print("Cascata Asterodi");
                aspetta = true;
                StartCoroutine("CascataAsteroidi");
            }
            else 
            {
                print("Armata Enemy");
                aspetta = true;
                StartCoroutine("ArmataEnemy");
            }
        } 
    }

    //la percentuale che il GamePlay sia normale o con Cascata di Asteroidi
    int PercentualeGamePlay()
    {
        int indice = Random.Range(0, 100);

        //normale
        if (indice < 95)
            return 0;
        //cascata asteroidi
        else if (indice < 98)
            return 1;
        //armata enemy
        else
            return 2;
    }

    //la probabilità che spowni un enemy è metà rispetto alla probabilità che spawny un asteroide
    int PercentualeSpawn()
    {
        int indice = Random.Range(0, 100);

        if (indice < 40)
            return 0;
        else if (indice < 80)
            return 1;
        else
            return 2;
    }


    //--------- SPAWNER CUORI
    void SpawnCuori()
    {
        StartCoroutine("Wait");

        if (!Player.GetComponent<Health>().isMaxHealth())
        {
            Vector2 spawnPosition = new Vector2(spawnRangeX, Random.Range(-spawnRangeY, spawnRangeY));
            Instantiate(Heart, spawnPosition, Heart.transform.rotation);
        }
    }

    IEnumerator Wait()
    {
        print("dovrebbe Funzionare");
        int num = Random.Range(0, 20);
        yield return new WaitForSeconds(num);
        print("IL NUMERO é" + num);
    }

    //--------- CASCATA ASTEROIDI -----------------
    IEnumerator CascataAsteroidi()
    {
        CasAst();
        yield return new WaitForSeconds(0.2f);
        CasAst();
        yield return new WaitForSeconds(0.2f);
        CasAst();
        yield return new WaitForSeconds(0.2f);
        CasAst();
        yield return new WaitForSeconds(0.2f);
        CasAst();
        yield return new WaitForSeconds(0.2f);
        CasAst();
        yield return new WaitForSeconds(0.2f);
        CasAst();
        yield return new WaitForSeconds(0.2f);
        CasAst();
        yield return new WaitForSeconds(0.2f);
        CasAst();
        yield return new WaitForSeconds(0.2f);
        CasAst();
        yield return new WaitForSeconds(0.2f);
        CasAst();
        yield return new WaitForSeconds(0.2f);
        CasAst();
        yield return new WaitForSeconds(0.2f);
        CasAst();
        yield return new WaitForSeconds(0.2f);
        CasAst();
        yield return new WaitForSeconds(0.2f);
        CasAst();
        yield return new WaitForSeconds(0.2f);
        CasAst();
        yield return new WaitForSeconds(0.2f);
        CasAst();
        yield return new WaitForSeconds(0.2f);
        CasAst();
        yield return new WaitForSeconds(0.2f);

        if (aumentaDiff == true)
        {
            CasAst();
            yield return new WaitForSeconds(0.2f);
            CasAst();
            yield return new WaitForSeconds(0.2f);
            CasAst();
            yield return new WaitForSeconds(0.2f);
            CasAst();
            yield return new WaitForSeconds(0.2f);
            CasAst();
            yield return new WaitForSeconds(0.2f);
            CasAst();
            yield return new WaitForSeconds(0.2f);
            CasAst();
            yield return new WaitForSeconds(0.2f);
            CasAst();
            yield return new WaitForSeconds(0.2f);
            CasAst();
            yield return new WaitForSeconds(0.2f);
            CasAst();
            yield return new WaitForSeconds(0.2f);
            CasAst();
            yield return new WaitForSeconds(0.2f);
        }
        aspetta = false; 
    }

    void CasAst()
    {
        int index = PercentualeAsteroidi();
        Vector2 spawnPosition = new Vector2(spawnRangeX, Random.Range(-spawnRangeY, spawnRangeY + 0.5f));
        Instantiate(nemici[index], spawnPosition, nemici[index].transform.rotation);
    }

    int PercentualeAsteroidi()
    {
        int indice = Random.Range(0, 100);

        //asteroide piccolo
        if (indice < 60)
            return 0;
        //asteroide grande
        else
            return 1;
    }

    //--------ARMATA DI ENEMY -----------------------
    IEnumerator ArmataEnemy()
    {
        ArmEn();
        yield return new WaitForSeconds(0.3f);
        ArmEn();
        yield return new WaitForSeconds(0.3f);
        ArmEn();
        yield return new WaitForSeconds(0.3f);
        ArmEn();
        yield return new WaitForSeconds(0.3f);
        ArmEn();
        ResetBool();
        yield return new WaitForSeconds(0.3f);
        ArmEn();
        yield return new WaitForSeconds(0.3f);
        ArmEn();
        yield return new WaitForSeconds(0.3f);
        ArmEn();
        yield return new WaitForSeconds(0.3f);
        ArmEn();
        yield return new WaitForSeconds(0.3f);
        ArmEn();
        ResetBool();
        yield return new WaitForSeconds(0.3f);
        ArmEn();
        yield return new WaitForSeconds(0.3f);
        ArmEn();
        yield return new WaitForSeconds(0.3f);
        ArmEn();
        yield return new WaitForSeconds(0.3f);
        ArmEn();
        yield return new WaitForSeconds(0.3f);
        ArmEn();
        yield return new WaitForSeconds(0.3f);

        if (aumentaDiff == true)
        {
            ArmEn();
            yield return new WaitForSeconds(0.3f);
            ArmEn();
            ResetBool();
            yield return new WaitForSeconds(0.3f);
            ArmEn();
            yield return new WaitForSeconds(0.3f);
            ArmEn();
            yield return new WaitForSeconds(0.3f);
            ArmEn();
            yield return new WaitForSeconds(0.3f);
            ArmEn();
            yield return new WaitForSeconds(0.3f);
            ArmEn();
            yield return new WaitForSeconds(0.3f);
        }
        aspetta = false;
    }

    void ArmEn()
    {
        float positionY = posizioneYEn();
        Vector2 spawnPosition = new Vector2(spawnRangeX, positionY);
        Instantiate(nemici[2], spawnPosition, nemici[2].transform.rotation);
    }

    private bool pos0 = true;
    private bool pos1 = true;
    private bool pos2 = true;
    private bool pos3 = true;
    private bool pos4 = true;
    
    private float posizioneYEn()
    {
        int posizione = Random.Range(0, 100);
        if (posizione < 20)
        {
            if (pos0 == false)
                return 0.3f;
            pos0 = false;
            return 0.6f;
        }
        else if (posizione < 40)
        {
            if (pos1 == false)
                return 0;
            pos1 = false;
            return 0.3f;
        }
        else if (posizione < 60)
        {
            if (pos2 == false)
                return -0.3f;
            pos2 = false;
            return 0;   
        }
        else if (posizione < 80)
        {
            if (pos3 == false)
                return -0.6f;
            pos3 = false;
            return -0.3f;
        }
        else
        {
            if (pos4 == false)
                return 0.6f;
            pos4 = false;
            return -0.6f;     
        }
    }

    private void ResetBool()
    {
         pos0 = true;
         pos1 = true;
         pos2 = true;
         pos3 = true;
         pos4 = true;
    }
}



/*
    public float spawnRangeX;
    public float spawnRangeY;

    private float startDelay = 2;
    private float spawnInterval = 2f;

    public GameObject[] asteroidi;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAsteroid", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRandomAsteroid()
    {
        int asteroidiIndex = Random.Range(0, asteroidi.Length);

        Vector2 spawnPosition = new Vector2(spawnRangeX, Random.Range(-spawnRangeY, spawnRangeY));

        Instantiate(asteroidi[asteroidiIndex], spawnPosition, asteroidi[asteroidiIndex].transform.rotation);
    }
*/