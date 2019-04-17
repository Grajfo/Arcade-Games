﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_racket : MonoBehaviour
{
    private Transform target;
    public float speed;
    private int framecount = 0;

    // Start is called before the first frame update
    void Start()
    {
        //check where position of gameobject ball is
        target = GameObject.FindGameObjectWithTag("ball").GetComponent<Transform>();
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
            if (transform.position.y < 32f && transform.position.y > -32f)
            {
                var check = transform.position;
                Vector2 v2 = new Vector2(60.50f, check.y);
                Vector2 t2 = new Vector2(60.50f, targ.y);
                transform.position = Vector2.MoveTowards(v2, t2, speed * Time.deltaTime);
            }
            else if (transform.position.y >= 32f)
            {
                Vector2 v2 = new Vector2(60.50f, 31.9f);
                Vector2 t2 = new Vector2(60.50f, targ.y);
                transform.position = Vector2.MoveTowards(v2, t2, speed * Time.deltaTime);

            }              
            else if (transform.position.y <= -32f)
            {
                Vector2 v2 = new Vector2(60.50f, -31.9f);
                Vector2 t2 = new Vector2(60.50f, targ.y);
                transform.position = Vector2.MoveTowards(v2, t2, speed * Time.deltaTime);
            }
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
