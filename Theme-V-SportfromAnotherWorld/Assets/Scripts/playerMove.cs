using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    int timer;
    [SerializeField] Rigidbody2D player;
    public float speed = 0;

    bool firstKey = false;
    bool secondkey = false;
    bool thirdkey = false;
    bool fourthkey = false;
    // Start is called before the first frame update
    void Start()
    {
        speed = 0;
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
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
            speed -= 0.5f;
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
            }

            if(firstKey && Input.GetKeyDown(KeyCode.P))
            {
                speed += 1f;
                firstKey = false;
            }


           
        }
    }
}
