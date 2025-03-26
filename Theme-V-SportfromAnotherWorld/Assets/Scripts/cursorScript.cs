using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursorScript : MonoBehaviour
{
    public float followSpeed = 0.1f;
    [SerializeField] GameObject[] beers;
    int beerlevel;
    float randomSpeed;

    // Use this for initialization
    void Start()
    {
        beerlevel = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 beerPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = Vector2.Lerp(transform.position, beerPosition, followSpeed);
        beers[beerlevel].SetActive(true);

        if (DrinkingBeer())
        {
            switch (beerlevel)
            {
                case 0:
                    break;

                case 1:
                    randomSpeed = Random.Range(-1f, 2f);
                    break;

                case 2:
                    randomSpeed = Random.Range(-1f, 5f);
                    break;

                case 3:
                    randomSpeed = Random.Range(-1f, 10f);
                    break;
            }

            playerMove.speed += randomSpeed;
            randomSpeed = 0;
            beerlevel = 0;
        }

        if(beerlevel > 3)
        {
            beerlevel = 3;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "beer")
        {
            beerlevel++;
        }

    }

    bool DrinkingBeer()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log(randomSpeed);
            beers[1].SetActive(false);
            beers[2].SetActive(false);
            beers[3].SetActive(false);
            return true;
        }
        return false;
    }
}
