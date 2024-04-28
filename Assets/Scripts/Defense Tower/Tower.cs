using System.Collections;
using UnityEngine;
using Assets.Scripts.Defense_Tower;

public class Tower : MonoBehaviour, IDefenseUnit
{
    public TowerData Data { private get; set; }
    public WayPoint BaseWaypoint { get; set; } // What the tower is standing on 

    [SerializeField] private Transform towerGunTransform;
    [SerializeField] private ParticleSystem projectileParticles;

    private Transform initialTowerGunTransform;
    private Transform targetEnemy;

    private void Start()
    {
        initialTowerGunTransform = towerGunTransform;
    }

    private void Update()
    {
        UpdateTargetEnemy();
        ProcessShooting();
    }

    private void ProcessShooting()
    {
        if (targetEnemy)
        {
            ShootAtEnemyIfInAttackRange();
        }
        else
        {
            towerGunTransform = initialTowerGunTransform;
            Shoot(false);
        }
    }

    private void UpdateTargetEnemy()
    {
        var enemies = FindObjectsOfType<Enemy>();
        if (enemies.Length == 0)
        {
            targetEnemy = null; // No enemies, so set targetEnemy to null
            return;
        }
        SetTargetEnemy(enemies);
    }

    private void SetTargetEnemy(Enemy[] enemies)
    {
        Transform closestEnemy = null; // Initialize to null

        foreach (Enemy testEnemy in enemies)
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

    private Transform SetCLosestEnemy(Transform closestEnemy, Enemy testEnemy)
    {
        float disToClosest = Vector3.Distance(transform.position, closestEnemy.position);
        float disToTest = Vector3.Distance(transform.position, testEnemy.transform.position);

        if (disToTest < disToClosest)
        {
            closestEnemy = testEnemy.transform;
        }

        return closestEnemy;
    }

    private void ShootAtEnemyIfInAttackRange()
    {
        float distanceToEnemy = Vector3.Distance(targetEnemy.transform.position, gameObject.transform.position);
        if (distanceToEnemy <= Data.attackRange)
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

    public void Shoot(bool bShoot)
    {
        var emissionModule = projectileParticles.emission;
        emissionModule.enabled = bShoot;
    }
}