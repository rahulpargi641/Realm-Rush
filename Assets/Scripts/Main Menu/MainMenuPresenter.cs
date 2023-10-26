using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuPresenter : MonoBehaviour
{
    [SerializeField] Button startButton;
    [SerializeField] Button quitButton;
    [SerializeField] Button howToPlay;
    [SerializeField] Button backButton;
    [SerializeField] GameObject instructionsScreen;

    private void Awake()
    {
        startButton.onClick.AddListener(PlayGame);
        quitButton.onClick.AddListener(QuitGame);
        howToPlay.onClick.AddListener(ShowInstructionScreen);
        backButton.onClick.AddListener(HideInstructionsScreen);
    }

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.PlaySound(SoundType.BgMusic);
    }

    private void PlayGame()
    {
        AudioManager.Instance.PlaySound(SoundType.MenuButtonStart);

        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
            nextSceneIndex = 0;

        SceneManager.LoadScene(nextSceneIndex);
    }

    private void QuitGame()
    {
        AudioManager.Instance.PlaySound(SoundType.MenuButtonQuit);

        UnityEditor.EditorApplication.isPlaying = false; // Stop playing in the editor
        Application.Quit();
    }

    private void ShowInstructionScreen()
    {
        AudioManager.Instance.PlaySound(SoundType.MenuButtonConfirm);

        instructionsScreen.SetActive(true);
    }

    private void HideInstructionsScreen()
    {
        AudioManager.Instance.PlaySound(SoundType.MenuButtonConfirm);

        if (instructionsScreen.activeSelf)
        {
            instructionsScreen.SetActive(false);
        }
    }
}
