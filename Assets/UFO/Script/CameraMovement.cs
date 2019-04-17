using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraMovement : MonoBehaviour
{
    public GameObject Player;
    private Vector3 OffSet ;
    // Start is called before the first frame update
    void Start()
    { // save the index of the scene
        PlayerPrefs.SetInt("ufolv" ,SceneManager.GetActiveScene().buildIndex);
        int nekaj = PlayerPrefs.GetInt("ufolv");
        OffSet = transform.position - Player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {  //Camera follow player 
        transform.position = Player.transform.position + OffSet;
    }
}
