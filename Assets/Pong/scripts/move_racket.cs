using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_racket : MonoBehaviour
{
    public float speed;
    public string axis;
    private Vector3 offset;
    private Rigidbody2D rb;

    void Start()
    {
        // Store reference to attached Rigidbody
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        //get axis to move up and down
        float v = Input.GetAxisRaw(axis);
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, v) * speed;
    }

    
    void OnMouseDown()
    {
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(0.0f, Input.mousePosition.y, 0.0f));
    }

      void OnMouseDrag()
     {
         // Move by Rigidbody rather than transform directly
         //rb.MovePosition(Camera.main.ScreenToWorldPoint(new Vector3(0.0f, Input.mousePosition.y)));
        Vector3 newPosition = new Vector3(0.0f, Input.mousePosition.y, 0.0f);
         var check = Camera.main.ScreenToWorldPoint(newPosition) + offset;
         rb.MovePosition(check);

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
    /* private void Checkposition(int i)
     {
         if (Input.touchCount > 0)
         {
             Touch touch = Input.GetTouch(i); // get first touch since touch count is greater than zero

             if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
             {
                 // get the touch position from the screen touch to world point
                 Vector3 touchedPos = Camera.main.ScreenToWorldPoint(new Vector3(0, touch.position.y, 0));
                 // lerp and set the position of the current object to that of the touch, but smoothly over time.
                 var nekaj = Vector3.Lerp(transform.position, touchedPos, Time.deltaTime);
                 rb.MovePosition(nekaj);
             }
         }
     }*/
}
