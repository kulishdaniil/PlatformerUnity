using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject botPrefab1;
    public GameObject botPrefab2;
    public Transform[] spawnPoints;

    public float spawnInterval = 10f;
    private float timer = 0f;

    private void Update()
    {
        TimerSpawn();
    }

    private void TimerSpawn()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnBot();
            timer = 0f;
        }
    }

    private void SpawnBot()
    {
        Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        switch (Random.Range(0, 1)) {
            case 0:
                {
                    Instantiate(botPrefab1, randomSpawnPoint.position, randomSpawnPoint.rotation);
                    break;
                }
            case 1:
                {
                    Instantiate(botPrefab2, randomSpawnPoint.position, randomSpawnPoint.rotation);
                    break;
                }
        }
    }
}