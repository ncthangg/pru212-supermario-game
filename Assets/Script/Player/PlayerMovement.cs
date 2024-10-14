using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private AudioClip walkSound;
    [SerializeField] private AudioClip jumpSound;
    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;
    private AudioSource audioSource;

    private void Awake()
    {
        // Grab references for rigidbody, animator, and audio source from the object
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        // Flip character when moving left-right
        if (horizontalInput > 0.01f)
        {
            transform.localScale = new Vector3(3, 3, 3);
        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-3, 3, 3);
        }

        // Jumping
        if (Input.GetKey(KeyCode.W) && grounded)
        {
            Jump();
        }

        // Set animator parameter
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", grounded);
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, 15f);
        anim.SetTrigger("jump");
        audioSource.PlayOneShot(jumpSound); // Play jump sound effect
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            grounded = true;
    }

    public void PlayFootstepSound()
    {
        if (grounded)
        {
            audioSource.PlayOneShot(walkSound); // Play walking sound effect
        }
    }
}
