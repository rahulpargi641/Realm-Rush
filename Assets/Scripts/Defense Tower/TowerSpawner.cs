using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Defense_Tower
{
    public class TowerSpawner : MonoBehaviour
    {
        [SerializeField] TowerFactory towerFactory;
        [SerializeField] int towerLimit = 5;

        private Queue<Tower> towerQueue = new Queue<Tower>();

        public void AddTower(WayPoint waypointToPlaceOn)
        {
            int nTowers = towerQueue.Count;
            print(gameObject.name + " Tower Placement");

            if (nTowers < towerLimit)
            {
                SpawnTower(waypointToPlaceOn);
            }
            else
            {
                MoveExistingTower(waypointToPlaceOn);
            }

            AudioManager.Instance.PlaySound(SoundType.TowerPlaced);
        }

        private void SpawnTower(WayPoint newBaseWayPoint)
        {
            var newTower = towerFactory.Create() as Tower;

            SetTransformAndParent(newBaseWayPoint, newTower);

            newTower.BaseWaypoint = newBaseWayPoint;
            newBaseWayPoint.isPlacable = false;

            towerQueue.Enqueue(newTower);
        }

        private void SetTransformAndParent(WayPoint newBaseWayPoint, Tower spawnedTower)
        {
            spawnedTower.transform.position = newBaseWayPoint.transform.position;
            spawnedTower.transform.rotation = Quaternion.identity;
            spawnedTower.transform.parent = transform;
        }

        private void MoveExistingTower(WayPoint waypointToPlaceOn)
        {
            var oldTower = towerQueue.Dequeue();

            oldTower.BaseWaypoint.isPlacable = true; // frees up the block
            waypointToPlaceOn.isPlacable = false;
            oldTower.BaseWaypoint = waypointToPlaceOn;
            oldTower.transform.position = waypointToPlaceOn.transform.position;

            towerQueue.Enqueue(oldTower);
        }
    }
}
