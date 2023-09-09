using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ManController : MonoBehaviour
{
    public float moveSpeed = 5.0f; // Speed at which the man moves
    public float jumpForce = 10.0f; // Increased force of the jump
    public LayerMask groundLayer; // Assign the ground layer here in the inspector
    public Transform groundCheckPoint; // Point where we check if the player is grounded
    public float groundCheckRadius = 0.2f; // Radius of the ground check circle

    private Rigidbody2D rb;
    public bool IsGrounded { get; private set; } // Public property to expose grounded status

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        CheckIfGrounded();
        Move();
        Jump();
    }

    private void Move()
    {
        float moveX = Input.GetAxisRaw("Horizontal"); // A/D or Left Arrow/Right Arrow

        Vector2 moveDirection = new Vector2(moveX, 0).normalized;
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, rb.velocity.y);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W) && IsGrounded)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void CheckIfGrounded()
    {
        IsGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);
    }
}
