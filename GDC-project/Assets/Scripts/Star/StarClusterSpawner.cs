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

    private void Awake()
    {
        player = FindObjectOfType<PlayerScript>().transform;
        starsParent = GameObject.FindWithTag("Stars").transform;
    }

    private void Start()
    {
        transform.position = new Vector3(0, player.position.y + starClusterHeight/2,0);
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
        Instantiate(starCluster, transform.position, Quaternion.identity, starsParent);
    }
}
