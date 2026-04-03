using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;

    public void SpawnCoins(GameObject building)
    {
        Building points = building.GetComponent<Building>();

        if(points.coinsParent == null)
        {
            Debug.Log("No coin points found");
        } 

        foreach (Transform coinpoint in points.coinsParent)
        {
            GameObject coin = Instantiate(coinPrefab, coinpoint.position, Quaternion.identity);
            coin.transform.SetParent(building.transform);
        }
    }
}