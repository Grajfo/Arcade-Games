using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_movement : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float speed;
    private int Count;
    public Text countText;
    public Text winText;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Count = 10;
        winText.text = "";
        SetCountText();
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            GetComponent<AudioSource>().Play();
            Count--;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + Count.ToString();
        if (Count == 0)
        {
            winText.text = "You WIN";
        }
    }
}
