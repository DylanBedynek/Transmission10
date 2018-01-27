using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //public Transform target;
    //public float walkDistance;
    //public float runDistance;
    //public float height;
    //public float rotateSpeed;

    public Transform player;
    public int cameraSelection;
    public float cameraMoveSpeed;
    public Transform cameraPosition1;
    public Transform cameraPosition2;
    public Transform cameraPosition3;
    public Transform cameraPosition4;
    //Transform _myTransform;



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            cameraSelection++;
        }
        gameObject.transform.LookAt(player);
        CameraRotation();
    }
    void CameraRotation()
    {
        switch (cameraSelection)
        {
            case 1:
                gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, cameraPosition1.position, cameraMoveSpeed * Time.deltaTime);
                break;
            case 2:
                gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, cameraPosition2.position, cameraMoveSpeed * Time.deltaTime);
                break;
            case 3:
                gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, cameraPosition3.position, cameraMoveSpeed * Time.deltaTime);
                break;
            case 4:
                gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, cameraPosition4.position, cameraMoveSpeed * Time.deltaTime);
                break;
            default:
                cameraSelection = 1;
                break;
        }
    }
    // Update is called once per frame
    //void LateUpdate()
    //{
    //    _myTransform.position = new Vector3(target.position.x, target.position.y + height, target.position.z - walkDistance);
    //    _myTransform.LookAt(target.transform);
    //}
}
