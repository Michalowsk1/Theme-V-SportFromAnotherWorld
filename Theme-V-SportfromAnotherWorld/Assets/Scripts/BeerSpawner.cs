using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class BeerSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] beers;

    public Transform[] spawner;

    int beerint;

    int spawnint;

    public int timer;
    int subtimer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        beerint = Random.Range(0, beers.Length);

        spawnint = Random.Range(0, spawner.Length);

        timeCount();
        if (gameManager.game)
        {
            if (timer > Random.Range(25, 50))
            {
                Instantiate(beers[beerint], spawner[spawnint]);
                timer = 0;
            }
        }
        else { }
        
    }


    void timeCount()
    {
        subtimer++;

        if (subtimer > 30)
        {
            timer++;
            subtimer = 0;
        }
    }
}
