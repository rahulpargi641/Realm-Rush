using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Range(0.1f, 120f)]
    [SerializeField] float secondsBetweenSpawns =2f;
    [SerializeField] EnemyMovement enemyPrefab;

    [SerializeField] Transform enemyParent;

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
            
            newEnemy.transform.parent = enemyParent;


            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
       
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}