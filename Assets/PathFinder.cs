using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] WayPoint startWayPoint, EndWayPoint;
    Dictionary<Vector2, WayPoint> grid = new Dictionary<Vector2, WayPoint>();
    // Start is called before the first frame update
    void Start()
    {
        LoadBlocks();
        ColorStartAndEnd();
    }

    private void ColorStartAndEnd()
    {
        startWayPoint.SetTopColor(Color.red);
        EndWayPoint.SetTopColor(Color.cyan);
    }

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<WayPoint>();
        
        foreach(WayPoint waypoint in waypoints)
        {
            var gridPos = waypoint.GetGridPos();
            if(grid.ContainsKey(gridPos))
            {
                Debug.LogWarning("Skipping Overlapping Block" + waypoint);
            }
            else
            {
                grid.Add(gridPos, waypoint);
                
                waypoint.SetTopColor(Color.black); 

            }
        }
        print("Loaded" + grid.Count +"Blocks");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
