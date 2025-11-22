using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject obstaclePrefab;
    public GameObject shieldPrefab;
    public GameObject speedBoostPrefab;
    public GameObject coinPrefab;  // Coin prefab

    [Header("Spawn Settings")]
    public float minSpawnTime = 0.8f;       // Minimum time between spawns
    public float maxSpawnTime = 1.5f;       // Maximum time between spawns
    public float spawnDistanceAhead = 10f;  // Distance ahead of player
    public float minDistanceBetweenObjects = 3f;

    [Header("Spawn Y Ranges")]
    public float obstacleYMin = -2f;
    public float obstacleYMax = -1f;
    public float shieldYMin = 0.5f;
    public float shieldYMax = 2f;
    public float speedBoostYMin = 1f;
    public float speedBoostYMax = 2.5f;
    public float coinYMin = 0.5f;
    public float coinYMax = 2f;

    [Header("Player Reference")]
    public Transform player;  

    private float lastSpawnX = 0f;

    private void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    private IEnumerator SpawnLoop()
    {
        while (true)
        {
            // Wait for a random interval
            float waitTime = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(waitTime);

            // Decide which object to spawn
            float rand = Random.value;

            GameObject prefabToSpawn = null;
            float yPos = 0f;

            // Probabilities: Obstacle 40%, Shield 10%, SpeedBoost 10%, Coin 40%
if (rand < 0.4f)            // 0.0 – 0.4 → 40% Obstacle
{
    prefabToSpawn = obstaclePrefab;
    yPos = Random.Range(obstacleYMin, obstacleYMax);
}
else if (rand < 0.5f)       // 0.4 – 0.5 → 10% Shield
{
    prefabToSpawn = shieldPrefab;
    yPos = Random.Range(shieldYMin, shieldYMax);
}
else if (rand < 0.6f)       // 0.5 – 0.6 → 10% SpeedBoost
{
    prefabToSpawn = speedBoostPrefab;
    yPos = Random.Range(speedBoostYMin, speedBoostYMax);
}
else                        // 0.6 – 1.0 → 40% Coin
{
    prefabToSpawn = coinPrefab;
    yPos = Random.Range(coinYMin, coinYMax);
}


            // Calculate spawn X with minimum spacing
            float spawnX = player.position.x + spawnDistanceAhead;
            if (spawnX - lastSpawnX < minDistanceBetweenObjects)
                spawnX = lastSpawnX + minDistanceBetweenObjects;

            lastSpawnX = spawnX;

            // Spawn the object
            SpawnObjectAtPosition(prefabToSpawn, spawnX, yPos);
        }
    }

    private void SpawnObjectAtPosition(GameObject prefab, float xPos, float yPos)
    {
        Vector3 spawnPos = new Vector3(xPos, yPos, 0f);
        Instantiate(prefab, spawnPos, Quaternion.identity);
    }
}
