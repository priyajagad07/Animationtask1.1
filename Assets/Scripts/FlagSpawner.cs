using UnityEngine;

public class FlagSpawner : MonoBehaviour
{
   
    public GameObject finishFlagPrefab;
  
    public void SpawnFinishFlag()
    {
        GameObject last = BuildingSpawner.instance.spawnedBuildings[BuildingSpawner.instance.spawnedBuildings.Count - 1];

        Building building = last.GetComponent<Building>();

        if (building.flagPoint == null)
        {
            Debug.Log("No flag point");
            return;
        }

        GameObject flag = Instantiate(finishFlagPrefab, building.flagPoint.position, Quaternion.identity);
        flag.transform.SetParent(last.transform);

        Debug.Log("Finish Spawned");
    }
}
