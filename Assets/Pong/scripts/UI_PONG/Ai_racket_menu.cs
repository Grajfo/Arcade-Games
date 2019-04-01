using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai_racket_menu : MonoBehaviour
{
    private Transform target;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("ball").GetComponent<Transform>();
    }
    private Color get_color()
    {
        Color Displayer = new Color(
          Random.Range(0f, 1f),
          Random.Range(0f, 1f),
          Random.Range(0f, 1f)
          );
        return Displayer;
    }
    // Update is called once per frame
    void Update()
    {
        var check = transform.position;
        var targ = target.position;
        Vector2 v2 = new Vector2(check.x, check.y);
        Vector2 t2 = new Vector2(check.x, targ.y);
        transform.position = Vector2.MoveTowards(v2, t2, speed * Time.deltaTime);
        Debug.Log(speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "ball")
        {
            GetComponent<SpriteRenderer>().color = get_color();
        }
    }
}