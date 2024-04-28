using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] float movementPeriod = 1;
        [SerializeField] List<WayPoint> path; // todo remove serializefield

        private EnemyVfx enemyVFX;

        private void Awake()
        {
            enemyVFX = GetComponent<EnemyVfx>();
        }

        // Start is called before the first frame update
        void Start()
        {
            GetAndFollowPath();
        }

        private void GetAndFollowPath()
        {
            PathFinder pathFinder = FindObjectOfType<PathFinder>();
            path = pathFinder.GetPath();

            StartCoroutine(FollowPath(path));
        }

        IEnumerator FollowPath(List<WayPoint> path)
        {
            //print("Starting Patrol");
            foreach (WayPoint wayPoint in path)
            {
                //print(wayPoint.name);
                transform.position = wayPoint.transform.position;
                yield return new WaitForSeconds(movementPeriod);
            }
            //print("End Patrol");
            enemyVFX?.PlayGoalReachedVFX();
        }
    }
}
