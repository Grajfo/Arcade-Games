using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class button_move : MonoBehaviour
{

    private Rigidbody2D rb;
    private Rigidbody2D rb2;
    public GameObject left_rack;
    public GameObject right_rack;
    public float speed;
    // Start is called before the first frame update

    void Start()
    {
        // Store reference to attached Rigidbody
        rb = left_rack.GetComponent<Rigidbody2D>();
        rb2 = right_rack.GetComponent<Rigidbody2D>();

    }

    public void OnClicked(Button button)
    {
        if (button.name == "up_left")
        {
            rb.velocity = new Vector2(0, 1) * speed;
        }
        else if (button.name == "down_left")
        {
            rb.velocity = new Vector2(0, -1) * speed;
        }

        if (button.name == "up_right")
        {
            rb2.velocity = new Vector2(0, 1) * speed;

        }
        else if (button.name == "down_right")
        {
            rb2.velocity = new Vector2(0, -1) * speed;

        }
    }
}
