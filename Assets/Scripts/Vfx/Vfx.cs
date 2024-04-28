using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Vfx
{
    public class Vfx : Flyweight
    {
        private new VfxSettings settings => (VfxSettings)base.settings;
        private ParticleSystem vfx;

        private void Awake()
        {
            vfx = GetComponent<ParticleSystem>();
        }

        private void OnEnable()
        {
            float despawnDelay = vfx.main.duration;
            StartCoroutine(DespawnParticles(despawnDelay));
        }

        private IEnumerator DespawnParticles(float despawnDelay)
        {
            yield return new WaitForSeconds(despawnDelay);

            FlyweightFactory.ReturnToPool(this);
        }

        internal void SetTransform(Vector3 spawnPoint)
        {
            transform.position = spawnPoint;
            transform.rotation = Quaternion.identity;
        }

        internal void PlayVFX()
        {
            if (vfx != null)
                vfx.Play();
            else
                Debug.LogError("Particle System component didn't add");
        }
    }
}