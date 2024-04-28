using UnityEngine;
using Assets.Scripts.Generic;
using Assets.Scripts.Enemy;

public class Enemy : Flyweight
{
    public static Observer<int> OnDestroyed = new Observer<int>(1);
    private new EnemySettings settings => (EnemySettings)base.settings;

    private EnemyVfx vfxManager;
    private int currentHealth;

    private void Awake()
    {
        vfxManager = GetComponent<EnemyVfx>();
        currentHealth = settings.maxHealth;
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
        vfxManager.PlayHitVFX();
        AudioManager.Instance.PlaySound(SoundType.Shoot);
    }

    private void ProcessDestruction()
    {
        OnDestroyed.Invoke();

        vfxManager.PlayDeathVFX();
        AudioManager.Instance.PlaySound(SoundType.Destroyed);

        EnemySpawnManager.Instance.ReturnToPool(this);
    }
}


