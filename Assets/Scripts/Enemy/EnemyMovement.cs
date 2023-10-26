using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] List<WayPoint> path; // todo remove serializefield

    [SerializeField] ParticleSystem goalParticle;
    [SerializeField] float movementPeriod = 1;
   
    // Start is called before the first frame update
    void Start()
    {
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
            yield return new WaitForSeconds(movementPeriod);
        }
        print("End Patrol");
        SelftDestruct();
    }

    private void SelftDestruct() 
    {
        var deathVfx = Instantiate(goalParticle, transform.position + new Vector3(0f, 15f, 0f), Quaternion.identity);
        deathVfx.Play();
        float destroyPlay = deathVfx.main.duration;
        Destroy(deathVfx.gameObject, destroyPlay); 

        Destroy(gameObject); 
    }
}
