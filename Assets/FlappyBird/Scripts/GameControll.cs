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
    public Text HighScoreText;
    public GameObject StartTxt;
    public bool GameOver = false;
    public float scroolSpeed;
    private int score = 0;
    private int Highscore;

    void Awake()
    {
        Highscore = PlayerPrefs.GetInt("highscore");
        HighScoreText.text = "HighScore: " + Highscore.ToString();
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void BirdScore()
    {
        if (GameOver) //gameover is true returns nothing else coutn score
        {
            return;
        }
        score++;
        ScoreText.text = "Score: " + score.ToString();
    }

    public void HighScore()
    {
        if(score> Highscore) // check if score is higher then highscore set ne highscore
        {
            PlayerPrefs.SetInt("highscore", score);
        }
    }

    public void StartText()
    {
        StartTxt.SetActive(false);
    }

    public void playerDies()
    {
        GameOverTxt.SetActive(true);
        GameOver = true;
        HighScore();
    }
}
