using System;
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

    public static event Action onWaypointEndTrigger;

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
        if (nextWaypointIndex == path.waypoints.Length)
        {
            endline();
            Debug.Log("einde pad");
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, path.waypoints[nextWaypointIndex].position, Time.deltaTime * speed);
            if (Vector3.Distance(transform.position, path.waypoints[nextWaypointIndex].position) <= reachedWaypointclearance)
            {

                nextWaypointIndex = nextWaypointIndex + 1;
            }
        }

        /*
        transform.position = Vector3.MoveTowards(transform.position, path.waypoints[nextWaypointIndex].position,Time.deltaTime * speed);
        if (Vector3.Distance(transform.position, path.waypoints[nextWaypointIndex].position) <= reachedWaypointclearance)
        {
            
            nextWaypointIndex = nextWaypointIndex + 1;
            if (nextWaypointIndex == path.waypoints.Length)
            {
                endline();
                Debug.Log("einde pad");
            }
        }*/
    }

    public void endline()
    {
        Destroy(gameObject);
        onWaypointEndTrigger?.Invoke();
        
    }

    public static void AddOnWaypointEndTriggerListener(Action listener)
    {
        WaypointFollower.onWaypointEndTrigger += listener;
    }
}
