using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReapitingBg : MonoBehaviour
{
       public float speed;
       public float EndX;
       public float startX;

       // Update is called once per frame
       void Update()
       {
           transform.Translate(Vector2.left * speed * Time.deltaTime);

           if(transform.position.x <= EndX)
           {
               transform.position = new Vector2(startX, transform.position.y);

           }
       }
       
}
