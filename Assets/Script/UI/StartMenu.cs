using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    [SerializeField] GameObject startButton;
    [SerializeField] GameObject quitButton;

    private void Start()
    {
    }
    void Update()
    {
    }

    public void StartGame()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Lv1");
    }
    public void QuitGame()
    {
        Debug.Log("Quit Game....");
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
