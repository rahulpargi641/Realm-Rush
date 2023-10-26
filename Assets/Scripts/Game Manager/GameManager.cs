using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject pauseScreen;
    [SerializeField] Button quitButton;

    private bool isPaused = false;

    private void Start()
    {
        quitButton.onClick.AddListener(QuitGame);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0;
        pauseScreen.SetActive(true);
        isPaused = true;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked; 
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
        isPaused = false;

        Cursor.visible = true; 
        Cursor.lockState = CursorLockMode.None; 
    }

    void QuitGame()
    {
        if (Application.isPlaying)
        {
            EditorApplication.isPlaying = false;
        }

        Application.Quit();
    }
}

