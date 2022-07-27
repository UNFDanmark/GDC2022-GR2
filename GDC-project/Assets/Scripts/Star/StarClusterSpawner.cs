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
        
    }

    void SpawnStarcluster()
    {
        GameObject starCluster = starClusters[Random.Range(0, starClusters.Count)];
        Instantiate(starCluster, new Vector3(0,0,0), Quaternion.identity);
    }

    void SpawnStartCluster(int index)
    {
        GameObject starCluster = starClusters[index];
        Instantiate(starCluster, player.position + new Vector3(0, firstClusterSpawnHeight, 0), Quaternion.identity, starsParent);
    }
}
