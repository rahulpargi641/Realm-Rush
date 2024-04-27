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
        AudioManager.Instance.PlaySound(SoundType.Shoot);

        if (hitPoints <= 0)
            DestroyEnemy();
    }

    private void DestroyEnemy()
    {
        FindObjectOfType<EnemySpawner>().EnemyDestroyed(); // Implement with event channels

        var deathVfx = Instantiate(deathParticlePrefab, transform.position + new Vector3(0f, 15f, 0f), Quaternion.identity); // implement with object pooling
        deathVfx.Play();

        float destroyPlay = deathVfx.main.duration;
        Destroy(deathVfx.gameObject, destroyPlay); // implement with 

        AudioManager.Instance.PlaySound(SoundType.Destroyed);

        Destroy(gameObject);
    }
}
