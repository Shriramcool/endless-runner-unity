using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 3f;         
    public float jumpForce = 16f;

    [Header("Speed Increase")]
    public float speedIncreaseRate = 0.01f;   
    public float maxSpeed = 5f;               

    [Header("Ground Check")]
    public Transform groundCheckPoint;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    [HideInInspector] public bool hasShield = false;
    [HideInInspector] public bool speedBoostActive = false;
    public float speedBoostAmount = 4f;
    public float speedBoostDuration = 3f;

    private Rigidbody2D rb;
    private bool isGrounded = false;

    public Transform spawnPoint;  // assign PlayerSpawnPoint in inspector

private void Start()
{
    if (spawnPoint != null)
        transform.position = spawnPoint.position;
}

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);
        DebugDrawGroundCheck();

        rb.linearVelocity = new Vector2(moveSpeed, rb.linearVelocity.y);
    }

    private void Update()
    {
        moveSpeed += speedIncreaseRate * Time.deltaTime;
        moveSpeed = Mathf.Clamp(moveSpeed, 1f, maxSpeed);

        if (Input.GetButtonDown("Jump"))
            TryJump();
    }

    public void JumpButtonPressed()
    {
        TryJump();
    }

    private void TryJump()
    {
        if (isGrounded)
            rb.linearVelocity = new Vector2(moveSpeed + 4f, jumpForce);
    }

    public void ActivateSpeedBoost(float extraSpeed, float duration)
    {
        if (speedBoostActive) return;

        speedBoostActive = true;
        moveSpeed += extraSpeed;
        Invoke(nameof(DeactivateSpeedBoost), duration);
    }

    private void DeactivateSpeedBoost()
    {
        moveSpeed -= speedBoostAmount;
        speedBoostActive = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Obstacle"))
        {
            if (hasShield)
            {
                hasShield = false;
                Transform shieldVisual = transform.Find("ShieldVisual");
                if (shieldVisual != null)
                    shieldVisual.GetComponent<SpriteRenderer>().enabled = false;
                Destroy(collision.gameObject);
            }
            else
            {
                if (GameManager.Instance != null)
                    GameManager.Instance.GameOver();
                else
                    Time.timeScale = 0f;
            }
        }
    }

    private void DebugDrawGroundCheck()
    {
        if (groundCheckPoint != null)
        {
            Color color = isGrounded ? Color.green : Color.red;
            Debug.DrawLine(groundCheckPoint.position, groundCheckPoint.position + Vector3.down * groundCheckRadius, color);
            Debug.DrawRay(groundCheckPoint.position, Vector3.right * 0.5f, Color.blue);
        }
    }
}
