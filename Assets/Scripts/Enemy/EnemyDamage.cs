using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] Collider collider;
    [SerializeField] int hitPoints = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

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
        Destroy(gameObject);
    }

    void ProcessHit()
    {
        hitPoints = hitPoints - 1;
        print("Current Hitpoints are " + hitPoints);
    }
}
