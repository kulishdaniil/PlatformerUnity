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

    public static int numberOfEnemies = 2;
    public int nowTheEnemies = 0;

    public static int waveNumber = 0;
    private int indexBot;
    private float timer = 0;

    public static bool saveWave = false;

    private void Update()
    {
        
        timer += Time.deltaTime;
        if (timer > 2)
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
            if (waveNumber>5)
            {
                Time.timeScale = 1f;
                SceneManager.LoadScene("Menu");
                waveNumber = 0;
                numberOfEnemies = 2;
            }

            if (saveWave)
            {
                waveNumber--;
                numberOfEnemies -= 2;
                if (waveNumber == 0)
                {
                    waveNumber++;
                    numberOfEnemies += 2;
                }
                saveWave = false;
            }

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
                    indexBot = 0;
                    for (int i = 0; i < numberOfEnemies; i++)
                    {
                        if (i == numberOfEnemies-1) indexBot = 1;
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