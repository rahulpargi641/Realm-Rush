using System.Collections;
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
        //print(gameObject.name + " Tower Placement");

        if(numTowers<=towerLimit)
        {
            InstantiateNewTower(baseWaypoint);
            
        }
        else
        {
            MoveExistingTower(baseWaypoint);
        }

    }

    private void InstantiateNewTower(WayPoint baseWaypoint)
    {
        var newTower= Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);

        newTower.transform.parent = towerParentTransform; 

        newTower.baseWaypoint = baseWaypoint;
        baseWaypoint.isPlacable = false;

        towerQueue.Enqueue(newTower);
        //print("Tower List" );
        // print("Tower placed");
    }

    private void MoveExistingTower(WayPoint newBaseWaypoint)
    {
        var oldTower = towerQueue.Dequeue();
        //print("Max Towers reached Can't Place Anymore Towers");

        oldTower.baseWaypoint.isPlacable = true; // free up the block
        newBaseWaypoint.isPlacable = false;
        oldTower.baseWaypoint = newBaseWaypoint;
        oldTower.transform.position = newBaseWaypoint.transform.position;

        towerQueue.Enqueue(oldTower);
    }
    
}
