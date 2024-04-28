using System;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerHealth : MonoBehaviour
    {
        public static Action OnPlayerDeath;
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
                OnPlayerDeath?.Invoke();
            }

            healthText.text = health.ToString();
        }
    }
}
