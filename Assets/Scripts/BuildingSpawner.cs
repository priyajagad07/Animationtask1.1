using System.Collections.Generic;
using UnityEngine;

public class BuildingSpawner : MonoBehaviour
{
    public GameObject[] buildingPrefabs;
    public Transform player;
    public Transform lastBuilding;
    public CoinSpawner coinSpawner;

    public float spawnDistance = 10f;
    public float minGap = 1.2f;
    public float maxGap = 2f;
    public float destroyDitsance = 15f;

    public float rightEdge;

    public static BuildingSpawner instance;
    private List<GameObject> spawnedBuildings = new List<GameObject>();

    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        Building building = lastBuilding.GetComponent<Building>();
        rightEdge = lastBuilding.position.x + (building.width / 2f);

        spawnedBuildings.Add(lastBuilding.gameObject);
    }

    public void OnPlayerLanded()
    {
        if (player.position.x + spawnDistance > rightEdge)
        {
            SpawnBuilding();
            DestroyOldBuildings();
        }
    }

    void SpawnBuilding()
    {
        GameObject prefab = buildingPrefabs[Random.Range(0, buildingPrefabs.Length)];
        GameObject newBuilding = Instantiate(prefab);
        Building building = newBuilding.GetComponent<Building>();

        float gap = Random.Range(minGap, maxGap);

        float spawnX = rightEdge + gap + (building.width / 2f);
        newBuilding.transform.position = new Vector3(spawnX, 0, 0);

        rightEdge = spawnX + (building.width / 2f);

        coinSpawner.SpawnCoins(newBuilding);

        spawnedBuildings.Add(newBuilding);
    }
        
    void DestroyOldBuildings()
    {
        for (int i = 0; i < spawnedBuildings.Count; i++)
        {
            GameObject buildings = spawnedBuildings[i];

            if (buildings == null)
            {
                continue;
            }

            Building b = buildings.GetComponent<Building>();

            float buildingRight = buildings.transform.position.x + (b.width / 2f);

            if (player.position.x - buildingRight > destroyDitsance)
            {
                Destroy(buildings);
                spawnedBuildings.RemoveAt(i);
                i--;
                Debug.Log("Building Destroy");
            }
        }
    }        
}