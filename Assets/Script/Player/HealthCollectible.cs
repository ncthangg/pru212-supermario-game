using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    [SerializeField] private float healthValue;  // Giá trị máu được cộng khi nhặt
    private Collider2D col;                     // Collider của cục máu

    private void Start()
    {
        // Lấy Collider2D của cục máu
        col = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Kiểm tra nếu đối tượng va chạm là Player
        if (collision.CompareTag("Player"))
        {
            // Thêm máu cho người chơi
            collision.GetComponent<Health>().AddHealth(healthValue);

            // Xóa Collider để cục máu không còn tương tác
            if (col != null)
            {
                Destroy(col);  // Xóa collider
            }

            // Ẩn cục máu hoặc có thể dùng gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
