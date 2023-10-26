using System;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    internal static Action onPlayerDeath;
    [SerializeField] int health = 100;
    [SerializeField] int healthDecrease = 10;
    [SerializeField] TextMeshProUGUI healthText;

    private void OnTriggerEnter(Collider other) // other - enemy 
    {
        health = health - healthDecrease;
        if (health <= 0)
        {
            health = 0;
            onPlayerDeath?.Invoke();
        }

        healthText.text = health.ToString();
    }
}
