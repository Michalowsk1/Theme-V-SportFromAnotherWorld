using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "enemy" || collision.gameObject.tag == "chug")
        {
            Destroy(gameObject);
        }
    }
}
