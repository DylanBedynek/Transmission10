using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class BatteryBehavior : MonoBehaviour
{
    public enum BATTERYSTATE { Red = 1, Blue, Green };

    GameObject AIState;
<<<<<<< HEAD
    AIPatrol aiPatrol;
=======
    AIPatrol aipatrol;
    
>>>>>>> 28c08ea70c3e61ef541b09a9b2a59a7e4da42ac9

    public float batteryLife = 100f;
    public float amountLost;
    public float timerRedBlue = 10f;
    public float timerGreen = 5f;
    public int batteryColor = 0;
    public AAL_FogPriority fog;
    public BATTERYSTATE whatColor;
    public GameObject mainCamera;
    public CameraFollow camFollow;
    public Vector3 oldPosition = Vector3.zero;
    public PostProcessingProfile redFilter;
    public PostProcessingProfile blueFilter;
    public PostProcessingProfile greenFilter;
    public PostProcessingBehaviour postProcessingBehaviour;

    // Use this for initialization
    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        camFollow = mainCamera.GetComponent<CameraFollow>();
        postProcessingBehaviour = mainCamera.GetComponent<PostProcessingBehaviour>();
        AIState = GameObject.FindGameObjectWithTag("Roger");
<<<<<<< HEAD
        aiPatrol = AIState.GetComponent<AIPatrol>();
        if(GetComponent<AAL_FogPriority>() != null)
        {
            fog = GetComponent<AAL_FogPriority>();
        }
=======
        aipatrol = AIState.GetComponent<AIPatrol>();
>>>>>>> 28c08ea70c3e61ef541b09a9b2a59a7e4da42ac9
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            batteryColor = 0;
<<<<<<< HEAD
            aiPatrol.redPlaying = false;
            aiPatrol.bluePlaying = false;
=======
            AIPatrol.redPlaying = false;
            AIPatrol.bluePlaying = false;
>>>>>>> 28c08ea70c3e61ef541b09a9b2a59a7e4da42ac9
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && batteryLife >= 10f && batteryColor == 0)
        {
            batteryColor = 1;
<<<<<<< HEAD
            aiPatrol.redPlaying = true;
            aiPatrol.bluePlaying = false;
=======
            AIPatrol.redPlaying = true;
            AIPatrol.bluePlaying = false;
>>>>>>> 28c08ea70c3e61ef541b09a9b2a59a7e4da42ac9
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && batteryLife >= 10f && batteryColor == 0)
        {
            batteryColor = 2;
<<<<<<< HEAD
            aiPatrol.redPlaying = false;
            aiPatrol.bluePlaying = true;
=======
            AIPatrol.redPlaying = false;
            AIPatrol.bluePlaying = true;
>>>>>>> 28c08ea70c3e61ef541b09a9b2a59a7e4da42ac9
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && batteryLife >= 50f && batteryColor == 0)
        {
            batteryColor = 3;
<<<<<<< HEAD
            aiPatrol.redPlaying = false;
            aiPatrol.bluePlaying = false;
=======
            AIPatrol.redPlaying = false;
            AIPatrol.bluePlaying = false;
>>>>>>> 28c08ea70c3e61ef541b09a9b2a59a7e4da42ac9
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
<<<<<<< HEAD
=======
               
>>>>>>> 28c08ea70c3e61ef541b09a9b2a59a7e4da42ac9
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
<<<<<<< HEAD
                if (timerGreen == 5f)
=======
                
                if (timerGreen == 3f)
>>>>>>> 28c08ea70c3e61ef541b09a9b2a59a7e4da42ac9
                {
                    batteryLife -= 50f;
                    postProcessingBehaviour.profile = greenFilter;
                    oldPosition = camFollow.transform.position;

                }

                timerGreen -= Time.deltaTime;
                if(timerGreen >= 3.0f)
                {
                    camFollow.isGreen = true;
                    camFollow.transform.position = Vector3.Lerp(camFollow.transform.position, camFollow.cameraPosition2, Time.deltaTime);
                }
                if(timerGreen <= 1.5f)
                {
                    camFollow.transform.position = Vector3.Lerp(camFollow.transform.position, camFollow.cameraPosition1, Time.deltaTime);
                }
                if (timerGreen <= 0)
                {
                    batteryColor = 0;
                    postProcessingBehaviour.profile = null;
                    timerGreen = 5f;
                    camFollow.isGreen = false;
                }
                break;
<<<<<<< HEAD
            default:
                timerGreen = 5f;
=======
            default:              
                timerGreen = 3f;
>>>>>>> 28c08ea70c3e61ef541b09a9b2a59a7e4da42ac9
                timerRedBlue = 10f;
                if (postProcessingBehaviour.profile != null)
                {
                    postProcessingBehaviour.profile = null;

                }
                break;
        }

    }
}
