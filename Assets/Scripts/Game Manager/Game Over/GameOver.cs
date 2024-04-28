using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] Button startButton;
    [SerializeField] Button quitButton;
    [SerializeField] float LevelLoadDelay = 2f;

    private void Awake()
    {
        startButton.onClick.AddListener(PlayGame);
        quitButton.onClick.AddListener(QuitGame);
    }

    private void PlayGame()
    {
        AudioManager.Instance.PlaySound(SoundType.MenuButtonStart);

        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex - 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
            nextSceneIndex = 0;

        SceneManager.LoadScene(nextSceneIndex);
    }

    private void QuitGame()
    {
        AudioManager.Instance.PlaySound(SoundType.MenuButtonQuit);

        Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false; // Stop playing in the editor
    }
}
