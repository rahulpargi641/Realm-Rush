using UnityEngine;
using Assets.Scripts.Generic;
using Assets.Scripts.Enemy;

public class Enemy : Flyweight
{
    public static Observer<int> OnDestroyed = new Observer<int>(1);
    private EnemySettings data => (EnemySettings)base.settings;
    private EnemyVFX enemyVFX;
    private int currentHealth;

    private void Awake()
    {
        enemyVFX = GetComponent<EnemyVFX>();
        currentHealth = data.maxHealth;
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessEnemyHit();
    }

    private void ProcessEnemyHit()
    {
        ProcessHit();

        if (currentHealth <= 0) ProcessDestruction();
    }

    private void ProcessHit()
    {
        currentHealth--;
        enemyVFX.PlayHitVFX();
        AudioManager.Instance.PlaySound(SoundType.Shoot);
    }

    private void ProcessDestruction()
    {
        OnDestroyed.Invoke();

        enemyVFX.PlayDeathVFX();
        AudioManager.Instance.PlaySound(SoundType.Destroyed);

        EnemySpawneManager.Instance.ReturnToPool(this);
    }
}


