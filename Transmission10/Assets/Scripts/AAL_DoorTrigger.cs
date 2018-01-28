using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AAL_DoorTrigger : MonoBehaviour {

    private Animator animInstance;

	// Use this for initialization
	void Start () {
        animInstance = this.gameObject.GetComponentInParent<Animator>();
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            animInstance.SetBool("DoorIsTriggered", true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            animInstance.SetBool("DoorIsTriggered", false);
        }
    }
}
