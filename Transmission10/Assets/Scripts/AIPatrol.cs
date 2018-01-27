using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AIPatrol : MonoBehaviour {

    NavMeshAgent myAgent;
    public GameObject[] waypoints;
    int currentWP = 0;

    private Animator anim;

    float accuracy = 1.0f;

    private void Awake()
    {
        if (anim != null)
            anim = GetComponent<Animator>();
    }

    // Use this for initialization
    void Start () {

        myAgent = GetComponent<NavMeshAgent>();
        waypoints = GameObject.FindGameObjectsWithTag("waypoint");

	}
	
	// Update is called once per frame
	void LateUpdate () {

        Vector3 lookAtGoal = new Vector3
            (waypoints[currentWP].transform.position.x, this.transform.position.y, waypoints[currentWP].transform.position.z);
        Vector3 direction = lookAtGoal - this.transform.position;

        if (direction.magnitude < accuracy)
        {
            currentWP++;
            if (currentWP >= waypoints.Length)
            {
                currentWP = 0;
            }

        }

        myAgent.SetDestination(lookAtGoal);

    }

}
