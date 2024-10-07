using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Camera playerCam;
    private Rigidbody2D rb;

    private Vector2 velocity;
    private float inputAxis;

    public float moveSpeed = 80f;
    
    //Jump config
    public float maxJumpHeight = 5f;
    public float maxJumpTime = 1f;
    
    public float jumpForce  => (2f * maxJumpHeight) / (maxJumpTime / 2f);
    public float gravity => (-2f * maxJumpHeight) / Mathf.Pow((maxJumpTime / 2f), 2);
    public bool grounded {  get; private set; }
    public bool jumping { get; private set; }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerCam = Camera.main;
    }

    private void Update()
    {
        HorizontalMovement();

        grounded = rb.Raycast(Vector2.down);

        if (grounded)
        {
            GroundedMovement();
        }

        ApplyGravity();
    }

    private void HorizontalMovement()
    {
        inputAxis = Input.GetAxis("Horizontal");
        velocity.x = Mathf.MoveTowards(velocity.x, inputAxis * moveSpeed, moveSpeed * Time.timeScale);
    }

    private void GroundedMovement()
    {
        velocity.y = Mathf.Max(velocity.y, 0f);
        if (Input.GetButtonDown("Jump"))
        {
            jumping = velocity.y > 0f;

            velocity.y = jumpForce;
            jumping = true;
        }
    }

    private void ApplyGravity()
    {
        // Check if falling
        bool falling = velocity.y < 0f || !Input.GetButton("Jump");
        float multiplier = falling ? 2f : 1f;

        // Apply gravity and terminal velocity
        velocity.y += gravity * multiplier * Time.deltaTime;
        velocity.y = Mathf.Max(velocity.y, gravity / 2f);
    }


    private void FixedUpdate()
    {
        Vector2 position = rb.position;
        position += velocity * Time.fixedDeltaTime;

        //Fix can't be out of boundd
        Vector2 leftEdge = playerCam.ScreenToWorldPoint(Vector2.zero);
        Vector2 rightEdge = playerCam.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        position.x = Mathf.Clamp(position.x, leftEdge.x + 0.2f, rightEdge.x + 0.2f);

        rb.MovePosition(position);
    }
}
