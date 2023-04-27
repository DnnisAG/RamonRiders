using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadController : MonoBehaviour
{
    [SerializeField] private GameObject nextRoadPrefab;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpawnTrigger"))
        {
            RoadSpawnController spawnController = other.GetComponentInParent<RoadSpawnController>();
            if (spawnController != null)
            {
                spawnController.RemoveRoad(gameObject);
                SpawnNextRoad(other.transform.position + nextRoadPrefab.transform.localScale.z * Vector3.forward);
            }
        }
    }

    private void SpawnNextRoad(Vector3 spawnPosition)
    {
        Instantiate(nextRoadPrefab, spawnPosition, Quaternion.identity);
    }
}
