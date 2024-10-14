using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoopaAttak : MonoBehaviour
{
    [SerializeField] private float damage = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        KoopaCollision koopaCollision = GetComponent<KoopaCollision>();

        if (collision.tag == "Player" && !koopaCollision.isShell)
        {
            // Chỉ gây sát thương nếu Koopa không ở trạng thái shell
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }


}
