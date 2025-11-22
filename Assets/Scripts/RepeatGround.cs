using UnityEngine;

public class RepeatGround : MonoBehaviour
{
    public float groundLength = 20f;  // Same as your ground scale X
    public float moveSpeed = 5f;      // We will sync this with player speed

    private Transform player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        // Move ground left based on player speed (infinite world effect)
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);

        // Check if ground is completely behind player
        if (transform.position.x < player.position.x - groundLength)
        {
            // Move it ahead to continue the loop
            transform.position = new Vector3(
                transform.position.x + groundLength * 2f,
                transform.position.y,
                transform.position.z
            );
        }
    }
}
