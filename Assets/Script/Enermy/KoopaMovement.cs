using UnityEngine;

public class KoopaMovement : MonoBehaviour
{
    public float speed = 3.0f;
    public bool isShell = false; 

    private bool movingLeft = true;

    void Update()
    {
        if (!isShell) 
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

    void Flip()
    {
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}
