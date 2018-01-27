using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryLifeDisplay : MonoBehaviour
{
    GameObject player;
    BatteryBehavior battery;
    public Text myText;


	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        myText = GetComponent<Text>();
        battery = player.GetComponent<BatteryBehavior>();
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        myText.text = battery.batteryLife.ToString() + "%";
    }
}
