using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] WayPoint startWayPoint, endWayPoint;

    private Dictionary <Vector2, WayPoint> grid = new Dictionary<Vector2, WayPoint>();
    private Queue <WayPoint> wayPointQueue = new Queue<WayPoint>();

    private bool isAlgoRunning = true;

    private WayPoint currentsearchCenter; // The current search center grid coordinate 
    private List<WayPoint> path = new List<WayPoint>(); 

    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    public List<WayPoint> GetPath()
    {
        if(path.Count == 0)
            CalculatePath();

        return path;
    }

    private void CalculatePath()
    {
        LoadWayPointsInGridDictionary();
        DoBreathFirstSearch();
        CreatePath();
    }

    private void CreatePath()
    {
        SetAsPath(endWayPoint);

        WayPoint previous = endWayPoint.exploredFrom;
        while(previous != startWayPoint)
        {
            SetAsPath(previous); 
            previous = previous.exploredFrom;
        }

        SetAsPath(startWayPoint);
        path.Reverse();
    }

    void SetAsPath(WayPoint waypoint)
    {
        path.Add(waypoint);
        waypoint.isPlacable = false;
    }

    private void LoadWayPointsInGridDictionary()
    {
        var waypoints = FindObjectsOfType<WayPoint>();

        foreach (WayPoint waypoint in waypoints)
        {
            var gridPos = waypoint.GridCoordinate;

            if (grid.ContainsKey(gridPos))
                Debug.LogWarning("Skipping Overlapping Block" + waypoint);
            else
                grid.Add(gridPos, waypoint);
        }
    }

    void DoBreathFirstSearch()
    {
        wayPointQueue.Enqueue(startWayPoint);
        while(wayPointQueue.Count > 0 && isAlgoRunning)
        {
            currentsearchCenter = wayPointQueue.Dequeue();
            // print("current searchCenter: " + searchCenter);
            HaltIfEndFound();
            ExploreNeighbours();
            currentsearchCenter.isExplored = true;
        }
       // print("Finished Pathfinding ?"); 
    }
    
    private void HaltIfEndFound()
    {
        if (currentsearchCenter == endWayPoint)
        {
            isAlgoRunning = false;
            //print(" Searching for end node, therefore stopping "); // todo remove log
        }
    }

    private void ExploreNeighbours()
    {
        if(!isAlgoRunning) { return; }

        foreach(Vector2Int direction in directions)
        {
            Vector2Int neighbourCoordinate = currentsearchCenter.GridCoordinate + direction;
            if (grid.ContainsKey(neighbourCoordinate))
            {
                QueueNewNeighbour(neighbourCoordinate);
            }
            // print("print" + neighbourCoordinates);
        }
    }

    private void QueueNewNeighbour(Vector2Int neighbourCoordinates)
    {
        WayPoint neighbour = grid[neighbourCoordinates];
        if(neighbour.isExplored || wayPointQueue.Contains(neighbour))
        {
            // do nothing
        }
        else
        {
            wayPointQueue.Enqueue(neighbour);
            neighbour.exploredFrom = currentsearchCenter;
           // print("Queueing " + neighbour);
        }
    }
}
