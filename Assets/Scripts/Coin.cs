using UnityEngine;

public class Coin : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CoinManager.instance.AddCoins(1);
            Debug.Log("Coin destroyed");
            Destroy(gameObject);
        }
    }
}
