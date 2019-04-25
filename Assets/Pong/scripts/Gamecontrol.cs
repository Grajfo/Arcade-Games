using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamecontrol : MonoBehaviour
{
    //singelton class for calling methods globally
    public static Gamecontrol instance;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // method to get a certain color
    public Color get_color()
    {
        Color Displayer = new Color(
          Random.Range(0f, 1f),
          Random.Range(0f, 1f),
          Random.Range(0f, 1f)
          );
        return Displayer;
    }


}
