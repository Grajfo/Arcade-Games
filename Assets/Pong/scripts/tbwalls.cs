using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tbwalls : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            GetComponent<SpriteRenderer>().color = Gamecontrol.instance.get_color();
        }
    }
}
