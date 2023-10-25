using System.Collections;
using TMPro;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Range(0.1f, 120f)]
    [SerializeField] float secondsBetweenSpawns = 1f;
    [SerializeField] EnemyMovement enemyPrefab;
    [SerializeField] Transform enemyParentTransform;
    [SerializeField] TextMeshProUGUI nEnemiesDestroyedText;

    int nEnemiesDestroyed;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RepeatedlySpawnEnemies());
    }

    IEnumerator RepeatedlySpawnEnemies()
    {
        while (true)
        {
            var newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            newEnemy.transform.parent = enemyParentTransform;

            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }

    public void EnemyDestroyed()
    {
        nEnemiesDestroyed++;
        nEnemiesDestroyedText.text = nEnemiesDestroyed.ToString();
    }
}
