using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Vector2 targetpos;
    public float Yincrement;
    public float speed;
    public float maxHeight;
    public float minHeight;
    public Text Scoretime;
    public Text Highscore;
    public Image[] hearts;
    public GameObject panel;
    public GameObject effect;
    public GameObject deathsound;
    private AudioSource[] Sounds;
    private float time = 0.18f;
    private float timer = 0.18f;
    public int health = 3;
    private float scoretime = 0;
    private float HighSc = 0;

    // Update is called once per frame

    private void Start()
    {
        HighSc = PlayerPrefs.GetFloat("EndRunnerScore");
        Sounds = GetComponents<AudioSource>();
        
    }


    void FixedUpdate()
    {
        scoretime += Time.deltaTime;
        Scoretime.text = "Score: " + Mathf.Round(scoretime);

        transform.position = Vector2.MoveTowards(transform.position, targetpos, speed * Time.deltaTime);

        timer -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < maxHeight && timer < 0)
        { 
            Instantiate(effect, transform.position, Quaternion.identity);
            targetpos = new Vector2(transform.position.x, transform.position.y + Yincrement);
            Sounds[1].Play();
            timer = time;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > minHeight && timer < 0)
        {
            Instantiate(effect, transform.position, Quaternion.identity);
            targetpos = new Vector2(transform.position.x, transform.position.y - Yincrement);
            Sounds[1].Play();
            timer = time;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (health == 2 && (other.CompareTag("Enemy")))
        {
            hearts[2].gameObject.SetActive(false);
        }
        if (health == 1 && (other.CompareTag("Enemy")))
        {
            hearts[1].gameObject.SetActive(false);

        }
        if (health == 0 && (other.CompareTag("Enemy")))
        {
            if (scoretime > HighSc)
            {
                deathsound.GetComponent<AudioSource>().Play();
                PlayerPrefs.SetFloat("EndRunnerScore", scoretime);
                hearts[0].gameObject.SetActive(false);
                HighSc = PlayerPrefs.GetFloat("EndRunnerScore");
                Highscore.text = "You're new HighScore\n " + Mathf.Round(HighSc);
                Destroy(gameObject);
                Destroy(this);
                panel.SetActive(true);
            }
            else
            {
                deathsound.GetComponent<AudioSource>().Play();
                hearts[0].gameObject.SetActive(false);
                HighSc = PlayerPrefs.GetFloat("EndRunnerScore");
                Highscore.text = "HighScore\n " + Mathf.Round(HighSc);
                Destroy(gameObject);
                Destroy(this);
                panel.SetActive(true);
            }
        }
    }
}
