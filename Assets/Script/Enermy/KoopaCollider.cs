using UnityEngine;

public class KoopaCollision : MonoBehaviour
{
    public Animator Animator;
    public float bounceForce = 10f;   // Lực nảy của Player khi nhảy lên đầu Koopa
    public bool isShell = false;      // Trạng thái shell
    public float shellSpeed = 5f;     // Tốc độ của shell
    public float shellLifetime = 5f;  // Thời gian tồn tại của shell trước khi biến mất

    private KoopaMovement koopaMovement;
    private Rigidbody2D rb;

    void Start()
    {
        koopaMovement = GetComponent<KoopaMovement>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Hàm được gọi khi nhảy lên đầu Koopa
    public void OnHeadJump(GameObject player)
    {
        if (!isShell)  
        {
            PlayerBounce(player); 
            EnterShell();     
        }
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
        Debug.Log("Koopa chuyển sang trạng thái shell");
        isShell = true;

        // Ngừng di chuyển Koopa
        if (koopaMovement != null)
        {
            koopaMovement.isShell = true;  // Thay đổi trạng thái trong KoopaMovement
        }

        // Kích hoạt chuyển đổi hoạt ảnh sang shell
        if (Animator != null)
        {
            Animator.SetBool("IsShell", true);
        }

        // Tạm dừng tất cả các tác động vật lý của Koopa
        if (rb != null)
        {
            rb.velocity = Vector2.zero;  // Dừng chuyển động
            rb.isKinematic = true;       // Ngừng vật lý tạm thời
        }

        // Shell sẽ biến mất sau một thời gian
        Invoke(nameof(DestroyBot), shellLifetime);
    }


    // Hủy đối tượng Koopa sau một khoảng thời gian
    void DestroyBot()
    {
        Destroy(gameObject);
    }
}
