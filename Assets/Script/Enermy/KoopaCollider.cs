using UnityEngine;

public class KoopaCollision : MonoBehaviour
{
    public Animator Animator;
    public float bounceForce = 10f;  
    public bool isDead = false;      
    public bool isShell = false;     
    public float shellLifetime = 5f; 

    private KoopaMovement koopaMovement;

    void Start()
    {
        koopaMovement = GetComponent<KoopaMovement>();
    }

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
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = new Vector2(rb.velocity.x, bounceForce);
        }
    }

    void EnterShell()
    {
        isShell = true;

        if (koopaMovement != null)
        {
            koopaMovement.isShell = true;
        }

        if (Animator != null)
        {
            Animator.SetBool("IsShell", true);
        }


        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.zero;
            rb.isKinematic = true;
        }

        Invoke(nameof(DestroyBot), shellLifetime);
    }

    void DestroyBot()
    {
        Destroy(gameObject);
    }



}
