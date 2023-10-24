using UnityEngine;

public class Tower : MonoBehaviour
{
    // Parameters of each tower
    [SerializeField] Transform objectToPan;
    [SerializeField] float attackRange = 50f;
    [SerializeField] ParticleSystem projectileParticle;

    public WayPoint baseWaypoint;  // What the tower is standing on 

    // State of each tower
    [SerializeField] Transform targetEnemy;
    
    // Update is called once per frame
    void Update()
    {
        SetTargetEnemy();
        if (targetEnemy)
        {
            objectToPan.LookAt(targetEnemy);
            FireAtEnemy();  
        }
        else
        {
            Shoot(false);
        }
    }

    private void SetTargetEnemy()
    {
        var sceneEnemies = FindObjectsOfType<EnemyDamage>();
        if (sceneEnemies.Length == 0) { return; }

        Transform closestEnemy = sceneEnemies[0].transform;

        //foreach (EnemyDamage testEnemy in sceneEnemies)
        //{
        //    closestEnemy = GetClosestEnemy(closestEnemy, testEnemy.transform);
        //}

        targetEnemy = closestEnemy;
    }

    private Transform GetClosestEnemy(Transform transformA, Transform transformB)
    {
        float disToA = Vector3.Distance(transform.position, transformB.position);
        float disToB = Vector3.Distance(transform.position, transformA.position);

        if (disToA < disToB)
        {
            return transformA;
        }

        return transformB;
    }

    void FireAtEnemy()
    {
        float distanceToEnemy = Vector3.Distance(targetEnemy.transform.position, gameObject.transform.position);
        if (distanceToEnemy <= attackRange)
        {
            Shoot(true);

        }
        else
        {
            Shoot(false);
        }
    }

    private void Shoot(bool isActive)
    {
        var emissionModule = projectileParticle.emission;
        emissionModule.enabled = isActive;
    }

}
