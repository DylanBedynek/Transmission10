using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float turnSmoothing = 15f; // A smoothing value for turning the player.
    public float speedDampTime = 0.1f; // The damping for the speed parameter
    float animationSpeedPercent;

    private Animator anim; // Reference to the animator component.
    private Rigidbody rigidBody;
    Vector3 inputDir = Vector3.zero;

    public float walkSpeed = 2f;
    public float runSpeed = 6f;

    void Awake()
    {
        anim = GetComponent<Animator>();

        rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Cache the inputs.
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if(h != 0f || v != 0f)
        {
            if(animationSpeedPercent < 0.5f)
            {
                animationSpeedPercent += Time.deltaTime;
            }
            anim.SetFloat("SpeedPercent", animationSpeedPercent);
        }
        if(h == 0 && v == 0)
        {
            if(animationSpeedPercent > 0)
            {
                animationSpeedPercent -= Time.deltaTime;
            }
            anim.SetFloat("SpeedPercent", animationSpeedPercent);
        }
        MovementManagement(h, v);

        //Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"),0f, Input.GetAxisRaw("Vertical"));
        //Vector3 inputDir = input.normalized;

        //if (inputDir != Vector3.zero)
        //{
        //    transform.eulerAngles = Vector3.up * Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg;
        //}

        //bool running = Input.GetKey(KeyCode.LeftShift);

        //float speed = (walkSpeed) * inputDir.magnitude;
        //(running) ? runSpeed :

        //transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);

        //float animationSpeedPercent = (.5f) * inputDir.magnitude;
        //(running) ? 1 : 
        //anim.SetFloat("SpeedPercent", animationSpeedPercent);

    }

    /////////////////////////////////////////////CHARACTER MOVEMENT/////////////////////////////////////////


    void MovementManagement(float horizontal, float vertical)
    {
        //Vector3 targetDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));

        // If there is some axis input...
        if (horizontal != 0f || vertical != 0f)
        {
            // ... set the players rotation and set the speed parameter to 5.3f.
            Rotating(horizontal, vertical);
            //if (anim != null)
            //    anim.SetFloat("SpeedPercent", .1f);
        }
        //else
        //    // Otherwise set the speed parameter to 0.
        //    if (anim != null)
        //    anim.SetFloat("SpeedPercent", 0);
    }



    void Rotating(float horizontal, float vertical)
    {
        // Create a new vector of the horizontal and vertical inputs.
        Vector3 targetDirection = new Vector3(horizontal, 0f, vertical);
        targetDirection = Camera.main.transform.TransformDirection(targetDirection);
        targetDirection.y = 0.0f;
        inputDir = targetDirection.normalized;
        animationSpeedPercent = (.3f) * inputDir.magnitude;

        //if (horizontal != 0f || vertical != 0f)
        //{
        //    float speed = (walkSpeed) * inputDir.magnitude;
        //    anim.SetFloat("SpeedPercent", animationSpeedPercent);
        //}

        this.transform.position += Vector3.Normalize(targetDirection) * 5 * Time.deltaTime;
        // Create a rotation based on this new vector assuming that up is the global y axis.
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);

        // Create a rotation that is an increment closer to the target rotation from the player's rotation.
        Quaternion newRotation = Quaternion.Lerp(rigidBody.rotation, targetRotation, turnSmoothing * Time.deltaTime);

        // Change the players rotation to this new rotation.
        rigidBody.MoveRotation(newRotation);
    }
}
