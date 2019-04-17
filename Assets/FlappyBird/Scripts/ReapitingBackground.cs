using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReapitingBackground : MonoBehaviour
{
    private BoxCollider2D groundColider;
    private float groundHorizontalLength;

    void Start()
    {
        groundColider = GetComponent<BoxCollider2D>();
        groundHorizontalLength = groundColider.size.x;
    }

    void Update()
    {   //check if the position x is smaller then groundcolliderlength so the background reposition to its value
        if (transform.position.x < -groundHorizontalLength)
        {
            repositionBackground();
        }
    }

    private void repositionBackground()
    {
        Vector2 groundOffset = new Vector2(groundHorizontalLength * 2f, 0);
        transform.position = (Vector2)transform.position + groundOffset;
    }
}
