using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    public GameObject[] roadPrefabs;
    public float zSpawn = 0;
    public float roadLength = 8.16f;
    public int numberOfRoad = 6;
    public Transform playerTransform;
    public List<GameObject> activeRoads = new List<GameObject>();

    void Start()
    {
        for(int i = 0; i < numberOfRoad; i++)
        {
            if(i==0)
            {
                SpawnRoad(1);
            }
            else 
            SpawnRoad(Random.Range(0, roadPrefabs.Length));
        }
    }

    private void Update()
    {
        if(playerTransform.position.z-20>zSpawn-(numberOfRoad*roadLength))
        {
            SpawnRoad(Random.Range(0, roadPrefabs.Length));
            DeleteRoad();
        }
    }
    public void SpawnRoad(int roadIndex)
    {
       GameObject go= Instantiate(roadPrefabs[roadIndex], new Vector3(0, 0, zSpawn), Quaternion.identity);
        activeRoads.Add(go);
        zSpawn += roadLength;
    }
    private void DeleteRoad()
    {
        Destroy(activeRoads[0]);
        activeRoads.RemoveAt(0);
    }
}
