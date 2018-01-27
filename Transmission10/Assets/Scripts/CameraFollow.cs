using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float walkDistance;
    public float runDistance;
    public float height;
    public float rotateSpeed;
    Transform _myTransform;

	// Use this for initialization
	void Start ()
    {
		if(target == null)
        {
            Debug.LogWarning("There is no target.");
        }

        _myTransform = transform;
	}
	
	// Update is called once per frame
	void LateUpdate ()
    {
        _myTransform.position = new Vector3(target.position.x, target.position.y + height, target.position.z - walkDistance);
        _myTransform.LookAt(target.transform);
	}
}
