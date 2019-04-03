using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    private bool IsDeath = false;
    private Rigidbody2D rb2d;
    private Animator anim;
    private Transform trans;

    public float upforce = 200f;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        trans = GetComponent<Transform>();
        if (IsDeath == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2(0, upforce));
                anim.SetTrigger("Flap");
            }
            if (trans.position.y >= 5.7f)
            {
                rb2d.velocity = Vector2.zero;
                IsDeath = true;
                anim.SetTrigger("Death");
                GameControll.instance.playerDies();
            }
        }
    }

    void OnCollisionEnter2D()
    {
        rb2d.velocity = Vector2.zero;
        IsDeath = true;
        anim.SetTrigger("Death");
        GameControll.instance.playerDies();
    }
}
