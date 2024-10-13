using UnityEngine;

public class PowerUp : MonoBehaviour
{
    
    public enum Type
    {
        Coin,
        ExtraLife,
    }

    public Type type;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Collect(collision.gameObject);
        }
    }

    private void Collect(GameObject player)
    {
        switch (type)
        {
            case Type.Coin:
                BlockCoin.Instance.AddCoin();
                break;

            case Type.ExtraLife:
                BlockCoin.Instance.AddLife();
                break;
        }

        Destroy(gameObject);
    }
}
