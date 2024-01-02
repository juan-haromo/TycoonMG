using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationsController : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public GroundDetector groundDetector;

    private float speed;
    private bool isGrounded;
    private Animator playerAnimator;
    // Start is called before the first frame update
    void Start()
    {
        speed = 0.0f;
        isGrounded = true;
        playerAnimator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        SetParameters();
    }

    private void SetParameters()
    {
         playerAnimator.SetBool("IsDancing", playerMovement.IsDancing());
         CheckSpeed();
         CheckGrounded();
         playerAnimator.SetFloat("Speed", speed);
         playerAnimator.SetBool("IsGrounded", isGrounded);
    }

    public void CheckSpeed()
    {
        speed = playerMovement.GetCurrentSpeed();
    }

    public void CheckGrounded()
    {
        isGrounded = groundDetector.GetIsGrounded();
    }
}

