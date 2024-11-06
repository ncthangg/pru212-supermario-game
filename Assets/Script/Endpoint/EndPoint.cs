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

            saveManager.CompletedMap(nextMap);

            if (nextMap > 2) // Kiểm tra nếu đang ở map cuối cùng
            {
                saveManager.CompletedGame();
                StartCoroutine(WaitAndLoadWingame(3f));
            }
            else
            {
                // StartCoroutine(WaitAndLoadNextLevel(3f));
                NextLv();
            }
        }
    }

    // Coroutine để đợi 3 giây trước khi gọi NextLv()
    private IEnumerator WaitAndLoadNextLevel(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        NextLv();
    }

    private IEnumerator WaitAndLoadWingame(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        ShowWinGameUI();
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
