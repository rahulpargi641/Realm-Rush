using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Range(0.1f, 120f)]
    [SerializeField] float spawninterval = 1f;
    [SerializeField] float dealyBeforeSpwaning = 2f;
    [SerializeField] EnemyMovement enemyPrefab;
    [SerializeField] Transform enemyParentTransform;
    [SerializeField] TextMeshProUGUI nEnemiesDestroyedText;

    [SerializeField] List<EnemySettings> enemies;

    private int nEnemiesDestroyed;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RepeatedlySpawnEnemies());
    }

    IEnumerator RepeatedlySpawnEnemies()
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
        //var newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity); // Object pooling
        //newEnemy.transform.parent = enemyParentTransform;
        var spawnedEnemy = FlyweightFactory.Spawn(enemies[0]);
        if (spawnedEnemy)
            spawnedEnemy.transform.parent = enemyParentTransform;
        else
            Debug.LogError("Enemy Didn't created");
    }

    public void EnemyDestroyed()
    {
        nEnemiesDestroyed++; // observer or event channels
        nEnemiesDestroyedText.text = nEnemiesDestroyed.ToString();
        AudioManager.Instance.PlaySound(SoundType.Destroyed);
    }
}
