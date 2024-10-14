using System.Collections;
using UnityEngine;

public class GoombaCollision : MonoBehaviour
{
    public Animator Animator;
    public float bounceForce = 10f;
    private bool isDead = false;
    bool Dead = false;
    private GoombaCollision goombaCollision;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Tính hướng từ quái đến Player
            Vector2 direction = collision.transform.position - transform.position;

            // Kiểm tra xem Player có rơi từ trên xuống không (tức là hướng đi xuống)
            if (direction.y > 0 && Mathf.Abs(direction.x) < 0.5f) // Kiểm tra chiều dọc và chiều ngang
            {
                PlayerBounce(collision.gameObject);
                BotDie();
            }
            else
            {
                // Nếu không phải va chạm từ trên xuống thì trừ máu của Player
                Health health = collision.gameObject.GetComponent<Health>();
                if (health != null)
                {
                    health.TakeDamage(1); // Giảm máu của Player
                }
            }
        }
    }

    void PlayerBounce(GameObject player)
    {
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = new Vector2(rb.velocity.x, bounceForce);
        }
    }

    void BotDie()
    {
        Dead = true;
        Animator.SetBool("IsDie", true);

        GoombaCollision botMovement = GetComponent<GoombaCollision>();
        if (botMovement != null)
        {
            botMovement.isDead = true;  // Ngừng di chuyển
        }

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.zero;
            rb.isKinematic = true;
        }
        Destroy(gameObject, 0.3f);
    }


}


