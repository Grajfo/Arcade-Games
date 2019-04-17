using UnityEngine;

public class walls : MonoBehaviour
{

    public GameObject s;

    private void OnCollisionEnter2D(Collision2D collision)
    {        
        //if ball hits left or right wall(goal) collor of the wall and background changes 
        if (collision.gameObject.name == "Ball")
        {
            GetComponent<SpriteRenderer>().color = Gamecontrol.instance.get_color();
            s.GetComponent<SpriteRenderer>().color = Gamecontrol.instance.get_color();
            GetComponent<AudioSource>().Play();
        }
    }
}
