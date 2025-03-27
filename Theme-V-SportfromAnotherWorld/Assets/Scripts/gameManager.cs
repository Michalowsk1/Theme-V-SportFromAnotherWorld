using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public int timer = 0;
    [SerializeField] GameObject camera;
    [SerializeField] GameObject chugCursor;
    [SerializeField] GameObject Drunk1Camera;
    [SerializeField] GameObject Drunk2Camera;
    [SerializeField] GameObject Drunk3Camera;
    [SerializeField] GameObject timeLine1;
    [SerializeField] GameObject timeLine2;
    [SerializeField] GameObject timeLine3;
    [SerializeField] GameObject timeLine4;
    [SerializeField] GameObject timeLine5;
    [SerializeField] TextMesh speedText;

    [SerializeField] GameObject level1Keys;
    [SerializeField] GameObject level2Keys;
    [SerializeField] GameObject level3Keys;
    [SerializeField] GameObject level4Keys;

    [SerializeField] GameObject level1;
    [SerializeField] GameObject level2;
    [SerializeField] GameObject level3;
    [SerializeField] GameObject level4;
    [SerializeField] GameObject level5;
    [SerializeField] GameObject level6;





    public static float enemySpeed;

    public static int level;
    public static bool game;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        camera.SetActive(false);
        timeLine1.SetActive(false);
        timeLine2.SetActive(false);
        timeLine3.SetActive(false);
        timeLine4.SetActive(false);
        timeLine5.SetActive(false);
        Drunk1Camera.SetActive(false);
        Drunk2Camera.SetActive(false);
        Drunk3Camera.SetActive(false);

        level1Keys.SetActive(false);
        level2Keys.SetActive(false);
        level3Keys.SetActive(false);
        level4Keys.SetActive(false);

        level1.SetActive(false);
        level2.SetActive(false);
        level3.SetActive(false);
        level4.SetActive(false);
        level5.SetActive(false);
        level6.SetActive(false);

        chugCursor.SetActive(true);

        speedText.transform.position = new Vector2(100, 0);
        level = 1;
        game = false;
    }

    // Update is called once per frame
    void Update()
    {
        speedText.text = "Speed:" + playerMove.speed;
        switch (level)
        {
            case 1:
                timeLine1.SetActive (true);
                BeginGame();
                camera.SetActive (true);
                level1.SetActive(true);
                speedText.transform.position = new Vector2(-8, -3);
                enemySpeed = 0.05f;
                level1Keys.SetActive(true);
                level2Keys.SetActive(false);
                level3Keys.SetActive(false);
                level4Keys.SetActive(false);

                break;


            case 2:
                timeLine2.SetActive(true);
                BeginGame();
                level1.SetActive(false);
                level2.SetActive(true);
                camera.SetActive (false);
                Drunk1Camera.SetActive(true);

                enemySpeed = 0.1f;
                level1Keys.SetActive(false);
                level2Keys.SetActive(true);
                level3Keys.SetActive(false);
                level4Keys.SetActive(false);

                break;

            case 3:
                timeLine3.SetActive(true);
                BeginGame();
                level2.SetActive(false);
                level3.SetActive(true);

                Drunk1Camera.SetActive (false);
                Drunk2Camera.SetActive(true);

                enemySpeed = 0.1f;
                level1Keys.SetActive(false);
                level2Keys.SetActive(false);
                level3Keys.SetActive(true);
                level4Keys.SetActive(false);

                break;

            case 4:
                timeLine4.SetActive(true);
                BeginGame();
                level3.SetActive(false);
                level4.SetActive(true);

                Drunk2Camera.SetActive (false);
                Drunk3Camera.SetActive(true);

                enemySpeed = 0.1f;
                level1Keys.SetActive(false);
                level2Keys.SetActive(false);
                level3Keys.SetActive(false);
                level4Keys.SetActive(true);

                break;

             case 5:
                level4.SetActive (false);
                chugCursor.SetActive (false);
                timeLine5.SetActive(true);
                Drunk3Camera.SetActive (false);
                camera.SetActive(true);
                StartCoroutine(Cutscene());
                break;

             case 6:
                level5.SetActive (false);
                level6.SetActive(true);

                break;
        }
    }


    void BeginGame()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            game = true;
        }
    }

    IEnumerator Cutscene()
    {
        level5.SetActive(true);
        timeLine5.SetActive(true);
        yield return new WaitForSeconds(24);
        level++;
    }
}
