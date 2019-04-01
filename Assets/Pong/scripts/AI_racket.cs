using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_racket : MonoBehaviour
{
    private Transform target;
    public float speed;

    private Color get_color()
    {
        Color Displayer = new Color(
          Random.Range(0f, 1f),
          Random.Range(0f, 1f),
          Random.Range(0f, 1f)
          );
        return Displayer;
    }
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("ball").GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var targ = target.position;

        if (transform.position.y < 32f && transform.position.y > -32f)
        {
            var check = transform.position;
            Vector2 v2 = new Vector2(60, check.y);
            Vector2 t2 = new Vector2(60, targ.y);
            transform.position = Vector2.MoveTowards(v2, t2, speed * Time.deltaTime);
        }
        else if(transform.position.y >= 32f)
        {
            Vector2 v2 = new Vector2(60, 31.9f);
            Vector2 t2 = new Vector2(60, targ.y);
            transform.position = Vector2.MoveTowards(v2, t2, speed * Time.deltaTime);

        }
        else if (transform.position.y <= -32f)
        {
            Vector2 v2 = new Vector2(60, -31.9f);
            Vector2 t2 = new Vector2(60, targ.y);
            transform.position = Vector2.MoveTowards(v2, t2, speed * Time.deltaTime);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            GetComponent<SpriteRenderer>().color = get_color();
            GetComponent<AudioSource>().Play();

        }
    }
}
