using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header("UI Collections")]
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject pauseMenu;
    [Header("Home Screen")]
    [SerializeField] GameObject startButton;
    [SerializeField] GameObject quitButton;
    public Progress progress;
    public static bool gamePaused = false;

    [SerializeField] private AudioClip gameOverSound;
    private AudioSource bgmAudioSource;
    private AudioSource gameOverAudioSource;

    private void Awake()
    {
        // Get the BGM AudioSource from the main camera
        bgmAudioSource = Camera.main.GetComponent<AudioSource>();

        // Add an AudioSource component for the game over sound
        gameOverAudioSource = gameObject.AddComponent<AudioSource>();
    }

    void Start()
    {
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(false);
        }
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
    public void Home()
    {
        Debug.Log("home");
        SceneManager.LoadScene("HomeScreen");
    }
    public void StartGame()
    {
        Debug.Log("start");
        var nowMap = progress.GetNowMap();
        SceneManager.LoadScene(nowMap);
    }
    public void WinGame()
    {
        Debug.Log("win");
    }
    public void GameOver()
    {
        Debug.Log("lose");
        // Stop the BGM
        bgmAudioSource.Stop();

        // Play the game over sound
        gameOverAudioSource.PlayOneShot(gameOverSound);
        gameOverUI.SetActive(true);
    }

    public void Restart()
    {
        Debug.Log("restart");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Pause()
    {
        Debug.Log("pause");
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        gamePaused = true;
    }
    public void Continue()
    {
        Debug.Log("continue");
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        gamePaused = false;
    }

    public void Exit()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

}
