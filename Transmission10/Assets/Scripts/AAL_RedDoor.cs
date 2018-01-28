using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AAL_RedDoor : MonoBehaviour {

    private AIPatrol aiScript;


    private Animator animInstance;


    // Use this for initialization
    void Start()
    {
        animInstance = this.gameObject.GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update () {
		if(AIPatrol.redPlaying == true)
        {
            animInstance.SetBool("DoorIsTriggered", true);
        }
        else
        {
            animInstance.SetBool("DoorIsTriggered", false);
        }
	}
}
