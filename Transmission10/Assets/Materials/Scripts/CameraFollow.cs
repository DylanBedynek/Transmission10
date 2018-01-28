using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float walkDistance;
    public float runDistance;
    public float height;
    Transform _myTransform;
    //public float rotateSpeed;

    //public Transform player;
    //public int cameraSelection;
    //public float cameraMoveSpeed;
    //public Transform cameraPosition1;
    //public Transform cameraPosition2;
    //public Transform cameraPosition3;
    //public Transform cameraPosition4;

    void Start()
    {
        if(target == null)
        {
            Debug.LogWarning("No target attatched to camera");
        }
        _myTransform = transform;
    }


    // Update is called once per frame
    void LateUpdate()
    {
        gameObject.transform.position = new Vector3(target.position.x, target.position.y + height, target.position.z - walkDistance);
        _myTransform.LookAt(target);
    }
}
