using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    private bool IsDeath = false;
    private Rigidbody2D rb2d;
    private Animator anim;
    private Transform trans;
    private int Count;
    public float upforce = 200f;

    //Setting values in start function
    void Start()
    {
        Count = 0;
        Time.timeScale = 0;
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        trans = GetComponent<Transform>();
        if (IsDeath == false) //check player isDeath
        {
            if (Input.GetMouseButtonDown(0)) // if player clicks mouse button the game starts
            {
                Time.timeScale = 1;
                GameControll.instance.StartText(); 
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2(0, upforce));
                this.GetComponents<AudioSource>()[1].Play();
                anim.SetTrigger("Flap");
            }
            if (trans.position.y >= 5.7f) //if player goes of screen he dies
            {
                rb2d.velocity = Vector2.zero;
                IsDeath = true;
                anim.SetTrigger("Death");
                GameControll.instance.playerDies();
                this.GetComponents<AudioSource>()[0].Play();
                Count++;
            }
        }
    }

    void OnCollisionEnter2D()
    {
        if (Count == 0) //if collision with piles or ground player dies
        {
            rb2d.velocity = Vector2.zero;
            IsDeath = true;
            anim.SetTrigger("Death");
            GameControll.instance.playerDies();
            this.GetComponent<AudioSource>().Play();
            Count++;
        }

    }
}
