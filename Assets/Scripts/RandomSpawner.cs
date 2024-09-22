using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject prefabToSpawn; // The prefab to spawn
    public float minSpawnTime = 1f;  // Minimum time interval between spawns
    public float maxSpawnTime = 3f;  // Maximum time interval between spawns
    public float spawnHeight = 6f;    // Height from which to spawn the prefab

    private float nextSpawnTime;

    void Start()
    {
        // Schedule the first spawn
        ScheduleNextSpawn();
    }

    void Update()
    {
        // Check if it's time to spawn a new prefab
        if (Time.time >= nextSpawnTime)
        {
            SpawnPrefab();
            ScheduleNextSpawn(); // Schedule the next spawn
        }
    }

    void SpawnPrefab()
    {
        // Determine a random horizontal position within the screen bounds
        float randomX = Random.Range(-Camera.main.aspect * Camera.main.orthographicSize, Camera.main.aspect * Camera.main.orthographicSize);

        // Set the spawn position at the top of the screen and random X
        Vector3 spawnPosition = new Vector3(randomX, Camera.main.orthographicSize + spawnHeight, 0);

        // Instantiate the prefab at the calculated spawn position
        Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
    }

    void ScheduleNextSpawn()
    {
        // Set the next spawn time to a random interval
        nextSpawnTime = Time.time + Random.Range(minSpawnTime, maxSpawnTime);
    }
}

