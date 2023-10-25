using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health = 100;
    [SerializeField] int healthDecrease = 10;
    [SerializeField] TextMeshProUGUI healthText;

    private void OnTriggerEnter(Collider other) // other - enemy 
    {
        if(health >= 0)
        {
            health = health - healthDecrease;
            healthText.text = health.ToString();
        }
    }
}
