using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Columns : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {   //diplay and count the bird score
        if(other.GetComponent<playerMovement> () != null)
        {
            GameControll.instance.BirdScore();
        }
    }
}
