using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [Header("Spawner Settings")]
    public GameObject obstaclePrefab;
    public float spawnInterval = 1.5f;
    public float minY = -2.8f;
    public float maxY = -2.0f;

    private float timer = 0f;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnObstacle();
            timer = 0f;
        }
    }

    private void SpawnObstacle()
    {
        float randomY = Random.Range(minY, maxY);

        Vector3 spawnPos = new Vector3(transform.position.x, randomY, 0);
        Instantiate(obstaclePrefab, spawnPos, Quaternion.identity);
    }
}
