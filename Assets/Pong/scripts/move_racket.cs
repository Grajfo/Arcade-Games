﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_racket : MonoBehaviour
{
    public float speed;
    public string axis;


    private void FixedUpdate()
    {
        float v = Input.GetAxisRaw(axis);
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, v) * speed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            GetComponent<SpriteRenderer>().color = Gamecontrol.instance.get_color();
            GetComponent<AudioSource>().Play();

        }
    }
}
