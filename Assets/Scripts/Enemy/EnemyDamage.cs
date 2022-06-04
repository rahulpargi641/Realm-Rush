using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] Collider collider;
    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem hitParticlePrefab;  // uncheck play on awake  
    [SerializeField] ParticleSystem deathParticlePrefab;
    private void OnParticleCollision(GameObject other)
    {
        print("I'm Hit");
        ProcessHit();
        if (hitPoints <= 0)
        {
            KillEnemy();
        }
        
       
    }

    private void KillEnemy()
    {
        var deathVfx=Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
        deathVfx.Play();
        float destroyPlay = deathVfx.main.duration;
        Destroy(deathVfx.gameObject, destroyPlay);

        Destroy(gameObject); // destroy so that it won't sit in hierachy means world
    }

    void ProcessHit()
    {
        hitPoints = hitPoints - 1;
        hitParticlePrefab.Play();
        print("Current Hitpoints are " + hitPoints);
    }
}
