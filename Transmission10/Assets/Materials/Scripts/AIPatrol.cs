using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AIPatrol : MonoBehaviour
{

    GameObject player;

    NavMeshAgent myAgent;
    public GameObject[] waypoints;
    int currentWP = 0;

    private Animator anim;

    float accuracy = 1.0f;


    public bool playerSighted;
    public float sightDist, fieldOfViewAngle = 100f;

    public float atkRange = 0.6f;

    private void Awake()
    {
        if (anim != null)
            anim = GetComponent<Animator>();
    }

    // Use this for initialization
    void Start()
    {

        myAgent = GetComponent<NavMeshAgent>();
        waypoints = GameObject.FindGameObjectsWithTag("waypoint");

        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void LateUpdate()
    {

        Vector3 lookAtGoal = new Vector3
            (waypoints[currentWP].transform.position.x, this.transform.position.y, waypoints[currentWP].transform.position.z);
        Vector3 direction = lookAtGoal - this.transform.position;

        this.transform.LookAt(lookAtGoal);

        if (direction.magnitude < accuracy)
        {
            currentWP++;
            if (currentWP >= waypoints.Length)
            {
                currentWP = 0;
            }

        }

        if(!playerSighted)
            myAgent.SetDestination(lookAtGoal);

        SearchForPlayer();

    }
    

    void SearchForPlayer()
    {
        RaycastHit hit;

        Debug.DrawRay(transform.position + Vector3.up, transform.forward * sightDist, Color.red);
        Debug.DrawRay(transform.position + Vector3.up, (transform.forward + transform.right).normalized * sightDist, Color.red);
        Debug.DrawRay(transform.position + Vector3.up, (transform.forward - transform.right).normalized * sightDist, Color.red);

        if (Physics.Raycast(transform.position, transform.forward, out hit, sightDist))
        {
            if(hit.collider.gameObject.tag == "Player")
            {
                playerSighted = true;
                transform.LookAt(hit.collider.gameObject.transform);
                myAgent.SetDestination(hit.collider.gameObject.transform.position);
                KeepDistance();
            }
        }
        if (Physics.Raycast(transform.position, (transform.forward + transform.right).normalized, out hit, sightDist))
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                playerSighted = true;
                transform.LookAt(hit.collider.gameObject.transform);
                myAgent.SetDestination(hit.collider.gameObject.transform.position);
                KeepDistance();
            }
        }
        if (Physics.Raycast(transform.position, (transform.forward - transform.right).normalized, out hit, sightDist))
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                playerSighted = true;
                transform.LookAt(hit.collider.gameObject.transform);
                myAgent.SetDestination(hit.collider.gameObject.transform.position);
                KeepDistance();
            }
        }
    }

    void KeepDistance()
    {
        float dist = Vector3.Distance(transform.position, player.transform.position);

        if(dist <= atkRange)
        {
            Debug.Log("I can hit the player");
            myAgent.isStopped = true;
        }
    }
}
