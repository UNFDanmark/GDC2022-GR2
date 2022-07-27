using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarClusterSpawner : MonoBehaviour
{
    public List<GameObject> starClusters;
    Transform player;
    Transform starsParent;

    public int firstClusterIndex = 0;
    public float starClusterHeight = 100f;
    public float firstClusterSpawnHeight; //Relative to player

    GameObject lastStarCluster;

    private void Awake()
    {
        player = FindObjectOfType<PlayerScript>().transform;
        starsParent = GameObject.FindWithTag("Stars").transform;
    }

    private void Start()
    {
        SpawnStartCluster(firstClusterIndex);
    }

    private void Update()
    {
        if(Mathf.Abs(player.position.y - lastStarCluster.transform.position.y) > starClusterHeight/2)
        {
            SpawnStarcluster();
        }
    }

    void SpawnStarcluster()
    {
        Vector3 spawnPos = lastStarCluster.transform.position + new Vector3(0, starClusterHeight + 5f, 0); 

        GameObject starCluster = starClusters[Random.Range(0, starClusters.Count)];
        lastStarCluster = Instantiate(starCluster, spawnPos, Quaternion.identity);
    }

    void SpawnStartCluster(int index)
    {
        GameObject starCluster = starClusters[index];
        lastStarCluster = Instantiate(starCluster, player.position + new Vector3(0, firstClusterSpawnHeight, 0), Quaternion.identity, starsParent);
    }
}
