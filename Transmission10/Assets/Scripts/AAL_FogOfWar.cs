using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AAL_FogOfWar : MonoBehaviour {

    [SerializeField]
    private GameObject fogObject;
 
    private Material fogMaterial;

    [SerializeField]
    private int fogPriority;

    protected AAL_FogPriority fogScript;


	// Use this for initialization
	void Start () {
        fogMaterial = fogObject.GetComponent<Renderer>().material;
        //fogObject = GameObject.FindGameObjectWithTag("FogOfWar");
        fogScript = fogObject.GetComponent<AAL_FogPriority>();
	}

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            fogScript.ChangeColor("r");
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            fogScript.ChangeColor("g");
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            fogScript.ChangeColor("b");
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            fogScript.ChangeColor("black");
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Player" && fogScript.fogNumber !=1)
    //    {
    //        //1 = Main Area
    //        //2 = Side Rooms
    //        if (fogObject.GetComponent<AAL_FogPriority>().fogNumber != 1)
    //        {
    //            fogScript.FogOn();
    //        }
    //        else
    //        {
    //            fogScript.FogOff();
    //        }
    //    }
    //    else if (other.tag == "Player" && fogScript.fogNumber == 1)
    //    {
    //        //1 = Main Area
    //        //2 = Side Rooms
    //        if (fogObject.GetComponent<AAL_FogPriority>().fogNumber != 1)
    //        {
    //            fogScript.FogOff();
    //        }
    //        else
    //        {
    //            fogScript.FogOn();
    //        }
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    //1 = Main Area
    //    //2 = Side Rooms
    //    if (fogObject.GetComponent<AAL_FogPriority>().fogNumber != 1)
    //    {
    //        fogScript.FogOff();
    //    }
    //    else
    //    {
    //        fogScript.FogOn();
    //    }
    //}

}
