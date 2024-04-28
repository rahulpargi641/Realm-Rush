using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Generic;

public class EnemySpawnManager : MonoSingletonGeneric<EnemySpawnManager>
{
    public List<Enemy> Enemies => enemies;

    [SerializeField] List<EnemySettings> enemySettings;

    [Range(0.1f, 120f)]
    [SerializeField] float spawninterval = 1f;
    [SerializeField] float dealyBeforeSpwaning = 2f;

    private List<Enemy> enemies = new List<Enemy>();

    private void Start()
    {
        StartCoroutine(SpawnEnemiesAtInterval());
    }

    IEnumerator SpawnEnemiesAtInterval()
    {
        yield return new WaitForSeconds(dealyBeforeSpwaning);

        while (true)
        {
            SpawnEnemy();
            AudioManager.Instance.PlaySound(SoundType.Spawn);

            yield return new WaitForSeconds(spawninterval);
        }
    }

    private void SpawnEnemy()
    {
        var spawnedEnemy = FlyweightFactory.Spawn(enemySettings[0]) as Enemy;
        if (spawnedEnemy)
        {
            SetEnemyTransform(spawnedEnemy);

            enemies.Add(spawnedEnemy);
        }
        else
        { Debug.LogError("Enemy Didn't created"); }
    }

    private void SetEnemyTransform(Enemy spawnedEnemy)
    {
        spawnedEnemy.transform.position = transform.position;
        spawnedEnemy.transform.rotation = Quaternion.identity;
        spawnedEnemy.transform.parent = transform;
    }

    public void ReturnToPool(Enemy enemy)
    {
        enemies.Remove(enemy);

        FlyweightFactory.ReturnToPool(enemy);
    }
}
