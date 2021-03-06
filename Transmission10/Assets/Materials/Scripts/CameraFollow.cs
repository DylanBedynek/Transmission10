﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float walkDistance;
    public float runDistance;
    public float height;
    Transform _myTransform;
    GameObject player;
    BatteryBehavior battery;
    public bool isGreen = false;

    //public float turnSpeed = 4.0f;
    //Vector3 offset;
    //public float rotateSpeed;

    //public Transform player;
    //public int cameraSelection;
    //public float cameraMoveSpeed;
    public Vector3 cameraPosition1;
    public Vector3 cameraPosition2;
    //public Transform cameraPosition3;
    //public Transform cameraPosition4;

    void Start()
    {
        if(target == null)
        {
            //Debug.LogWarning("No target attatched to camera");
        }
        //offset = new Vector3(target.position.x, target.position.y + height, target.position.z - walkDistance);
        _myTransform = transform;
        

    }


    // Update is called once per frame
    void LateUpdate()
    {
        cameraPosition1 = new Vector3(_myTransform.position.x, _myTransform.position.y + 4, _myTransform.position.z);
        cameraPosition2 = new Vector3(_myTransform.position.x, _myTransform.position.y + 40, _myTransform.position.z);

        if (isGreen == false)
        {
            _myTransform.position = new Vector3(target.position.x, target.position.y + height, target.position.z - walkDistance);
        }
            _myTransform.LookAt(target.position);

        //Mouse movement for camera?

        //offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offset;
        //transform.position = target.position + offset;
    }
}
