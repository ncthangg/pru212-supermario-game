using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private AudioClip walkSound;
    [SerializeField] private AudioClip jumpSound;

    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;
    private AudioSource audioSource;
    private Coroutine walkCoroutine;

    private void Awake()
    {
        // Grab references for Rigidbody2D, Animator, and AudioSource from object
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

        // Play walking sound effect
        if (horizontalInput != 0 && grounded)
        {
            if (walkCoroutine == null)
            {
                walkCoroutine = StartCoroutine(PlayWalkingSound());
            }
        }
        else
        {
            if (walkCoroutine != null)
            {
                StopCoroutine(walkCoroutine);
                walkCoroutine = null;
            }
        }

        // Jumping
        if (Input.GetKey(KeyCode.W) && grounded)
        {
            Jump();
        }

        // Set animator parameters
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", grounded);
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, 15f);
        anim.SetTrigger("jump");
        PlayJumpSound();
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            grounded = true;
    }

    private IEnumerator PlayWalkingSound()
    {
        while (true)
        {
            audioSource.PlayOneShot(walkSound);
            yield return new WaitForSeconds(1f); // Play sound every 1 second
        }
    }

    private void PlayJumpSound()
    {
        audioSource.PlayOneShot(jumpSound);
    }
}
