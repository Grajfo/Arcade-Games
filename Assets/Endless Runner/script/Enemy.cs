using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damage =1;
    public float speed;

    public GameObject effect;

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if(this.transform.position.x < -9)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(effect, transform.position, Quaternion.identity);
            other.GetComponent<Player>().health -= damage;
            Destroy(gameObject);
        }
    }

}
