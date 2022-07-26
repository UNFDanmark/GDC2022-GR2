using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarClusterSpawner : MonoBehaviour
{
    public List<GameObject> starClusters;

    public int firstClusterIndex = 0;

    private void Start()
    {
        SpawnStarcluster(firstClusterIndex);
    }

    private void Update()
    {
        
    }

    void SpawnStarcluster()
    {
        GameObject starCluster = starClusters[Random.Range(0, starClusters.Count)];
        Instantiate(starCluster, new Vector3(0,0,0), Quaternion.identity);
    }

    void SpawnStarcluster(int index)
    {
        GameObject starCluster = starClusters[index];
        Instantiate(starCluster, new Vector3(0, 0, 0), Quaternion.identity);
    }
}
