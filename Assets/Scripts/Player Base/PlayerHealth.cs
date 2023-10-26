using System;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    internal static Action onPlayerDeath;
    [SerializeField] int health = 100;
    [SerializeField] int healthLoss = 50;
    [SerializeField] TextMeshProUGUI healthText;

    private void OnTriggerEnter(Collider other) // other - enemy 
    {
        health = health - healthLoss;
        if (health <= 0)
        {
            health = 0;
            AudioManager.Instance.PlaySound(SoundType.PlayerDeath);
            onPlayerDeath?.Invoke();
        }

        healthText.text = health.ToString();
    }
}
