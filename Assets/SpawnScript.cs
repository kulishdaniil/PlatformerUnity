using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BotSpawner : MonoBehaviour
{
    public GameObject botPrefab1;
    public GameObject botPrefab2;
    public Transform[] spawnPoints;

    public TextMeshProUGUI WaveText;

    public int numberOfEnemies = 2;
    public int nowTheEnemies = 0;

    private static int waveNumber = 0;
    private int indexBot;
    private float timer = 0;

    private void Update()
    {
        
        timer += Time.deltaTime;
        if (timer > 5)
        {
            if (SceneManager.GetActiveScene().name == "GameScene") TimerSpawn();
            timer = 0;
        }
    }

    private void TimerSpawn()
    {
        nowTheEnemies = GameObject.FindGameObjectsWithTag("Bot").Length;
        if (nowTheEnemies == 0)
        {
            numberOfEnemies += 2;
            nowTheEnemies = numberOfEnemies;
            waveNumber++;
            WaveText.text = "" + waveNumber;
            if (waveNumber <= 2)
            {
                for (int i = 0; i < numberOfEnemies; i++)
                {
                    indexBot = 0;
                    SpawnBot(indexBot);
                }
            }
            else
            {
                if (waveNumber == 3)
                {
                    for (int i = 0; i < numberOfEnemies; i++)
                    {
                        indexBot = Random.Range(0, 3);
                        if (indexBot < 3) indexBot = 0;
                        if (indexBot == 3) indexBot = 1;
                        SpawnBot(indexBot);
                    }
                }
                else
                {
                    if (waveNumber <= 5)
                    {
                        for (int i = 0; i < numberOfEnemies; i++)
                        {
                            indexBot = Random.Range(0, 3);
                            if (indexBot < 2) indexBot = 0;
                            if (indexBot >= 2) indexBot = 1;
                            SpawnBot(indexBot);
                        }
                    }
                }
            }
        }
    }

    private void SpawnBot(int indexBot)
    {
        Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        switch (indexBot)
        {
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