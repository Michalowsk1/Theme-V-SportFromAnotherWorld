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

    [SerializeField] GameObject level1Keys;
    [SerializeField] GameObject level2Keys;
    [SerializeField] GameObject level3Keys;

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
        level = 0;
        game = false;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(introScene());
        BeginGame();

        switch (level)
        {
            case 0:
                camera.SetActive(true);

                break;

                case 1:

                level1Keys.SetActive(true);
                level2Keys.SetActive(false);
                level3Keys.SetActive(false);

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

        level = 1;
        yield return null;
    }


    void BeginGame()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            game = true;
        }
    }

}
