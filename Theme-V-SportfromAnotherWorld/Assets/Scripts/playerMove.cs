using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    int timer;
    [SerializeField] Rigidbody2D player;
    public static float speed = 0;

    [SerializeField] GameObject button1Tick;
    [SerializeField] GameObject button2Tick;
    [SerializeField] GameObject button3Tick;

    bool firstKey = false;
    bool secondkey = false;
    bool thirdkey = false;
    // Start is called before the first frame update
    void Start()
    {
        speed = 0;
        player = GetComponent<Rigidbody2D>();

        button1Tick.SetActive(false);
        button2Tick.SetActive(false);
        button3Tick.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        speed = Mathf.Round(speed * 10.0f) * 0.1f;  
        if (gameManager.game)
        {
            speedDecrease();
            SpeedIncreaser();
            player.velocity = new Vector2(speed, 0);
        }
    }


    void speedDecrease()
    {
        timer++;

        if(timer >= 20)
        {
            speed -= 0.1f;
            timer = 0;
        }

        if(speed <= 0)
        {
            speed = 0;
        }
    }    

    void SpeedIncreaser()
    {
        if(gameManager.level == 1) //SOBER ROUND - NO SLOWING DOWN
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                firstKey = true;
                button1Tick.SetActive(true);
            }

            if(firstKey && Input.GetKeyDown(KeyCode.P))
            {
                speed += 0.5f;
                button1Tick.SetActive(false);

                button2Tick.SetActive(true);
                button2Tick.SetActive(false);
                firstKey = false;
            }

        }

        if (gameManager.level == 2) //Drunk Round = punishes for wrong input
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                firstKey = true;
                button1Tick.SetActive(true);
            }

            if (firstKey && Input.GetKeyDown(KeyCode.R))
            {
                secondkey = true;
                button2Tick.SetActive(true);
            }

            if (firstKey && secondkey && Input.GetKeyDown(KeyCode.D))
            {
                speed += 1f;
                button1Tick.SetActive(false);
                firstKey = false;
                button2Tick.SetActive(false);
                secondkey = false;
            }


        }
    }
}
