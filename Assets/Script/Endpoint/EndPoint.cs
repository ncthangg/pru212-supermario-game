using System.Collections;
using System.Collections.Generic;
using System.Net.WebSockets;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPoint : MonoBehaviour
{
    public SaveManager saveManager;
    public GameObject winGameUI;
    private int nextMap;
    void Start()
    {
        nextMap = saveManager.progress.GetNextMap();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Animator playerAnimator = collision.GetComponent<Animator>();
            Player player = collision.GetComponent<Player>();
            if (playerAnimator != null)
            {
                player.StopMovement();
            }

            saveManager.CompleteMap(nextMap);

            if (nextMap > 2) // Kiểm tra nếu đang ở map cuối cùng
            {
                ShowWinGameUI();
                saveManager.CompleteGame();
            }
            else
            {
                StartCoroutine(WaitAndLoadNextLevel(5f));
            }
        }
    }

    // Coroutine để đợi 5 giây trước khi gọi NextLv()
    private IEnumerator WaitAndLoadNextLevel(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        NextLv();
    }

    public void NextLv()
    {
        Debug.Log("start");
        SceneManager.LoadScene(nextMap);
    }

    private void ShowWinGameUI()
    {
        winGameUI.SetActive(true);
    }

}
