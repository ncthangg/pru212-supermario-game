using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool gamePaused = false;
    [SerializeField] GameObject pauseMenu;

    private void Start()
    {
        pauseMenu.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
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
        SceneManager.LoadScene(0);
    }

    public void Continue()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        gamePaused = false;
    }
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        gamePaused = true;
    }
}
