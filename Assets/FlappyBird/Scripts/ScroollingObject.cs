using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScroollingObject : MonoBehaviour
{
    private Rigidbody2D rb2d;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(GameControll.instance.scroolSpeed, 0);
    }

    void Update()
    { //if game over the background stops moving
        if(GameControll.instance.GameOver == true)
        {
            rb2d.velocity = Vector2.zero;
        }
    }
}
