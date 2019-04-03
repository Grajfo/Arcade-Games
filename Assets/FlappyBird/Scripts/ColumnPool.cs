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
    private float spawnXPosition = 5f;
    private int currentColumn = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        columns = new List<GameObject>();
        for (int i = 0; i < columnPoolSize; i++)
        {
            columns.Add((GameObject)Instantiate(ColumnPrefab, objectPoolPosition, Quaternion.identity));
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;

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
