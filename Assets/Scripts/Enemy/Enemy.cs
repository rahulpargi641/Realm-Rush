using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Flyweight
{
    new EnemySettings settings => (EnemySettings) base.settings;

    void OnEnable()
    {
        //StartCoroutine(DeSpawnAfterDelay(settings.despawnDelay));
    }



    IEnumerator DeSpawnAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        FlyweightFactory.ReturnToPool(this);
    }
}
