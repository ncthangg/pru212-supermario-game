using UnityEngine;

public class StartPoint : MonoBehaviour
{
    public GameObject playerPrefab; // Prefab của nhân vật người chơi
    public Transform spawnPoint; // Vị trí mà người chơi sẽ xuất hiện

    void Start()
    {
        if (playerPrefab != null && spawnPoint != null)
        {
            Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
