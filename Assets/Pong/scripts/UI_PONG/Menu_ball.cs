using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu_ball : MonoBehaviour
{
    public int speed;
    public Text title;
    public Text button1, button2, button3;

    private void Start()
    {
        this.GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
    }

    //Hit factor where the ball hits the racket
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // for detecting ball with left racket and adding velocity to ball 
        if (collision.gameObject.name == "left_racket")
        {
            float y = hitFactor(transform.position,
                collision.transform.position,
                    collision.collider.bounds.size.y);

            Vector2 dir = new Vector2(1, y).normalized;
            GetComponent<Rigidbody2D>().velocity = dir * speed;
            GetComponent<SpriteRenderer>().color = Gamecontrol.instance.get_color();
            title.color = Gamecontrol.instance.get_color();
            button1.color = Gamecontrol.instance.get_color(); 
            button2.color = Gamecontrol.instance.get_color(); 
            button3.color = Gamecontrol.instance.get_color();
        }

        // for detecting ball with right racket and adding velocity to ball 

        else if (collision.gameObject.name == "right_racket")
        {
            float y = hitFactor(transform.position,
                collision.transform.position,
                    collision.collider.bounds.size.y);

            Vector2 dir = new Vector2(-1, y).normalized;
            GetComponent<Rigidbody2D>().velocity = dir * speed;
            GetComponent<SpriteRenderer>().color = Gamecontrol.instance.get_color();
            title.color = Gamecontrol.instance.get_color();
            button1.color = Gamecontrol.instance.get_color();
            button2.color = Gamecontrol.instance.get_color(); 
            button3.color = Gamecontrol.instance.get_color();
        }
    }
}
