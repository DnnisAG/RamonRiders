using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawnController : MonoBehaviour
{
    [SerializeField] private GameObject roadPrefab;
    [SerializeField] private int numInitialRoads = 3;

    private List<GameObject> roadList = new List<GameObject>();

    private void Start()
    {
        Vector3 spawnPosition = transform.position;
        for (int i = 0; i < numInitialRoads; i++)
        {
            SpawnNewRoad(spawnPosition);
            spawnPosition += roadPrefab.transform.localScale.z * Vector3.forward;
        }
    }

    private void SpawnNewRoad(Vector3 spawnPosition)
    {
        GameObject newRoad = Instantiate(roadPrefab, spawnPosition, Quaternion.identity);
        roadList.Add(newRoad);
    }

    public void RemoveRoad(GameObject road)
    {
        roadList.Remove(road);
    }

    private void Update()
    {
        if (roadList.Count == 0)
        {
            Vector3 spawnPosition = transform.position;
            for (int i = 0; i < numInitialRoads; i++)
            {
                SpawnNewRoad(spawnPosition);
                spawnPosition += roadPrefab.transform.localScale.z * Vector3.forward;
            }
        }
    }
}

