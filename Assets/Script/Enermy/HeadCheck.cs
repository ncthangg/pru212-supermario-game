using UnityEngine;

public class HeadCheck : MonoBehaviour
{
    private KoopaCollision koopaCollision;

    void Start()
    {
        koopaCollision = GetComponentInParent<KoopaCollision>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Tính toán hướng va chạm giữa Player và HeadCheck
            Vector2 direction = collision.transform.position - transform.position;

            // Thêm kiểm tra direction.y để xác định Player có thực sự nhảy lên đầu không
            if (direction.y > 0 && Mathf.Abs(direction.x) < 0.5f)
            {
                koopaCollision.OnHeadJump(collision.gameObject); 
            }
        }
    }


}
