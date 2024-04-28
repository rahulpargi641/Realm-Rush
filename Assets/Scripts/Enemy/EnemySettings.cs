using UnityEngine;


[CreateAssetMenu(menuName = "Flyweight/Enemy Settings")]
public class EnemySettings : FlyweightSettings
{
    public int maxHealth = 25;
    public int destructionPoints = 1;
    
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




