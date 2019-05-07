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
            Vector3 targ = target.position;
            Vector3 check = transform.position;

            Vector2 v2 = new Vector2(rb.position.x, check.y);
            Vector2 t2 = new Vector2(rb.position.x, targ.y);
            Vector2 postion = Vector2.MoveTowards(v2, t2, speed * Time.deltaTime);
            rb.MovePosition(postion);
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
