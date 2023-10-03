using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    public float radius;
    public LayerMask detectedLayers;

    private bool isGroundaed;
   
    // Update is called once per frame
    void Update()
    {
        CheckGround(); 
    }

    void CheckGround()
    {
        isGroundaed = Physics.CheckSphere(transform.position, radius, detectedLayers);
    }

    public bool GetIsGrounded()
    {
        return isGroundaed;
    }
}
