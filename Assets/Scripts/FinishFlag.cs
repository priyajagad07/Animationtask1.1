using UnityEngine;

public class FinishFlag : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Triggered with: " + collision.name);
        
        if (collision.CompareTag("Player"))
        {
            GameManager.instance.LevelCompleted();
        }
    }
}
