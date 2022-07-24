using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    public float width = 10f;

    float currentSpawnDelay;
    public float minSpawnDelay = 0.5f;
    public float maxSpawnDelay = 1.5f;

    float lastStarSpawn = 0f;

    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        SpawnStar();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - lastStarSpawn >= currentSpawnDelay)
        {
            SpawnStar();
            lastStarSpawn = Time.time;

            currentSpawnDelay = Random.Range(minSpawnDelay, maxSpawnDelay);
        }
    }

    void SpawnStar()
    {
        float xPos = Random.Range(transform.position.x - width / 2, transform.position.x + width / 2);
        Vector3 spawnPos = new Vector3(xPos ,transform.position.y, transform.position.z);
        Instantiate(prefab, spawnPos, Quaternion.identity);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, new Vector3(width, 1, 1));
    }
}
