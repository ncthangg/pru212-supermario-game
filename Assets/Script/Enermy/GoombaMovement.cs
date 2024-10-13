using System.Collections;
using UnityEngine;

public class BotMovement : MonoBehaviour
{
    public float speed = 3.0f;
    private bool movingLeft = true;
    private bool facingRight = true;
    public bool isDead = false;

    void Update()
    {
        if (!isDead)
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

        // if (!isDead && collision.gameObject.CompareTag("Player") == false)
        // {
        //     movingLeft = !movingLeft;
        //     Flip();
        // }else{

        // }
        movingLeft = !movingLeft;
        Flip();
    }

    // Hàm lật đối tượng 
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}