using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] List<WayPoint> path;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FollowPath());
        print("Hey, I'm back at Start");
      
       
    }

    IEnumerator FollowPath()
    {
        print("Starting Patrol");
        foreach (WayPoint wayPoint in path)
        {
            //print(wayPoint.name);
            transform.position = wayPoint.transform.position;
            print(transform.position.x + "," + transform.position.z); 
            yield return new WaitForSeconds(1f);
        }
        print("End Patrol");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
