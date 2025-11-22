using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{
    public float duration = 3f; // default power-up duration

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ApplyEffect(collision.gameObject);
            gameObject.SetActive(false); // hide power-up
            Destroy(gameObject, 0.1f);   // remove from scene
        }
    }

    public abstract void ApplyEffect(GameObject player);
}
