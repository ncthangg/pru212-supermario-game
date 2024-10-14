using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject pauseMenu;
    public Progress progress;
    public static bool gamePaused = false;

    private void Start()
    {
        pauseMenu.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("paused");
            if (!gamePaused)
            {
                Pause();
            }
            else
            {
                Continue();
            }
        }
    }
    public void GameOver()
    {
        Debug.Log("lose");
        gameOverUI.SetActive(true);
    }
    public void StartGame()
    {
        Debug.Log("start");
        Time.timeScale = 1.0f;  
        SceneManager.LoadScene(progress.GetNowMap());
    }
    public void Restart()
    {
        Debug.Log("restart");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Home()
    {
        Debug.Log("home");
        SceneManager.LoadScene("HomeScreen");
    }
    public void Continue()
    {
        Debug.Log("continue");
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        gamePaused = false;
    }
    public void Pause()
    {
        Debug.Log("pause");
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        gamePaused = true;
    }
    public void Exit()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

}
