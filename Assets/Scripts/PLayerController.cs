using UnityEngine;

public class PLayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 15f;
    private Rigidbody2D rb;

    private void Awake()
    {
        // Ensure the Rigidbody2D component is present
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D component not found on this GameObject.");
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Handle player movement input
        HandleMovement();
        // Handle player jump input
        HandleJump();
    }
    // FixedUpdate is called at a fixed interval and is used for physics calculations
    private void HandleMovement()
    {
        // Get input from the horizontal and vertical axes
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
        if (moveInput > 0) transform.localScale = new Vector3(1, 1, 1);
        else if (moveInput < 0) transform.localScale = new Vector3(-1, 1, 1);
    }
    private void HandleJump()
    {
        if(Input.GetButtonDown("Jump"))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }
}
