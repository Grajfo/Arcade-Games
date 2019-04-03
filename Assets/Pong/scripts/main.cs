using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class main : MonoBehaviour
{
    private bool pause;
    public ball balls;
    public Text countdowns;
    public string timerText;
    public GameObject seperator;
    public GameObject racketprefab;
    public Button quit;


    void Start()
    {
        pause = false;
        seperator.GetComponent<SpriteRenderer>().enabled = false;
        StartCoroutine(Countdown(3));
    }

    void Update()
    {
        countdowns.text = timerText.ToString();
        PauseGame();
    }
    private void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause = !pause;
        }
        if (pause)
        {
            Time.timeScale = 0;
            seperator.gameObject.SetActive(false);
            quit.gameObject.SetActive(true);
        }
        else if (!pause)
        {
            Time.timeScale = 1;
            seperator.gameObject.SetActive(true);
            quit.gameObject.SetActive(false);
        }
    }

    IEnumerator Countdown(int seconds)
    {
        int count = seconds;

        while (count >= 0)
        {
            if (count == 0)
            {
                timerText = "Go";
                countdowns.text = timerText.ToString();
                yield return new WaitForSeconds(1);
                count--;
            }
            else if( count > 0)
            {
                countdowns.text = timerText.ToString();
                yield return new WaitForSeconds(1);
                timerText = (int.Parse(timerText) - 1).ToString();
                count--;
            }
        }
        countdowns.enabled = false;
        seperator.GetComponent<SpriteRenderer>().enabled = true;
        balls.enabled = true;
    }
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void End(int scena)
    {
        SceneManager.LoadScene(scena);
    }
}
