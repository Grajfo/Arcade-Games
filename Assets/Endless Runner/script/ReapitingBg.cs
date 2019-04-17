using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReapitingBg : MonoBehaviour
{
       public float speed;
       public float EndX;
       public float startX;

       void Update()
       {
        // for reapiting backgroud
           transform.Translate(Vector2.left * speed * Time.deltaTime);

           if(transform.position.x <= EndX)
           {
               transform.position = new Vector2(startX, transform.position.y);

           }
       }
       
}
