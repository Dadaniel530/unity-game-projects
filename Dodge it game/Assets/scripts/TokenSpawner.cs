using UnityEngine;

public class TokenSpawner : MonoBehaviour
{
    public GameObject clockPrefab;
    public bool clockSpawned = false;
    public float clockSpawnDelay = 10f;

    public GameObject goodTokenPrefab;
    public GameObject badTokenPrefab;
    public Transform player;

    public GameObject shieldPrefab;
    private bool shieldSpawned = false;
    public float shieldSpawnDelay = 15f;


    public float spawnInterval = 2f;
    public float spawnRadius = 6f;   // how far from player
    public float spawnHeight = 1f;   // Y height of tokens

    void Start()
    {
        Invoke(nameof(SpawnShield), shieldSpawnDelay);

        InvokeRepeating(nameof(SpawnToken), 1f, spawnInterval);
        Invoke(nameof(SpawnClock), clockSpawnDelay);
    }
    void SpawnClock()
    {
        if (clockSpawned || player == null) return;

        // Smaller radius so clock spawns closer
        float minRadius = 1.5f;
        float maxRadius = 3f;

        Vector2 offset = Random.insideUnitCircle.normalized * Random.Range(minRadius, maxRadius);

        Vector3 spawnPos = new Vector3(
            player.position.x + offset.x,
            1f,
            player.position.z + offset.y
        );

        Instantiate(clockPrefab, spawnPos, Quaternion.identity);
        clockSpawned = true;
    }

    void SpawnShield()
    {
        if (shieldSpawned || player == null) return;

        float minRadius = 1.5f;
        float maxRadius = 3f;

        Vector2 offset = Random.insideUnitCircle.normalized * Random.Range(minRadius, maxRadius);

        Vector3 spawnPos = new Vector3(
            player.position.x + offset.x,
            1f,
            player.position.z + offset.y
        );

        Instantiate(shieldPrefab, spawnPos, Quaternion.identity);
        shieldSpawned = true;
    }


    void SpawnToken()
    {
        if (player == null) return;

        // Random point around player
        Vector2 randomCircle = Random.insideUnitCircle.normalized * Random.Range(2f, spawnRadius);

        Vector3 spawnPos = new Vector3(
            player.position.x + randomCircle.x,
            spawnHeight,
            player.position.z + randomCircle.y
        );

        int roll = Random.Range(0, 100);

        if (roll < 70)
        {
            Instantiate(goodTokenPrefab, spawnPos, Quaternion.identity);
        }
        else
        {
            Instantiate(badTokenPrefab, spawnPos, Quaternion.identity);
        }
    }
}
