using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Vector2 targetpos;
    public float Yincrement;
    public float speed;
    public float maxHeight;
    public float minHeight;
    private float time = 0.20f;
    private float timer = 0.20f;
    public int health = 3;
    // Update is called once per frame

    void Update()
    {
        if(health == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        transform.position = Vector2.MoveTowards(transform.position, targetpos, speed * Time.deltaTime);

        timer -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < maxHeight && timer<0)
        {
            targetpos = new Vector2(transform.position.x, transform.position.y + Yincrement);
            timer = time;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > minHeight && timer < 0)
        {
            targetpos = new Vector2(transform.position.x, transform.position.y - Yincrement);
            timer = time;
        }
    }
}
