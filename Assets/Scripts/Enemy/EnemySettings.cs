using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flyweight/Enemy Settings")]
public class EnemySettings : FlyweightSettings
{
    public float despawnDelay = 5f;
    //public float speed = 10f;

    public override Flyweight Create()
    {
        var go = Instantiate(prefab);
        go.SetActive(false);
        go.name = prefab.name;

        var enemy = go.AddComponent<Enemy>();
        enemy.settings = this;

        return enemy;
    }
}

