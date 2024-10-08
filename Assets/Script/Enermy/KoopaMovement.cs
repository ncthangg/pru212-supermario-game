using UnityEngine;

public class KoopaMovement : MonoBehaviour
{
    public float speed = 3.0f;
    public bool isShell = false;
    public bool isKicked = false;
    private bool movingLeft = true;
    private bool facingRight = true;

    void Update()
    {
        if (!isShell ) 
        {
            if (movingLeft)
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
        }
        }
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isShell) 
        {
            if (collision.gameObject.CompareTag("Player") == false)
            {
                movingLeft = !movingLeft;
                Flip();
            }
        }
    }
    void KickKoopa(Collision2D collision)
    {
        isKicked = true;

        if (collision.transform.position.x > transform.position.x)
        {
            facingRight = false;
        }
        else
        {
            facingRight = true;
        }

        Destroy(gameObject, 3f);
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }


}
