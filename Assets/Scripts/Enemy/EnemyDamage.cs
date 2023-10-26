using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem hitParticlePrefab;   
    [SerializeField] ParticleSystem deathParticlePrefab;

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        hitPoints = hitPoints - 1;
        hitParticlePrefab.Play();
        print("Current Hitpoints are " + hitPoints);

        AudioManager.Instance.PlaySound(SoundType.Shoot);

        if (hitPoints <= 0)
            KillEnemy();
    }

    private void KillEnemy()
    {
        FindObjectOfType<EnemySpawner>().EnemyDestroyed();

        var deathVfx = Instantiate(deathParticlePrefab, transform.position + new Vector3(0f, 15f, 0f), Quaternion.identity);
        deathVfx.Play();

        float destroyPlay = deathVfx.main.duration;
        Destroy(deathVfx.gameObject, destroyPlay);

        AudioManager.Instance.PlaySound(SoundType.Destroyed);

        Destroy(gameObject);
    }
}
