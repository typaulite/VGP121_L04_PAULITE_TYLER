using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyControl : MonoBehaviour {

    //public Transform target;
    public GameObject[] waypoints;
    public float speed=5;
    int current = 0 ;
    float wPradius=1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //Enemy Waypoint Path
        if (Vector3.Distance(waypoints[current].transform.position, transform.position) <wPradius)
        {
            current++;
            if (current>=waypoints.Length)
            { 
                current=0;
            }
        }
         transform.position=Vector3.MoveTowards(transform.position, waypoints[current].transform.position,Time.deltaTime*speed);
        
        //GetComponent<NavMeshAgent>().SetDestination(Waypoint1.position, Waypoint2.position, Waypoint3.position, Waypoint4.position);
	}
}
