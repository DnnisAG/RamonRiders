using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesSpawner : MonoBehaviour
{
    private int spawnInterval = 10;
    private int lastSpawnZ = 16;
    private int SpawnAmount = 4;

    public List<GameObject> obstacles;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnObstacles() {
        lastSpawnZ += spawnInterval;
        for (int i = 0; i< SpawnAmount; i++)
        {
            GameObject obstacle = obstacles[Random.Range(0, obstacles.Count)];

            Instantiate(obstacle, new Vector3(0, 0.25f, lastSpawnZ),obstacle.transform.rotation);
        }
    }

}
