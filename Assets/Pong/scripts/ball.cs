using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ball : MonoBehaviour
{
    private int counter = 0;
    public float speed;
    public Text scoreLeft;
    public Text scoreRight;
    public Text winner_left;
    public Text winner_right;
    private int scorele = 0;
    private int scoreri = 0;
    private string[] Check =  {"right", "left"};
    private Random random = new Random();
    // Start is called before the first frame update
    void Start()
    {
        System.Random rd = new System.Random();
        var st = rd.Next(Check.Length);
        if (Check[st] == "right")
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
        }
        else if(Check[st] == "left")
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.left * speed;

        }
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
    private void FixedUpdate()
    {
        if (scorele == 10)
        {
            Destroy(this);
            winner_left.text = "WINNER";
            winner_left.gameObject.SetActive(true);

        }
        else if(scoreri == 10)
        {
            Destroy(this);
            winner_right.text = "WINNER";
            winner_right.gameObject.SetActive(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "left_pallete")
        {
            float y = hitFactor(transform.position, 
                collision.transform.position, 
                    collision.collider.bounds.size.y);

            Vector2 dir = new Vector2(1, y).normalized;
            GetComponent<Rigidbody2D>().velocity = dir * speed;
            counter++;
            GetComponent<SpriteRenderer>().color = Gamecontrol.instance.get_color();
        }

        else if(collision.gameObject.name == "right_pallete" || collision.gameObject.name == "right_pallete_AI")
        {
            float y = hitFactor(transform.position,
                collision.transform.position,
                    collision.collider.bounds.size.y);

            Vector2 dir = new Vector2(-1, y).normalized;
            GetComponent<Rigidbody2D>().velocity = dir * speed;
            counter++;
            GetComponent<SpriteRenderer>().color = Gamecontrol.instance.get_color();
        }

        else if (collision.gameObject.name == "Right")
        {
            scorele += 1;
            scoreLeft.text = scorele.ToString();
            speed = 70;
            GetComponent<SpriteRenderer>().color = Gamecontrol.instance.get_color();
            GameObject.FindWithTag("MainCamera").GetComponent<Camera>().backgroundColor = Gamecontrol.instance.get_color();
            scoreLeft.color = Gamecontrol.instance.get_color();
        }
        else if (collision.gameObject.name == "Left")
        {
            scoreri += 1;
            scoreRight.text = scoreri.ToString();
            speed = 70;
            GetComponent<SpriteRenderer>().color = Gamecontrol.instance.get_color();
            GameObject.FindWithTag("MainCamera").GetComponent<Camera>().backgroundColor = Gamecontrol.instance.get_color();
            scoreRight.color = Gamecontrol.instance.get_color();
        }
        else if (collision.gameObject.tag == "tbwall")
        {
            GetComponent<SpriteRenderer>().color = Gamecontrol.instance.get_color();
        }
        if (counter == 3)
        {
            speed += 10;
            counter = 0;
        }

    }
}
