using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Assets.Scripts.Player;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject pauseScreen;
    [SerializeField] Button quitButton;
    [SerializeField] string GameOverSceneName = "GameOver";
    [SerializeField] float LevelLoadDelay = 2f;

    private bool isPaused = false;

    private void Awake()
    {
        quitButton.onClick.AddListener(QuitGame);
        pauseScreen.SetActive(false); 
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayerHealth.OnPlayerDeath += GameOver;
    }

    private void OnDestroy()
    {
        PlayerHealth.OnPlayerDeath -= GameOver;
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
        isPaused = true;
        pauseScreen.SetActive(true);
        Time.timeScale = 0; // Pause time

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    void ResumeGame()
    {
        isPaused = false;
        pauseScreen.SetActive(false);
        Time.timeScale = 1; // Resume time

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void QuitGame()
    {
        if (Application.isPlaying)
        {
            Application.Quit(); // Quit the game directly
        }
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Stop playing in the editor
#endif
        AudioManager.Instance.PlaySound(SoundType.MenuButtonConfirm);
    }

    private void GameOver()
    {
        StartCoroutine(LoadGameOverScene());
    }

    private IEnumerator LoadGameOverScene()
    {
        yield return new WaitForSecondsRealtime(LevelLoadDelay);

        SceneManager.LoadScene(GameOverSceneName);
    }
}

