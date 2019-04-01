using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject Player;
    private Vector3 OffSet ;
    // Start is called before the first frame update
    void Start()
    {
        OffSet = transform.position - Player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Player.transform.position + OffSet;
    }
}
