using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_racket : MonoBehaviour
{
    private Transform target;
    public float speed;
    private int framecount = 0;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        //check where position of gameobject ball is
        target = GameObject.FindGameObjectWithTag("ball").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // getting the framecount that every third frame ball checks where the position of the ball is
        framecount++;
        if (framecount == 3)
        {
            var targ = target.position;

            //checks that racket doesnt go througth wall

            var check = transform.position;
            Vector2 v2 = new Vector2(60.77785f, check.y);
            Vector2 t2 = new Vector2(60.77785f, targ.y);
            var nekaj = Vector2.MoveTowards(v2, t2, speed * Time.deltaTime);
            rb.MovePosition(nekaj);
            framecount = 0;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {   
        //change color
        if (collision.gameObject.name == "Ball")
        {
            GetComponent<SpriteRenderer>().color = Gamecontrol.instance.get_color();
            GetComponent<AudioSource>().Play();

        }
    }
}
