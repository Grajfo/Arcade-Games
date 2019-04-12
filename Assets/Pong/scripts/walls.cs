using UnityEngine;

public class walls : MonoBehaviour
{

    public GameObject s;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            GetComponent<SpriteRenderer>().color = Gamecontrol.instance.get_color();
            s.GetComponent<SpriteRenderer>().color = Gamecontrol.instance.get_color();
            GetComponent<AudioSource>().Play();
        }
        else if (collision.gameObject.name == "Ball" && collision.gameObject.tag == "tbwall")
        {
            GetComponent<SpriteRenderer>().color = Gamecontrol.instance.get_color();
        }
    }
}
