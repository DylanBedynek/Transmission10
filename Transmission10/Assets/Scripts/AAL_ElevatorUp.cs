using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AAL_ElevatorUp : MonoBehaviour {

    [SerializeField]
    private GameObject finalSpot;
 
    //[SerializeField]
    //private GameObject finalSpotBack;
    public GameObject player;

    private Transform playerTransform;
    PlayerMovement playerMove;

    //private bool isUsed = false;
    
    // Use this for initialization

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            player.transform.position= finalSpot.transform.position;
            playerMove = player.GetComponent<PlayerMovement>();
            playerMove.checkPoint = finalSpot.transform.position;
            //PlayerMovement.checkPoint = finalSpot.transform.position;
            //isUsed = true;
        }
        //else if (other.tag == "Player" && !isUsed)
        //{
        //    playerTransform = finalSpotBack.transform;
        //    isUsed = false;
        //}

    }

    //void OnTriggerExit(Collider other)
    //{
    //    if (other.tag == "Player")
    //        isUsed = !isUsed;
    //}

}
