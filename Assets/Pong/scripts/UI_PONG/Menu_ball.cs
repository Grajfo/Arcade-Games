using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_ball : MonoBehaviour
{
    public int speed;

    private void Start()
    {
        Debug.Log("zakaj ne dela");
        this.GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
    }

    float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketHeight)
    {
        // ascii art:
        // ||  1 <- at the top of the racket
        // ||
        // ||  0 <- at the middle of the racket
        // ||
        // || -1 <- at the bottom of the racket
        return (ballPos.y - racketPos.y) / racketHeight;
    }
    private Color get_color()
    {
        Color Displayer = new Color(
          Random.Range(0f, 1f),
          Random.Range(0f, 1f),
          Random.Range(0f, 1f)
          );
        return Displayer;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "left_racket")
        {
            float y = hitFactor(transform.position,
                collision.transform.position,
                    collision.collider.bounds.size.y);

            Vector2 dir = new Vector2(1, y).normalized;
            GetComponent<Rigidbody2D>().velocity = dir * speed;
            GetComponent<SpriteRenderer>().color = get_color();
        }

        else if (collision.gameObject.name == "right_racket")
        {
            float y = hitFactor(transform.position,
                collision.transform.position,
                    collision.collider.bounds.size.y);

            Vector2 dir = new Vector2(-1, y).normalized;
            GetComponent<Rigidbody2D>().velocity = dir * speed;
            GetComponent<SpriteRenderer>().color = get_color();
        }
    }
}
