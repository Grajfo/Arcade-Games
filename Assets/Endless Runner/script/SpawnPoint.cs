using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject enemy;

    void Start()
    {   //instantiate enemies
        Instantiate(enemy, transform.position, Quaternion.identity);
    }

}
