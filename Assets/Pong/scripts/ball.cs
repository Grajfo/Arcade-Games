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
    public Text winner;
    public GameObject rightracket;
    public GameObject leftracket;
    public GameObject seperator;
    private int scorele = 0;
    private int scoreri = 0;
    private List<string> Check = new List<string> {"rightup", "leftup","rightdown","leftdown"};
    private Random random = new Random();
    // Start is called before the first frame update
    void Start()
    {
        System.Random rd = new System.Random();
        var st = rd.Next(Check.Count);
        //get random integer from length of check so when ball starts which way it will go
        if (Check[st] == "rightup")
        {
            GetComponent<Rigidbody2D>().velocity = (Vector2.right + Vector2.up) * 55;
        }
        else if (Check[st] == "leftup")
        {
            GetComponent<Rigidbody2D>().velocity = (Vector2.left + Vector2.up) * 55;

        }
        else if (Check[st] == "rightdown")
        {
            GetComponent<Rigidbody2D>().velocity = (Vector2.right + Vector2.down) * 55;

        }
        else if (Check[st] == "leftdown")
        {
            GetComponent<Rigidbody2D>().velocity = (Vector2.left + Vector2.down) * 55;

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
        // Check which won is the winner and display it
        if (scorele == 10)
        {
            seperator.SetActive(false);
            Destroy(rightracket.GetComponent<AI_racket>());
            Destroy(rightracket.GetComponent<move_racket>());
            Destroy(leftracket.GetComponent<move_racket>());
            Destroy(gameObject);
            winner.text = "WINNER LEFT";
            winner.gameObject.SetActive(true);
        }
        else if(scoreri == 10)
        {
            seperator.SetActive(false);
            Destroy(rightracket.GetComponent<AI_racket>());
            Destroy(rightracket.GetComponent<move_racket>());
            Destroy(leftracket.GetComponent<move_racket>()); Destroy(gameObject);
            winner.text = "WINNER RIGHT";
            winner.gameObject.SetActive(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "left_pallete")
        {
            // get value of where the ball hits the racket and returns ball in right directions with higher speed
            float y = hitFactor(transform.position, collision.transform.position, collision.collider.bounds.size.y);
            Vector2 dir = new Vector2(1, y).normalized;
            GetComponent<Rigidbody2D>().velocity = dir * speed;
            counter++;
            GetComponent<SpriteRenderer>().color = Gamecontrol.instance.get_color();
        }

        else if(collision.gameObject.name == "right_pallete" || collision.gameObject.name == "right_pallete_AI")
        {
            // get value of where the ball hits the racket and returns ball in left directions with higher speed
            float y = hitFactor(transform.position,collision.transform.position,collision.collider.bounds.size.y);
            Vector2 dir = new Vector2(-1, y).normalized;
            GetComponent<Rigidbody2D>().velocity = dir * speed;
            counter++;
            GetComponent<SpriteRenderer>().color = Gamecontrol.instance.get_color();
        }

        else if (collision.gameObject.name == "Right")
        {
            //if left player hits goal then score goes up and the speed of the ball goes to default value and color changes
            scorele += 1;
            scoreLeft.text = scorele.ToString();
            speed = 70;
            GetComponent<SpriteRenderer>().color = Gamecontrol.instance.get_color();
            GameObject.FindWithTag("MainCamera").GetComponent<Camera>().backgroundColor = Gamecontrol.instance.get_color();
            scoreLeft.color = Gamecontrol.instance.get_color();
        }
        else if (collision.gameObject.name == "Left")
        {
            //if right player hits goal then score goes up and the speed of the ball goes to default value and color changes
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
        if (counter == 3) // every 3 hits of racket the speed of a ball increase by 10
        {
            speed += 10;
            counter = 0;
        }

    }
}
