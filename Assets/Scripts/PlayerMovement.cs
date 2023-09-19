using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //public
    public float walkSpeed;
    public float runsSpeed;
    public float rotationSpeed;
    public bool canMove;
    public Transform cameraAim;
    //private 
    private Vector3 movementVector;
    private float actualSpeed;
    private CharacterController characterController;
   


    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        actualSpeed = walkSpeed;
        movementVector = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        Gravity();
        if (canMove)
        {
            Run();
            Walk();
            AlignPlayer();
        }
    }

    void Walk()
    {
        //Get input
        movementVector.z = Input.GetAxis("Horizontal");
        movementVector.x = Input.GetAxis("Vertical");

       //Normalize
        movementVector = movementVector.normalized;

        movementVector = cameraAim.TransformDirection(movementVector);

        //Move
        characterController.Move(movementVector * Time.deltaTime *  actualSpeed);

    }
    void Run()
    {
        if (Input.GetAxis("Run")>0f)
        {
            actualSpeed = runsSpeed;
        }
        else
        {
            actualSpeed = walkSpeed;
        }
    }
    void Gravity()
    {
        Vector3 gravity = new Vector3(0f, -4 * Time.deltaTime, 0f);
        characterController.Move(gravity);
    }

    void AlignPlayer()
    {
        if (characterController.velocity.magnitude > 0f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movementVector), rotationSpeed * Time.deltaTime);
        }
    }
}
