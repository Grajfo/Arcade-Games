using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> ObstaclePatterns;
    public float decreaseTime;
    public float minTime = 0.65f;

    private float timeBtwSpawn;
    public float startTimeBtwSpawn;


    private void Update()
    {
        if (timeBtwSpawn <= 0)
        {
            int rand = Random.Range(0, ObstaclePatterns.Count);
            Instantiate(ObstaclePatterns[rand], transform.position, Quaternion.identity);
            timeBtwSpawn = startTimeBtwSpawn;
            if (startTimeBtwSpawn > minTime)
            {
                startTimeBtwSpawn -= decreaseTime;
            }
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
    }
}
