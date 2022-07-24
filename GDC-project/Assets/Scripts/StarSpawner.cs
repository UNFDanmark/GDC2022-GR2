using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    public float width = 10f;
    public float startSpawnHeight = 10f;
    public float startSpawnHeightOffset;

    float currentSpawnDelay;
    public float minSpawnDelay = 0.5f;
    public float maxSpawnDelay = 1.5f;

    public int startStarAmount = 4;

    float lastStarSpawn = 0f;

    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < startStarAmount; i++)
        {
            float minY = transform.position.y + startSpawnHeightOffset - startSpawnHeight / 2;
            float maxY = transform.position.y + startSpawnHeightOffset + startSpawnHeight / 2;
            SpawnStar(Random.Range(minY, maxY));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - lastStarSpawn >= currentSpawnDelay)
        {
            SpawnStar(transform.position.y);
            lastStarSpawn = Time.time;

            currentSpawnDelay = Random.Range(minSpawnDelay, maxSpawnDelay);
        }
    }

    void SpawnStar(float yPos)
    {
        float xPos = Random.Range(transform.position.x - width / 2, transform.position.x + width / 2);
        Vector3 spawnPos = new Vector3(xPos , yPos, transform.position.z);
        Instantiate(prefab, spawnPos, Quaternion.identity);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, new Vector3(width, 1, 1));
        Gizmos.color = Color.green;
        Vector3 boxPos = new Vector3(transform.position.x, transform.position.y + startSpawnHeightOffset, transform.position.z);
        Vector3 boxSize = new Vector3(width, startSpawnHeight, 1);
        Gizmos.DrawWireCube(boxPos, boxSize);
    }
}
