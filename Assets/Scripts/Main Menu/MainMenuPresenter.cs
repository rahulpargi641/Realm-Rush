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
        PlayButtonClickSound();

        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
            nextSceneIndex = 0;

        SceneManager.LoadScene(nextSceneIndex);
    }

    private void QuitGame()
    {
        PlayButtonClickSound();

        Application.Quit();
    }

    private void ShowInstructionScreen()
    {
        PlayButtonClickSound();

        instructionsScreen.SetActive(true);
    }

    private void HideInstructionsScreen()
    {
        if (instructionsScreen.activeSelf)
        {
            instructionsScreen.SetActive(false);
        }
    }

    private void PlayButtonClickSound()
    {
        AudioManager.Instance.PlaySound(SoundType.ButtonClick);
    }
}
