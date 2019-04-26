using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class button_move : MonoBehaviour
{

    public float speed;
    private float dirY;
    public string axis;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        dirY = CrossPlatformInputManager.GetAxis(axis);
        rb.velocity = new Vector2(0, dirY) * speed;
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
