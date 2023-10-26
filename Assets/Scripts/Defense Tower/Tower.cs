using UnityEngine;

public class Tower : MonoBehaviour
{
    // Parameters of each tower
    [SerializeField] Transform towerGunTransform;
    [SerializeField] float attackRange = 50f;
    [SerializeField] ParticleSystem projectileParticle;

    public WayPoint baseWaypoint;  // What the tower is standing on 

    Transform initialTowerGunTransform;
    Transform targetEnemy;

    private void Start()
    {
        initialTowerGunTransform = towerGunTransform;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTargetEnemy();
        if (targetEnemy)
        {
            FireAtEnemyIfInAttackRange();
        }
        else
        {
            towerGunTransform = initialTowerGunTransform;
            Shoot(false);
        }
    }

    private void UpdateTargetEnemy()
    {
        var enemies = FindObjectsOfType<EnemyDamage>();
        if (enemies.Length == 0)
        {
            targetEnemy = null; // No enemies, so set targetEnemy to null
            return;
        }
        SetTargetEnemy(enemies);
    }

    private void SetTargetEnemy(EnemyDamage[] enemies)
    {
        Transform closestEnemy = null; // Initialize to null

        foreach (EnemyDamage testEnemy in enemies)
        {
            if (closestEnemy == null)
            {
                closestEnemy = testEnemy.transform;
            }
            else
            {
                closestEnemy = SetCLosestEnemy(closestEnemy, testEnemy);
            }
        }

        targetEnemy = closestEnemy;
    }

    private Transform SetCLosestEnemy(Transform closestEnemy, EnemyDamage testEnemy)
    {
        float disToClosest = Vector3.Distance(transform.position, closestEnemy.position);
        float disToTest = Vector3.Distance(transform.position, testEnemy.transform.position);

        if (disToTest < disToClosest)
        {
            closestEnemy = testEnemy.transform;
        }

        return closestEnemy;
    }

    void FireAtEnemyIfInAttackRange()
    {
        float distanceToEnemy = Vector3.Distance(targetEnemy.transform.position, gameObject.transform.position);
        if (distanceToEnemy <= attackRange)
        {
            towerGunTransform.LookAt(targetEnemy);
            Shoot(true);
        }
        else
        {
            towerGunTransform = initialTowerGunTransform;
            Shoot(false);
        }
    }

    private void Shoot(bool isActive)
    {
        var emissionModule = projectileParticle.emission;
        emissionModule.enabled = isActive;
    }
}
