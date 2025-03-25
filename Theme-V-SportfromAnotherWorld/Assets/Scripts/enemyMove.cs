using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMove : MonoBehaviour
{
    [SerializeField]Rigidbody2D enemy;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.game)
            enemy.velocity = new Vector2(0.2f, 0) * Random.Range(1f, 15f);
        else { }
    }
}
