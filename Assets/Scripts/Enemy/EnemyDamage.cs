using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] Collider collider;
    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem hitParticlePrefab;   
    [SerializeField] ParticleSystem deathParticlePrefab;

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hitPoints <= 0)
            KillEnemy();
    }

    private void ProcessHit()
    {
        hitPoints = hitPoints - 1;
        hitParticlePrefab.Play();
        print("Current Hitpoints are " + hitPoints);
    }

    private void KillEnemy()
    {
        var deathVfx = Instantiate(deathParticlePrefab, transform.position + new Vector3(0,0,10), Quaternion.identity);
        deathVfx.Play();
        float destroyPlay = deathVfx.main.duration;
        Destroy(deathVfx.gameObject, destroyPlay);

        Destroy(gameObject);
    }
}
