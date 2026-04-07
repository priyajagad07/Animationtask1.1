using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpForce = 8f;
    public float moveSpeed = 2f;
    public float fallThreshold = -3f;
    private Rigidbody2D rb;
    public FixedJoystick joystick;
    private bool isGrounded;
    private int jumpCount = 0;
    public int maxJumps = 2;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (MobileInput.jumpPressed && jumpCount < maxJumps)
        {
            Jump();
            MobileInput.jumpPressed = false;
        }

        if (transform.position.y < fallThreshold)
        {
            GameManager.instance.GameOver(this);
        }
    }

    void FixedUpdate()
    {

        //float speed = GameManager.instance.currentSpeed;
        //rb.linearVelocity = new Vector2(moveSpeed, rb.linearVelocity.y);
        float move = joystick.Horizontal * moveSpeed;
        rb.linearVelocity = new Vector2(move, rb.linearVelocity.y);
        Debug.Log("Speed: " + moveSpeed);
    }

    void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0.0f);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        jumpCount++;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            jumpCount = 0;

            BuildingSpawner.instance.OnPlayerLanded();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}