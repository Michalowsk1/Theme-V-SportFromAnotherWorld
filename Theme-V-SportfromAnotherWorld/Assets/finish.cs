using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finish : MonoBehaviour
{
    [SerializeField] GameObject VictoryText;
    [SerializeField] GameObject DefeatText;
    [SerializeField] GameObject nextLevelButton;
    [SerializeField] GameObject playAgainButton;
    [SerializeField] GameObject timeline;


    void Start()
    {
        VictoryText.SetActive(false);
        DefeatText.SetActive(false);
        nextLevelButton.SetActive(false);
        playAgainButton.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            VictoryText.SetActive(true);
            nextLevelButton.SetActive(true);
            Time.timeScale = 0;
            playerMove.speed = 0;
            gameManager.enemySpeed = 0;

        }

        if(collision.gameObject.tag == "enemy")
        {
            DefeatText.SetActive(true);
            playAgainButton.SetActive(true);
            //Time.timeScale = 0;
            Debug.Log("FAIL");

        }
    }



    public void PlayAgain()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void NextLevel()
    {
        gameManager.level++;
        nextLevelButton.SetActive(false);
        VictoryText.SetActive(false);
        Time.timeScale = 1;
    }

}
