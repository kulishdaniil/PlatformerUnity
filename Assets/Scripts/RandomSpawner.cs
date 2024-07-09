using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject ammoPrefab; // Префаб патронов
    public GameObject healthPrefab; // Префаб аптечек

    public float spawnInterval = 5f; // Интервал респавна
    public int maxAmmo = 6; // Максимальное количество патронов
    public int maxHealth = 4; // Максимальное количество аптечек

    private float timer = 0f;
    private int currentAmmoCount = 0;
    private int currentHealthCount = 0;

    // Границы области спауна
    private float minX = -52f;
    private float maxX = 31f;
    private float minZ = -54f;
    private float maxZ = 42f;
    private float y = 0.6f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            currentAmmoCount = GameObject.FindGameObjectsWithTag("BulletBox").Length;
            currentHealthCount = GameObject.FindGameObjectsWithTag("HealthBox").Length;
            SpawnItem();
            timer = 0f;
        }
    }

    void SpawnItem()
    {
        GameObject itemToSpawn = null;

        if (currentAmmoCount < maxAmmo && currentHealthCount < maxHealth)
        {
            itemToSpawn = (Random.value > 0.5f) ? ammoPrefab : healthPrefab;
        }
        else if (currentAmmoCount < maxAmmo)
        {
            itemToSpawn = ammoPrefab;
        }
        else if (currentHealthCount < maxHealth)
        {
            itemToSpawn = healthPrefab;
        }

        if (itemToSpawn != null)
        {
            float x = Random.Range(minX, maxX);
            float z = Random.Range(minZ, maxZ);
            Vector3 spawnPosition = new Vector3(x, y, z);

            Instantiate(itemToSpawn, spawnPosition, Quaternion.identity);
        }
    }
}