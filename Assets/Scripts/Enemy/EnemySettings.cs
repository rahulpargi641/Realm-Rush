using System.Collections;
using UnityEngine;


[CreateAssetMenu(menuName = "Flyweight/Enemy Settings")]
public class EnemySettings : FlyweightSettings
{
    public int maxHealth = 17;
    public int destructionPoints = 1;
    public float despawnDelay = 5f;
    //public float speed = 10f;

    private void OnEnable()
    {
        //StartCoroutine(DeSpawnAfterDelay(settings.despawnDelay));
    }

    public override Flyweight Create()
    {
        var go = Instantiate(prefab);
        go.SetActive(false);
        go.name = prefab.name;

        var enemy = go.AddComponent<Enemy>();
        enemy.settings = this;

        return enemy;
    }

    IEnumerator DeSpawnAfterDelay(float delay) // to do : Remove 
    {
        yield return new WaitForSeconds(delay);
        //FlyweightFactory.ReturnToPool(this);
    }
}




