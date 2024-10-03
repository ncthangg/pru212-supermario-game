using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private LayerMask groundLayer;
    private Rigidbody2D body;
    private BoxCollider2D boxCollider;
    private void Awake()
    {
        //Grab references for rigidbody and animator from object
        body = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);

        //Flip charater when moving left-right
        if (horizontalInput > 0.01f)
        {
            transform.localScale = new Vector3(3, 3, 3);
        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-3, 3, 3);
        }

        //Jumping 
        if (Input.GetKey(KeyCode.W) && isGrounded())
        {
            Jump();
        }

    }
    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, 5.5f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }
}
