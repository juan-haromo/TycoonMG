using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Variables Publicas
    public Transform cameraAim;
    public float walkSpeed, runSpeed, rotationSpeed, jumpForce;
    public bool canMove;
    public GroundDetector groundDetector;
    
    //Variables privadas
    private Vector3 vectorMovement;
    private Vector3 verticalForce;
    private float speed;
    private bool isGrounded;
    private CharacterController characterController;
    // Start is called before the first frame update
    void Start()
    {

        characterController = GetComponent<CharacterController>();
        speed = walkSpeed;
        vectorMovement = Vector3.zero;
        verticalForce = Vector3.zero;
    }


    void Update()
    {
        if (canMove)
        {
            Walk();
            Run();
            AlignPlayer();
            Jump();
        }
        Gravity();
        CheckGround();
    }
    //Funciones para caminar
    void Walk()
    {
        //Conseguimos los inputs
        vectorMovement.x = Input.GetAxis("Horizontal");
        vectorMovement.z = Input.GetAxis("Vertical");
        //Normalizamos el vector de movimiento
        vectorMovement = vectorMovement.normalized;

        //Nos movemos en direccion a la camara
        vectorMovement = cameraAim.TransformDirection(vectorMovement);

        //Movemos al player
        characterController.Move(vectorMovement * speed * Time.deltaTime);

    }
    void Run()
    {
        //Si presionamos el boton para correr modificamos la velocidad
        if (Input.GetAxis("Run") > 0f)
        {
            speed = runSpeed;
        }
        else
        {
            speed = walkSpeed;
        }
    }
    //Funcion provisional de gravedad
    void Gravity()
    {
        if (!isGrounded)
        {
            verticalForce += Physics.gravity * Time.deltaTime;
        }
        else
        {
            verticalForce = new Vector3(0.0f, -2, 0.0f);
        }

        characterController.Move(verticalForce * Time.deltaTime);
        
    }

    //Funcion para alinear al jugador hacia donde se mueve
    void AlignPlayer()
    {
        //Si nos estamos moviendo, alineamos la rotacion
        if (characterController.velocity.magnitude > 0f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(vectorMovement), rotationSpeed * Time.deltaTime);
        }
    }

    void Jump()
    {
        if(isGrounded && Input.GetAxis("Jump") > 0.0f)
        {
            verticalForce = new Vector3(0.0f, jumpForce, 0.0f);
            isGrounded = false;
        }
    }

    void CheckGround()
    {
        isGrounded = groundDetector.GetIsGrounded();
    }
}