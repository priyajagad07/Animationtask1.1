using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    public void SpawnEnemey(GameObject building)
    {
        Building b = building.GetComponent<Building>();

        if(b.enemyPoint == null)
        {
            Debug.Log("Enemy point is null");
            return;
        }

        GameObject enemy = Instantiate(enemyPrefab, b.enemyPoint.position, Quaternion.identity);
        enemy.transform.SetParent(building.transform);
    }
}
