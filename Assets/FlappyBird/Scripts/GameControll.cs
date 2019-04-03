using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControll : MonoBehaviour
{
    public static GameControll instance;
    public GameObject GameOverTxt;
    public Text ScoreText;
    public bool GameOver = false;
    public float scroolSpeed;
    private int score = 0;
    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(GameOver == true && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }   
    }
    public void BirdScore()
    {
        if (GameOver)
        {
            return;
        }

        score++;
        ScoreText.text = "Score: " + score.ToString();
        
    }

    public void playerDies()
    {
        GameOverTxt.SetActive(true);
        GameOver = true;
    }


}
