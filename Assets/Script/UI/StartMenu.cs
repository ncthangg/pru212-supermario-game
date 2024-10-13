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
        SceneManager.LoadScene("ThienPTB");
    }
    public void QuitGame()
    {
        Debug.Log("Quit Game....");
        Application.Quit();
    }
}
