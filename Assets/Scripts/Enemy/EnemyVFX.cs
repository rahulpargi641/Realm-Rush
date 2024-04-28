using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class EnemyVFX : MonoBehaviour
    {
        [SerializeField] ParticleSystem hitParticlePrefab;
        [SerializeField] ParticleSystem deathParticlePrefab;

        internal void PlayHitVFX()
        {
            hitParticlePrefab.Play();
        }

        internal void PlayDeathVFX()
        {
            var deathVfx = Instantiate(deathParticlePrefab, transform.position + new Vector3(0f, 15f, 0f), Quaternion.identity); // implement with object pooling
            deathVfx.Play();

            float destroyPlay = deathVfx.main.duration;
            Destroy(deathVfx.gameObject, destroyPlay); // implement with 
        }
    }
}
