using System.Collections.Generic;
using UnityEngine;


public class TowerSpawner : MonoBehaviour
{
    [SerializeField] int towerLimit = 5;
    [SerializeField] Tower towerPrefab;
    [SerializeField] Transform spawnerTransform;

    Queue<Tower> towerQueue = new Queue<Tower>();

    public void AddTower(WayPoint waypointToPlaceOn)
    { 
        int nTowers = towerQueue.Count;
        print(gameObject.name + " Tower Placement");

        if(nTowers < towerLimit)
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
        var newTower = Instantiate(towerPrefab, newBaseWayPoint.transform.position, Quaternion.identity); // object pool

        newTower.transform.parent = spawnerTransform; 

        newTower.baseWaypoint = newBaseWayPoint;
        newBaseWayPoint.isPlacable = false;

        towerQueue.Enqueue(newTower);
    }

    private void MoveExistingTower(WayPoint waypointToPlaceOn)
    {
        var oldTower = towerQueue.Dequeue();

        oldTower.baseWaypoint.isPlacable = true; // frees up the block
        waypointToPlaceOn.isPlacable = false;
        oldTower.baseWaypoint = waypointToPlaceOn;
        oldTower.transform.position = waypointToPlaceOn.transform.position;

        towerQueue.Enqueue(oldTower);
    }
}
