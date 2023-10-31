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
    private float currentSpeed;
    private bool isGrounded;
    private CharacterController characterController;
    private bool isDancing;
    // Start is called before the first frame update
    void Start()
    {

        characterController = GetComponent<CharacterController>();
        speed = 0.0f;
        currentSpeed = 0.0f;
        isGrounded = true;
        vectorMovement = Vector3.zero;
        verticalForce = Vector3.zero;
    }

    
    void Update()
    {
        if (canMove)
        {
            Move();
        }
        Gravity();
        CheckGround();
    }

    public void Move()
    {
        
        Walk();
        Run();
        AlignPlayer();
        Jump();
    }

    //Funciones para caminar
    void Walk()
    {
        //Conseguimos los inputs
        vectorMovement.x = Input.GetAxis("Horizontal");
        vectorMovement.z = Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.Q)) { isDancing = true; }
        if(isDancing && (vectorMovement.x>0.3f || vectorMovement.z > 0.3f || !isGrounded)) { isDancing=false; }
        //Normalizamos el vector de movimiento
        vectorMovement = vectorMovement.normalized;

        //Nos movemos en direccion a la camara
        vectorMovement = cameraAim.TransformDirection(vectorMovement);

        //Velocidad actual con suavizado 
        currentSpeed = Mathf.Lerp(currentSpeed, vectorMovement.magnitude * speed, 10f * Time.deltaTime);

        //Movemos al player
        characterController.Move(currentSpeed * Time.deltaTime * vectorMovement);
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

    public float GetCurrentSpeed()
    {
        return currentSpeed;
    }
    
    public bool IsDancing()
    {
        return isDancing;
    }

    public void Stop()
    {
        currentSpeed = 0.0f;    
    }
}