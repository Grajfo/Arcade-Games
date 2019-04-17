using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_racket : MonoBehaviour
{
    public float speed;
    public string axis;


    private void FixedUpdate()
    {
        //get axis to move up and down
        float v = Input.GetAxisRaw(axis);
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, v) * speed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //change color if ball touches racket
        if (collision.gameObject.name == "Ball")
        {
            GetComponent<SpriteRenderer>().color = Gamecontrol.instance.get_color();
            GetComponent<AudioSource>().Play();

        }
    }
}
