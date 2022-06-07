using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] List<WayPoint> path; // todo remove

    [SerializeField] ParticleSystem goalParticle;
    [SerializeField] float movementPeriod =1;
   
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
            yield return new WaitForSeconds(movementPeriod);
        }
        print("End Patrol");
        SelftDestruct();
    }

    private void SelftDestruct() 
    {
        var deathVfx = Instantiate(goalParticle, transform.position, Quaternion.identity);
        deathVfx.Play();
        float destroyPlay = deathVfx.main.duration;
        Destroy(deathVfx.gameObject, destroyPlay); // you're not destroying object you were destroying particlesystem

        Destroy(gameObject); // destroy so that it won't sit in hierachy means world
    }
}
