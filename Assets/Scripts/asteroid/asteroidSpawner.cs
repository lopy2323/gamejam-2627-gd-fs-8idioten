using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class asteroidSpawner : MonoBehaviour
{

    [SerializeField] private float spawnInterval = 2f;
    [SerializeField] private float spawnRadius = 10f;
    [SerializeField] private int maxAsteroids = 10;

    [SerializeField] private GameObject asteroidPrefab;

    public List<GameObject> spawnedAsteroids = new List<GameObject>();

    private void Update()
    {
        spawnInterval -= Time.deltaTime;
        if (spawnInterval <= 0f)
        {
            SpawnAsteroid();
            spawnInterval = UnityEngine.Random.Range(1f, 3f);
        }

    }

    private void SpawnAsteroid()
    {
        if (spawnedAsteroids.Count >= maxAsteroids)
        {
            return;
        }
        Vector2 spawnPosition = UnityEngine.Random.insideUnitCircle.normalized * spawnRadius;
        if (asteroidPrefab != null)
        {
            GameObject newAsteroid = Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);
            newAsteroid.GetComponent<asteroid>().spawner = this;
            spawnedAsteroids.Add(newAsteroid);
        }
    }
}
