using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyweightFactory : MonoSingletonGeneric<FlyweightFactory>
{
    [SerializeField] int defaultCapacity = 20;
    [SerializeField] int maxPoolSize = 100;

    readonly Dictionary<FlyweightType, ObjectPool<Flyweight>> pools = new Dictionary<FlyweightType, ObjectPool<Flyweight>>();

    protected override void Awake()
    {
        base.Awake();
    }

    public static Flyweight Spawn(FlyweightSettings s) => Instance.GetPoolFor(s)?.Get();
    public static void ReturnToPool(Flyweight f) => Instance.GetPoolFor(f.settings)?.Release(f);

    ObjectPool<Flyweight> GetPoolFor(FlyweightSettings settings)
    {
        ObjectPool<Flyweight> pool;

        if (pools.TryGetValue(settings.type, out pool)) return pool;

        pool = new ObjectPool<Flyweight>(
            settings.Create,
            settings.OnGet,
            settings.OnRelease,
            settings.OnDestroyPoolObject,
            defaultCapacity,
            maxPoolSize
            );

        pools.Add(settings.type, pool);
        return pool;
    }
}
