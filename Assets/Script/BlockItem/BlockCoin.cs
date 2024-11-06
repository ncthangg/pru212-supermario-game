using System.Collections;
using UnityEngine;

public class BlockCoin : MonoBehaviour
{
    public static BlockCoin Instance { get; private set; }

    public int coinValue = 100; // Gi� tr? c?a coin, m?c ??nh 10 ?i?m
    public int coins { get; private set; }
    public int lives { get; private set; }
    private void Start()
    {
        AddCoin();

        StartCoroutine(Animate());
    }

    private IEnumerator Animate()
    {
        Vector3 restingPosition = transform.localPosition;
        Vector3 animatedPosition = restingPosition + Vector3.up * 2f;

        yield return Move(restingPosition, animatedPosition);
        yield return Move(animatedPosition, restingPosition);

        // Th�m ?i?m sau khi coin xu?t hi?n
        ScoreManager.Instance.AddPoints(coinValue);


        Destroy(gameObject);
    }

    private IEnumerator Move(Vector3 from, Vector3 to)
    {
        float elapsed = 0f;
        float duration = 0.25f;

        while (elapsed < duration)
        {
            float t = elapsed / duration;

            transform.localPosition = Vector3.Lerp(from, to, t);
            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = to;
    }

    public void AddCoin()
    {
        coins++;
    }

    public void AddLife()
    {
        lives++;
    }
}
