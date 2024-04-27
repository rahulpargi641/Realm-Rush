using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] ParticleSystem goalParticle;
    [SerializeField] float movementPeriod = 1;

    [SerializeField] List<WayPoint> path; // todo remove serializefield

    // Start is called before the first frame update
    void Start()
    {
        GetAndFollowPath();
    }

    private void GetAndFollowPath()
    {
        PathFinder pathFinder = FindObjectOfType<PathFinder>();
        path = pathFinder.GetPath();
        StartCoroutine(FollowPath(path));
    }

    IEnumerator FollowPath(List<WayPoint> path)
    {
        //print("Starting Patrol");
        foreach (WayPoint wayPoint in path)
        {
            //print(wayPoint.name);
            transform.position = wayPoint.transform.position; 
            yield return new WaitForSeconds(movementPeriod);
        }
        //print("End Patrol");
        SelftDestruct();
    }

    private void SelftDestruct() 
    {
        var deathVfx = Instantiate(goalParticle, transform.position + new Vector3(0f, 15f, 0f), Quaternion.identity); // Object pooling
        deathVfx.Play();
        float destroyPlay = deathVfx.main.duration;
        Destroy(deathVfx.gameObject, destroyPlay); // object pooling

        Destroy(gameObject); 
    }
}
