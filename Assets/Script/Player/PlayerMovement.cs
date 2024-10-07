using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;
    private AudioSource audioSource;
    private Coroutine runningSoundCoroutine;

    public AudioClip jumpClip;
    public AudioClip runClip;


    private void Awake()
    {
        //Grab references for rigidbody and animator from object
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);

        //Flip charater when moving left-right
        if (horizontalInput > 0.01f && grounded && runningSoundCoroutine == null)
        {
            transform.localScale = new Vector3(3, 3, 3);
            runningSoundCoroutine = StartCoroutine(PlayRunningSound());
        }
        else if (horizontalInput < -0.01f && grounded && runningSoundCoroutine == null)
        {
            transform.localScale = new Vector3(-3, 3, 3);
            runningSoundCoroutine = StartCoroutine(PlayRunningSound());
        }
        else if (horizontalInput == 0 && runningSoundCoroutine != null)
        {
            StopCoroutine(runningSoundCoroutine);
            runningSoundCoroutine = null;
            audioSource.Stop();
        }
        //Jumping 
        if (Input.GetKey(KeyCode.W) && grounded)
        {
            Jump();
            
        }

        //Set animator parameter
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", grounded);
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, 5.5f);
        grounded = false;
        PlaySound(jumpClip);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            grounded = true;
    }

    private void PlaySound(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }

    private IEnumerator PlayRunningSound()
    {
        while (true)
        {
            PlaySound(runClip);
            yield return new WaitForSeconds(1f); // Play every 1 second
        }
    }
}