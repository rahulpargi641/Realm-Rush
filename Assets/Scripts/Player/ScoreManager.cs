using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    private int currentScore;

    private void OnEnable() => Enemy.OnDestroyed.AddListner(AddScore);
    private void OnDisable() => Enemy.OnDestroyed.RemoveListner(AddScore);

    private void AddScore(int points)
    {
        currentScore += points;
        UpdateScoreText();
        AudioManager.Instance.PlaySound(SoundType.Destroyed);
    }

    private void UpdateScoreText()
    {
        scoreText.text = $"{currentScore}";
    }
}