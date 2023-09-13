using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //public
    public float walkSpeed;
    public float runsSpeed;
    public bool canMove;
    //private 
    private Vector3 movementVector;
    private float actualSpeed;
    private CharacterController characterController;
    private Vector3 gravity = new Vector3(0f, -4 * Time.deltaTime, 0f);


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
        }
    }

    void Walk()
    {
        //Get input
        movementVector.x = Input.GetAxis("Horizontal");
        movementVector.z = Input.GetAxis("Vertical");

       //Normalize
        movementVector = movementVector.normalized;

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
        
        characterController.Move(gravity);
    }
}
