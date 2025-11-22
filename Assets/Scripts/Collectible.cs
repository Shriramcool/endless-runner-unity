using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int value = 1; // Points for this coin

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ScoreManager.Instance.AddScore(value); // Add points
            Destroy(gameObject); // Remove coin
        }
    }
}
