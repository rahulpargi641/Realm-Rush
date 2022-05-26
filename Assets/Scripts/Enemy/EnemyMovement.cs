using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] List<WayPoint> path; // todo remove
   
    // Start is called before the first frame update
    void Start()
    {
        
        // print("Hey, I'm back at Start");
        PathFinder pathFinder = FindObjectOfType<PathFinder>();
        path = pathFinder.GetPath();
        StartCoroutine(FollowPath(path));
    }

    IEnumerator FollowPath(List<WayPoint> path)
    {
        print("Starting Patrol");
        foreach (WayPoint wayPoint in path)
        {
            //print(wayPoint.name);
            transform.position = wayPoint.transform.position;
            // print(transform.position.x + "," + transform.position.z);   // to know about coroutine
            yield return new WaitForSeconds(2f);
        }
        print("End Patrol");  
    } 

    // Update is called once per frame
    void Update()
    {
        
    }
}
