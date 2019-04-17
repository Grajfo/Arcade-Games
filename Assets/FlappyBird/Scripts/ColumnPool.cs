using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour
{
    public int columnPoolSize = 5;
    public GameObject ColumnPrefab;
    public float spawnRate = 3f;
    public float columnMin = -2f;
    public float columnMax = 2f;


    private List<GameObject> columns;
    private Vector2 objectPoolPosition = new Vector2(-15f, -25f);
    private float timeSinceLastSpawned;
    private float spawnXPosition = 10f;
    private int currentColumn = 0;
    
    void Start()
    {   //instantiate 5 columnpools
        columns = new List<GameObject>();
        for (int i = 0; i < columnPoolSize; i++)
        {
            columns.Add((GameObject)Instantiate(ColumnPrefab, objectPoolPosition, Quaternion.identity));
        }
    }

    void Update()
    {
        //check the time last spawned
        timeSinceLastSpawned += Time.deltaTime;

        //position the obstacle at random position in the camera 
        if(GameControll.instance.GameOver == false && timeSinceLastSpawned >= spawnRate)
        {
            timeSinceLastSpawned = 0;
            float spawnYposition = Random.Range(columnMin, columnMax);
            columns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYposition);
            currentColumn++;
            if(currentColumn >= columnPoolSize)
            {
                currentColumn = 0;
            }
        }
    }
}
