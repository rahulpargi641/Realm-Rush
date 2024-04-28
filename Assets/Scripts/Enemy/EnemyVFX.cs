using UnityEngine;
using Assets.Scripts.Vfx;

namespace Assets.Scripts.Enemy
{
    public class EnemyVfx : MonoBehaviour
    {
        [SerializeField] private ParticleSystem hitParticlePrefab;
        [SerializeField] private ParticleSystem goalParticle;
        //[SerializeField] private ParticleSystem deathParticlePrefab;

        private const float verticalOffset = 15f;

        internal void PlayHitVFX()
        {
            if (hitParticlePrefab != null)
                hitParticlePrefab.Play();
        }

        internal void PlayDeathVFX()
        {
            //var deathVfx = Instantiate(deathParticlePrefab, transform.position + new Vector3(0f, verticalOffset, 0f), Quaternion.identity); // implement with object pooling
            VfxSpawnManager.Instance.SpawnVfx(transform.position + new Vector3(0f, verticalOffset, 0f));
        }

        internal void PlayGoalReachedVFX()
        {
            if (goalParticle != null)
            {
                var deathVfx = Instantiate(goalParticle, transform.position + new Vector3(0f, verticalOffset, 0f), Quaternion.identity); // doesn't frequently created
                deathVfx.Play();

                float destroyDelay = deathVfx.main.duration;
                Destroy(deathVfx.gameObject, destroyDelay);
            }
        }
    }
}
