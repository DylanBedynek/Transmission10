using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickUp : MonoBehaviour
{
    GameObject player;
    GameObject battery;
    BatteryBehavior batteryBehavior;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        batteryBehavior = player.GetComponent<BatteryBehavior>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (batteryBehavior.batteryLife != 100f)
            {
                batteryBehavior.batteryLife = 100f;
                Destroy(this.gameObject);
            }
        }
    }
}
