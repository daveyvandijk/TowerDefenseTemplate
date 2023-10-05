using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private float speed = 1;
    [SerializeField] private int nextWaypointIndex = 1;
    [SerializeField] private float reachedWaypointclearance = 0.25f;
    [SerializeField] private Path path;
    

    // Start is called before the first frame update
    void Awake()
    {
        path = FindAnyObjectByType<Path>();
        
    }
    void Start()
    {
        transform.position = path.waypoints[0].position;
        nextWaypointIndex = 1;
         
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, path.waypoints[nextWaypointIndex].position,Time.deltaTime * speed);
        if (Vector3.Distance(transform.position, path.waypoints[nextWaypointIndex].position) <= reachedWaypointclearance)
        {
            nextWaypointIndex = nextWaypointIndex + 1;
            if (nextWaypointIndex >= path.waypoints.Length)
            {
                
                Destroy(gameObject);
            }
        }
    }
}
