using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] WayPoint startWayPoint, endWayPoint;
    Dictionary <Vector2, WayPoint> grid = new Dictionary<Vector2, WayPoint>();
    Queue <WayPoint> queue = new Queue<WayPoint>();
     bool isRunning = true;
    WayPoint searchCenter;
    List<WayPoint> path = new List<WayPoint>(); 

    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    public List<WayPoint> GetPath()
    {
        if(path.Count==0)
        {
            CalculatePath();
        }
        return path;
    }

    private void CalculatePath()
    {
        LoadBlocks();
        ColorStartAndEnd();
        BreathFirstSearch();
        CreatePath();
    }

    // Start is called before the first frame update

    private void CreatePath()
    {
        print("Creating path");
        path.Add(endWayPoint);
        WayPoint previous = endWayPoint.exploredFrom;
        while(previous!=startWayPoint)
        {
            // add intermediate waypoints
            path.Add(previous);
            previous = previous.exploredFrom;
        }
        path.Add(startWayPoint);
        path.Reverse();
       // print(path);
        // add start waypoint
        // reverse the list
    }

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<WayPoint>();

        foreach (WayPoint waypoint in waypoints)
        {
            var gridPos = waypoint.GetGridPos();
            if (grid.ContainsKey(gridPos))
            {
                Debug.LogWarning("Skipping Overlapping Block" + waypoint);
            }
            else
            {
                grid.Add(gridPos, waypoint);

                waypoint.SetTopColor(Color.black);      

            }
        }
       // print("Loaded" + grid.Count + "Blocks");

    }
    void BreathFirstSearch()
    {
        queue.Enqueue(startWayPoint);
        while(queue.Count>0 && isRunning)   // This will prevent us from getting us in a infinite loop
        {
            searchCenter = queue.Dequeue();
            // print("searchCenter: " + searchCenter); // todo remove log
            HaltIfEndFound();
            ExploreNeighbours();
            searchCenter.isExplored = true;
            
        }
        print("Finished Pathfinding ?");  // Execution comes here
    }

     void HaltIfEndFound()
    {
        if (searchCenter == endWayPoint)
        {
            print(" Searching for end node, therefore stopping "); // todo remove log
            isRunning = false;
        }

    }

    private void ExploreNeighbours()
    {
        if(!isRunning) { return; }

        foreach(Vector2Int direction in directions)
        {
            Vector2Int neighbourCoordinates = searchCenter.GetGridPos() + direction;
          //  print("print" + neighbourCoordinates);
           /* try
            {
                QueueNewNeighbours(neighbourCoordinates);
            }
            catch
            {

            }  */  

            if(grid.ContainsKey(neighbourCoordinates))
            {
                QueueNewNeighbours(neighbourCoordinates);
            }
        }
    }

    private void QueueNewNeighbours(Vector2Int neighbourCoordinates)
    {
        
        WayPoint neighbour = grid[neighbourCoordinates];
        if(neighbour.isExplored || queue.Contains(neighbour))
        {
            // do nothing 
        }
        else
        {
            queue.Enqueue(neighbour);
            neighbour.exploredFrom = searchCenter;
           // print("Queueing " + neighbour);
        }
       
    }

    private void ColorStartAndEnd()
    {
        // todo consider moving out
        startWayPoint.SetTopColor(Color.red);
        endWayPoint.SetTopColor(Color.cyan);
    }

   

    // Update is called once per frame
    void Update()
    {
        
    }
}
