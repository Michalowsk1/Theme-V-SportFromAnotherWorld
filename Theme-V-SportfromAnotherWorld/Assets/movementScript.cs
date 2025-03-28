using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class movementScript : MonoBehaviour
{
    [SerializeField] GameObject letter;
    [SerializeField] Rigidbody2D letterMove;
    [SerializeField] GameObject[] cracks;
    [SerializeField] GameObject shard;

    float xMove;
    float yMove;

    int clickCount;
    int crackArr;
    // Start is called before the first frame update
    void Start()
    {
        shard.SetActive(true);
        cracks[1].SetActive(false);
        cracks[2].SetActive(false);
        cracks[3].SetActive(false);
        clickCount = 0;
        crackArr = 0;
        xMove = 0.8f;
        yMove = 0.5f;
        letter.transform.position = new Vector2(43f, -13f);
    }

    // Update is called once per frame
    void Update()
    {
        ShardCracker();
        cracks[crackArr].SetActive(true);
        letterMove.velocity = new Vector2(xMove, yMove);

    }

    void ShardCracker()
    {
        if (clickCount == 5)
        {
            crackArr++;
            clickCount = 0;
        }

        if (crackArr == 4)
        {
            cracks[1].SetActive(false);
            cracks[2].SetActive(false);
            cracks[3].SetActive(false);
            cracks[4].SetActive(false);
            shard.SetActive(false);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision) //bounces against walls
    {
        if(collision.gameObject.tag == "xWall")
        {
            xMove = xMove * -1;
        }

        if(collision.gameObject.tag == "yWall")
        {
            yMove = yMove * -1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "sword")
        {
            clickCount++;

        }
        else Debug.Log("noHit");
    }
}
