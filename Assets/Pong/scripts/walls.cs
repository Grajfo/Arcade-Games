using UnityEngine;

public class walls : MonoBehaviour
{

    public GameObject s;
    private Color get_color()
    {
        Color Displayer = new Color(
          Random.Range(0f, 1f),
          Random.Range(0f, 1f),
          Random.Range(0f, 1f)
          );
        return Displayer;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            GetComponent<SpriteRenderer>().color = get_color();
            s.GetComponent<SpriteRenderer>().color = get_color();
            GetComponent<AudioSource>().Play();
        }
        else if (collision.gameObject.name == "Ball" && collision.gameObject.tag == "tbwall")
        {
            GetComponent<SpriteRenderer>().color = get_color();
        }
    }
}
