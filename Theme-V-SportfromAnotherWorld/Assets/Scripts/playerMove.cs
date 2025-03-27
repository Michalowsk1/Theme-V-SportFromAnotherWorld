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


    [SerializeField] GameObject green;
    [SerializeField] GameObject red;

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

        green.SetActive(false);
        red.SetActive(false);
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

        if(timer >= 3)
        {
            speed -= 0.25f;
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
                StartCoroutine(correct());
                speed += 5f;
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

            else if (firstKey && (Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.D))) //WRONG BUTTON
            {
                speed -= 1f;
            }

            if (firstKey && secondkey && Input.GetKeyDown(KeyCode.D))
            {
                speed += 5f;
                button1Tick.SetActive(false);
                firstKey = false;
                button2Tick.SetActive(false);
                secondkey = false;
            }

            else if (firstKey && secondkey && (Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.R))) //WRONG BUTTON
            {
                speed -= 1f;

            }


        }

        if (gameManager.level == 3) //Drunk Round = punishes for wrong input , camera rotates
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                firstKey = true;
                button1Tick.SetActive(true);
            }

            if (firstKey && Input.GetKeyDown(KeyCode.O))
            {
                secondkey = true;
                button2Tick.SetActive(true);
            }

            else if (firstKey && (Input.GetKeyDown(KeyCode.L) || Input.GetKeyDown(KeyCode.I))) //WRONG BUTTON
            {
                speed -= 1f;

            }

            if (firstKey && secondkey && Input.GetKeyDown(KeyCode.I))
            {
                speed += 4.5f;
                button1Tick.SetActive(false);
                firstKey = false;
                button2Tick.SetActive(false);
                secondkey = false;
            }
            else if (firstKey && secondkey && (Input.GetKeyDown(KeyCode.O) || Input.GetKeyDown(KeyCode.L))) //WRONG BUTTON
            {
                speed -= 1f;

            }


        }

        if (gameManager.level == 4) //Drunk Round = punishes for wrong input, camera rotates and shrinks and increases
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                firstKey = true;
                button1Tick.SetActive(true);
            }

            if (firstKey && Input.GetKeyDown(KeyCode.Z))
            {
                secondkey = true;
                button2Tick.SetActive(true);
            }

            else if (firstKey && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.N))) //WRONG BUTTON
            {
                speed -= 1f;
            }

            if (firstKey && secondkey && Input.GetKeyDown(KeyCode.N))
            {
                speed += 5f;
                button1Tick.SetActive(false);
                firstKey = false;
                button2Tick.SetActive(false);
                secondkey = false;
            }

            else if (firstKey && secondkey && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Z))) //WRONG BUTTON
            {
                speed -= 1f;
            }


        }
    }

    IEnumerator correct()
    {
        green.SetActive(true);
        yield return new WaitForSeconds(0.01f);
        green.SetActive(false);
    }

    IEnumerator Incorrect()
    {
        red.SetActive(true);
        yield return new WaitForSeconds(0.01f);
        red.SetActive(false);
    }
}
