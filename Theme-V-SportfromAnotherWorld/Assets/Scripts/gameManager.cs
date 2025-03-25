using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public int timer = 0;
    [SerializeField] GameObject camera;
    [SerializeField] GameObject Drunk1Camera;
    [SerializeField] GameObject Drunk2Camera;
    [SerializeField] GameObject timeLine;
    [SerializeField] TextMesh speedText;

    [SerializeField] GameObject level1Keys;
    [SerializeField] GameObject level2Keys;
    [SerializeField] GameObject level3Keys;
    [SerializeField] GameObject level4Keys;

    [SerializeField] GameObject level1;
    [SerializeField] GameObject level2;
    [SerializeField] GameObject level3;
    [SerializeField] GameObject level4;


    public static float enemySpeed;

    public static int level;
    public static bool game;
    // Start is called before the first frame update
    void Start()
    {
        camera.SetActive(false);
        timeLine.SetActive(false);
        Drunk1Camera.SetActive(false);
        Drunk2Camera.SetActive(false);

        level1Keys.SetActive(false);
        level2Keys.SetActive(false);
        level3Keys.SetActive(false);
        level4Keys.SetActive(false);

        level1.SetActive(false);
        level2.SetActive(false);
        level3.SetActive(false);
        level4.SetActive(false);
        speedText.transform.position = new Vector2(100, 0);
        level = 1;
        game = false;
    }

    // Update is called once per frame
    void Update()
    {
        speedText.text = "Speed:" + playerMove.speed;
        StartCoroutine(introScene());
        BeginGame();

        switch (level)
        {
            case 1:
                camera.SetActive (true);
                level1.SetActive(true);
                speedText.transform.position = new Vector2(-8, -3);
                enemySpeed = 0.2f;
                level1Keys.SetActive(true);
                level2Keys.SetActive(false);
                level3Keys.SetActive(false);
                level4Keys.SetActive(false);

                break;


            case 2:
                level1.SetActive(false);
                level2.SetActive(true);

                enemySpeed = 0.2f;
                level1Keys.SetActive(false);
                level2Keys.SetActive(true);
                level3Keys.SetActive(false);
                level4Keys.SetActive(false);

                break;

            case 3:
                level2.SetActive(false);
                level3.SetActive(true);

                enemySpeed = 0.3f;
                level1Keys.SetActive(false);
                level2Keys.SetActive(false);
                level3Keys.SetActive(true);
                level4Keys.SetActive(false);

                break;

            case 4:
                level3.SetActive(false);
                level4.SetActive(true);

                enemySpeed = 0.35f;
                level1Keys.SetActive(false);
                level2Keys.SetActive(false);
                level3Keys.SetActive(false);
                level4Keys.SetActive(true);

                break;
        }
    }


    IEnumerator introScene()
    {
        timer++;
        timeLine.SetActive(true);
        if(timer == 1500)
        {
            Debug.Log("FINISHED");
        }
        yield return new WaitForSeconds(5);

    }


    void BeginGame()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            game = true;
        }
    }

}
