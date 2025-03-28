using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalLevel : MonoBehaviour
{

    public int timer;

    int timeGap;

    int stage;

    int clickCounter;

    [SerializeField] GameObject customCursor;
    [SerializeField] GameObject InputRequired;
    [SerializeField] TextMesh InputText;

    [SerializeField] GameObject stage1;
    [SerializeField] GameObject stage2;
    [SerializeField] GameObject stage3;




    string Inputs = "abcdefghijklmnopqrstuvwxyz";

    public Transform spawn;

    void Start()
    {
        stage = 1;
        stage1.SetActive(false);
        stage2.SetActive(false);
        stage3.SetActive(false);

    }

    void Update()
    {
        stageChanger();
        CustomCursor();
        timer = timer + 1;

        switch (stage)
        {
            case 1:
                stage1.SetActive(true);
          
                timeGap = 900;
                break;

            case 2:
                stage1.SetActive(false);
                stage2.SetActive(true);



                timeGap = 750;
                break;

            case 3:
                stage2.SetActive(false);
                stage3.SetActive(true);

                timeGap = 600;
                break;
        }

        LetterRandomiser();



        Debug.Log(stage + "  " + clickCounter);


    }

    void LetterRandomiser()
    {

        if (timer >= timeGap)
        {
            char randomInput = Inputs[Random.Range(0, Inputs.Length)]; //RANDOMLY GENERATES LETTER

            KeyCode keycode = (KeyCode)randomInput;

            InputText.text = randomInput.ToString();

            Debug.Log(randomInput);

            timer = 0;

            if(Input.GetKeyDown(keycode))
            {
                clickCounter++;
            }    

        }
    }

    void stageChanger()
    {
        if(stage == 1 && clickCounter >= 25)
        {
            stage++;
        }

        if (stage == 2 && clickCounter >= 75)
        {
            stage++;
        }

        if (stage == 3 && clickCounter == 200)
        {
            stage++;
        }
    }

    void CustomCursor()
    {
        Vector2 swordPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        customCursor.transform.position = Vector2.Lerp(customCursor.transform.position, swordPosition, 0.1f);
    }

}
