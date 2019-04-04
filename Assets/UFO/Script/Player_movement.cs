﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_movement : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float speed;
    public int Count;
    public Text countText;
    public Text winText;
    public GameObject panel;
    public GameObject quit;
    private bool playerWins =false;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        winText.text = "";
        SetCountText();
    }

    private void FixedUpdate()
    {
        var vertical = Input.GetAxis("Vertical");
        var horizontal = Input.GetAxis("Horizontal");
        var movement = new Vector2(horizontal, vertical);
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
            playerWins = true;
            panel.SetActive(true);
            quit.SetActive(false);
            winText.text = "You WIN";
        }
        else if (Count == 0 && PlayerPrefs.GetInt("ufolv") == 10)
        {
            playerWins = true;
            panel.SetActive(true);
            quit.SetActive(false);
            winText.text = "Congratulations You Finished last lv";
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "spike" && playerWins == false)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
