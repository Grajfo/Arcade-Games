using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> ObstaclePatterns;
    public float decreaseTime;
    public float minTime = 0.65f;
    public float startTimeBtwSpawn;
    private float timeBtwSpawn;


    private void Update()
    {
        //check the time last spawn so the enemies dont spawn one after another in a second
        if (timeBtwSpawn <= 0)
        {
            int rand = Random.Range(0, ObstaclePatterns.Count);
            Instantiate(ObstaclePatterns[rand], transform.position, Quaternion.identity); // random generate pattern of obstacle
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
