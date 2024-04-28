using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [Range(0.1f, 120f)]
        [SerializeField] float spawninterval = 1f;
        [SerializeField] float dealyBeforeSpwaning = 2f;

        [SerializeField] List<EnemySettings> enemySettings;

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
            var spawnedEnemy = FlyweightFactory.Spawn(enemySettings[0]);
            if (spawnedEnemy)
                spawnedEnemy.transform.parent = transform;
            else
                Debug.LogError("Enemy Didn't created");
        }
    }
}
