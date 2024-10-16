using System.Collections;
using UnityEngine;

public class BlockHit : MonoBehaviour
{
    public GameObject heartPrefab; // Prefab của trái tim sẽ xuất hiện
    public Sprite emptyBlock;      // Hình ảnh của block khi đã bị đánh
    public int maxHits = 1;        // Số lần có thể hit block, -1 để vô hạn
    private bool animating;        // Kiểm tra block có đang di chuyển không
    private bool isUsed = false;   // Trạng thái của block, đã dùng hay chưa

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!animating && maxHits != 0 && collision.gameObject.CompareTag("Player") && !isUsed)
        {
            // Lấy hướng va chạm từ contact point
            ContactPoint2D contact = collision.GetContact(0);
            Vector2 collisionDirection = contact.normal;

            // Kiểm tra xem người chơi có va chạm từ phía dưới không
            if (Vector2.Dot(collisionDirection, Vector2.up) > 0.5f)
            {
                Hit();  // Gọi hàm hit khi va chạm từ phía dưới
            }
        }
    }

    private void Hit()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        maxHits--;

        // Nếu maxHits là 0, đổi sprite sang emptyBlock
        if (maxHits == 0)
        {
            spriteRenderer.sprite = emptyBlock;
            isUsed = true; // Đánh dấu block đã được sử dụng
        }

        // Tạo ra trái tim khi hit block
        if (heartPrefab != null)
        {
            GameObject heart = Instantiate(heartPrefab, transform.position + Vector3.up, Quaternion.identity);
            Rigidbody2D heartRb = heart.GetComponent<Rigidbody2D>();

            if (heartRb != null)
            {
                heartRb.gravityScale = 1f;  // Đặt gravity để trái tim rơi xuống
            }
        }

        StartCoroutine(Animate()); // Chạy hoạt ảnh di chuyển của block
    }

    private IEnumerator Animate()
    {
        animating = true;

        Vector3 restingPosition = transform.localPosition;
        Vector3 animatedPosition = restingPosition + Vector3.up * 0.5f;

        yield return Move(restingPosition, animatedPosition);
        yield return Move(animatedPosition, restingPosition);

        animating = false;
    }

    private IEnumerator Move(Vector3 from, Vector3 to)
    {
        float elapsed = 0f;
        float duration = 0.125f;

        while (elapsed < duration)
        {
            float t = elapsed / duration;
            transform.localPosition = Vector3.Lerp(from, to, t);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = to;
    }
}
