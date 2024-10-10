using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
    public Progress progress;

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
    }
    public void StartGame()
    {
        Debug.Log("start");
        SceneManager.LoadScene(progress.GetNowMap());
    }
    public void Restart()
    {
        Debug.Log("restart");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Menu()
    {
        Debug.Log("menu");
        SceneManager.LoadScene(0);
    }
    public void Exit()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

}
