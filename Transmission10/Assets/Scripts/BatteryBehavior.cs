using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryBehavior : MonoBehaviour
{
   public enum BATTERYSTATE { Red = 1, Blue, Green };

    public float batteryLife = 100f;
    public float amountLost;
    public int batteryColor = 0;
    public BATTERYSTATE whatColor;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            batteryColor++;
            if(batteryColor > 3)
            {
                batteryColor = 1;
            }
        }

        whatColor = (BATTERYSTATE)batteryColor;

        switch (whatColor)
        {
            case BATTERYSTATE.Red:
                batteryLife -= 10f;
                //amountLost = Time.deltaTime * 3f;
                batteryColor = 0;
                break;
            case BATTERYSTATE.Blue:
                batteryLife -= 10f;
                //amountLost = Time.deltaTime * 2f;
                batteryColor = 0;
                break;
            case BATTERYSTATE.Green:
                batteryLife -= 10f;
                //amountLost = Time.deltaTime;
                batteryColor = 0;
                break;
            default:
                break;
        }

        //batteryLife -= amountLost;
    }
}
