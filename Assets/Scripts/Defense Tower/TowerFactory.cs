using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] int towerLimit = 5;
    [SerializeField] Tower towerPrefab;
    [SerializeField] Transform towerParentTransform;

    Queue<Tower> towerQueue = new Queue<Tower>();

    public void AddTower(WayPoint baseWaypoint)
    { 
        int numTowers = towerQueue.Count;
        print(gameObject.name + " Tower Placement");

        if(numTowers < towerLimit)
        {
            InstantiateNewTower(baseWaypoint);
        }
        else
        {
            MoveExistingTower(baseWaypoint);
        }

        AudioManager.Instance.PlaySound(SoundType.TowerPlaced);
    }

    private void InstantiateNewTower(WayPoint newBaseWayPoint)
    {
        var newTower= Instantiate(towerPrefab, newBaseWayPoint.transform.position, Quaternion.identity);

        newTower.transform.parent = towerParentTransform; 

        newTower.baseWaypoint = newBaseWayPoint;
        newBaseWayPoint.isPlacable = false;

        towerQueue.Enqueue(newTower);
    }

    private void MoveExistingTower(WayPoint newBaseWaypoint)
    {
        var oldTower = towerQueue.Dequeue();

        oldTower.baseWaypoint.isPlacable = true; // frees up the block
        newBaseWaypoint.isPlacable = false;
        oldTower.baseWaypoint = newBaseWaypoint;
        oldTower.transform.position = newBaseWaypoint.transform.position;

        towerQueue.Enqueue(oldTower);
    }
}
