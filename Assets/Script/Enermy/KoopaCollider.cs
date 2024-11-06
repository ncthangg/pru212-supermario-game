using System.Collections;
using UnityEngine;

public class KoopaCollision : MonoBehaviour
{
    public Animator Animator;
    public float bounceForce = 10f;   // Lực nảy của Player khi nhảy lên đầu Koopa
    public bool isShell = false;      // Trạng thái shell
    public float shellSpeed = 5f;     // Tốc độ của shell
    public float shellLifetime = 5f;  // Thời gian tồn tại của shell trước khi biến mất
    private bool canCollide = true;

    private KoopaMovement koopaMovement;
    private Rigidbody2D rb;


    public void OnHeadJump(GameObject collision)
    {
        if (!isShell)
        {
            PlayerBounce(collision.gameObject);
            EnterShell();
        }
        else
        {
            Rigidbody2D playerRb = collision.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                rb.isKinematic = false;  // Kích hoạt vật lý trở lại
                rb.velocity = new Vector2(shellSpeed * Mathf.Sign(playerRb.velocity.x), rb.velocity.y); // Di chuyển shell theo hướng của player
            }
        }
        StartCoroutine(CollisionCooldown());
    }


    void PlayerBounce(GameObject player)
    {
        Rigidbody2D playerRb = player.GetComponent<Rigidbody2D>();
        if (playerRb != null)
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x, bounceForce);
        }
    }

    void EnterShell()
    {
        isShell = true;
        Animator.SetBool("IsShell", true);

        // Ngừng di chuyển Koopa
        KoopaMovement koopaMovement = GetComponent<KoopaMovement>();
        if (koopaMovement != null)
        {
            koopaMovement.enabled = false;
        }

        KoopaAttak koopaAtt = GetComponent<KoopaAttak>();
        koopaAtt.enabled = false;

        // Tạm dừng tất cả các tác động vật lý của Koopa
        rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.zero;  // Dừng chuyển động ngay lập tức
            rb.isKinematic = false;       // Ngừng vật lý tạm thời để Koopa không bị rơi
        }

        // Shell sẽ biến mất sau một thời gian
        Invoke(nameof(DestroyBot), shellLifetime);
    }


    void DestroyBot()
    {
        Destroy(gameObject);
    }

    private IEnumerator CollisionCooldown()
    {
        canCollide = false; // Đặt cờ không cho phép va chạm
        yield return new WaitForSeconds(2f); // Chờ 2 giây
        canCollide = true; // Cho phép va chạm trở lại
    }
}
