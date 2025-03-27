using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class FinalLevel : MonoBehaviour
{

    public int timer;

    int timeGap;

    int stage;

    [SerializeField] GameObject InputRequired;
    [SerializeField] TextMesh InputText;

    string Inputs = "abcdefghijklmnopqrstuvwxyz";

    void Start()
    {
        stage = 1;
    }

    void Update()
    {
        timer = timer + 1;

        switch (stage)
        {
            case 1:
                timeGap = 900;
                break;

            case 2:
                timeGap = 750;
                break;

            case 3:
                timeGap = 600;
                break;
        }

        LetterRandomiser();






    }

    void LetterRandomiser()
    {
        if (timer >= timeGap)
        {
            char randomInput = Inputs[Random.Range(0, Inputs.Length)]; //RANDOMLY GENERATES LETTER

            InputText.text = randomInput.ToString();

            Debug.Log(randomInput);

            timer = 0;
        }
    }
}
