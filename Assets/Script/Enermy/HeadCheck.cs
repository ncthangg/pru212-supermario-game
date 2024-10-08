using UnityEngine;

public class HeadCheck : MonoBehaviour
{
    private KoopaCollision koopaCollision;

    void Start()
    {
        // Lấy tham chiếu đến KoopaCollision
        koopaCollision = GetComponentInParent<KoopaCollision>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            Vector2 direction = collision.transform.position - transform.position;

            if (rb != null && direction.y > 0 && Mathf.Abs(direction.x) < 0.5f)
            {
                koopaCollision.OnHeadJump(collision.gameObject); 
            }
        }
    }
}
