using UnityEngine;


public class PlayerMovement2D : MonoBehaviour
{
    public Animator anima;

    [Header("Movement")]
    public float moveSpeed = 5f;
    public float jumpForce = 12f;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool isGrounded;
    private float moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get left/right input
        moveInput = Input.GetAxisRaw("Horizontal");
        if (moveInput > 0)
        {
            anima.SetBool("RUN", true);
            transform.localScale = new Vector3(0.8f, 0.8f, 1f);
        }
        if (moveInput < 0)
        {
            anima.SetBool("RUN", true);
            transform.localScale = new Vector3(-0.8f, 0.8f, 1f);
        }
        if (moveInput == 0)
        {
            anima.SetBool("RUN", false);
            
        }

        // Jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);

        }
    }

    void FixedUpdate()
    {
        // Apply movement
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        // Check if grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    void OnDrawGizmosSelected()
    {
        // Draw ground check circle in Scene view
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}
