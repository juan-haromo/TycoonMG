using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSwords : MonoBehaviour
{
    private Vector3 rotation;
    public float rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rotation.y = rotationSpeed;
    }

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(rotation * Time.deltaTime);
    }
}
