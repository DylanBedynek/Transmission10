using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class BatteryBehavior : MonoBehaviour
{
    public enum BATTERYSTATE { Red = 1, Blue, Green };

    public float batteryLife = 100f;
    public float amountLost;
    public float timerRedBlue = 10f;
    public float timerGreen = 3f;
    public int batteryColor = 0;
    public BATTERYSTATE whatColor;
    public GameObject mainCamera;
    public PostProcessingProfile redFilter;
    public PostProcessingProfile blueFilter;
    public PostProcessingProfile greenFilter;
    public PostProcessingBehaviour postProcessingBehaviour;

    // Use this for initialization
    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        postProcessingBehaviour = mainCamera.GetComponent<PostProcessingBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            batteryColor = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && batteryLife >= 10f && batteryColor == 0)
        {
            batteryColor = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && batteryLife >= 10f && batteryColor == 0)
        {
            batteryColor = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && batteryLife >= 50f && batteryColor == 0)
        {
            batteryColor = 3;
        }

        whatColor = (BATTERYSTATE)batteryColor;

        switch (whatColor)
        {
            case BATTERYSTATE.Red:
                if (timerRedBlue == 10f)
                {
                    batteryLife -= 10f;
                    postProcessingBehaviour.profile = redFilter;
                }

                timerRedBlue -= Time.deltaTime;

                if (timerRedBlue <= 0)
                {
                    batteryColor = 0;
                    postProcessingBehaviour.profile = null;
                    timerRedBlue = 10f;
                }
                break;
            case BATTERYSTATE.Blue:
                if (timerRedBlue == 10f)
                {
                    batteryLife -= 10f;
                    postProcessingBehaviour.profile = blueFilter;
                }

                timerRedBlue -= Time.deltaTime;

                if (timerRedBlue <= 0)
                {
                    batteryColor = 0;
                    postProcessingBehaviour.profile = null;
                    timerRedBlue = 10f;
                }
                break;
            case BATTERYSTATE.Green:
                if (timerGreen == 3f)
                {
                    batteryLife -= 50f;
                    postProcessingBehaviour.profile = greenFilter;
                }

                timerGreen -= Time.deltaTime;

                if (timerGreen <= 0)
                {
                    batteryColor = 0;
                    postProcessingBehaviour.profile = null;
                    timerGreen = 3f;
                }
                break;
            default:
                timerGreen = 3f;
                timerRedBlue = 10f;
                if(postProcessingBehaviour.profile != null)
                {
                    postProcessingBehaviour.profile = null;
                }
                break;
        }

    }
}
